using PeopleViewer.Presentation;
using PersonDataReader.SQL;
using System.Windows;

namespace PeopleViewer.Desktop;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ComposeObjects();
        Application.Current.MainWindow.Title = "With Dependency Injection";
        Application.Current.MainWindow.Show();
    }

    private static void ComposeObjects()
    {
        // Data Reader
        var reader = new SQLReaderProxy(AppDomain.CurrentDomain.BaseDirectory + "People.db");

        var viewModel = new PeopleViewModel(reader);
        Application.Current.MainWindow = new PeopleViewerWindow(viewModel);
    }
}
