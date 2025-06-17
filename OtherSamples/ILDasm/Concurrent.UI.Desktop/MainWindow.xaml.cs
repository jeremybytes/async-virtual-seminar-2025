using System.Windows;
using TaskAwait.Library;
using TaskAwait.Shared;

namespace Concurrent.UI;

public partial class MainWindow : Window
{
    PersonReader reader = new();
    CancellationTokenSource? tokenSource;

    public MainWindow()
    {
        InitializeComponent();
    }

    // Using Task (Single Continuation)
    private void FetchWithTaskButton_Click(object sender, RoutedEventArgs e)
    {
        ClearListBox();

        Task<List<Person>> peopleTask = reader.GetPeopleAsync();

        // Always
        peopleTask.ContinueWith(
            PopulateListBox,
            TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void PopulateListBox(Task<List<Person>> task)
    {
        List<Person> people = task.Result;
        PersonListBox.ItemsSource = people;
    }

    // Using Await
    private async void FetchWithAwaitButton_Click(object sender, RoutedEventArgs e)
    {
        ClearListBox();

        List<Person> people = await reader.GetPeopleAsync();
        PersonListBox.ItemsSource = people;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        tokenSource?.Cancel();
    }

    private void ClearListBox()
    {
        PersonListBox.ItemsSource = null;
    }
}
