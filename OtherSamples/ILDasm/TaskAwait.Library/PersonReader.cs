using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Channels;
using TaskAwait.Shared;

namespace TaskAwait.Library;

public class PersonReader
{
    HttpClient client = 
        new() { BaseAddress = new Uri("http://localhost:9874") };
    JsonSerializerOptions options = 
        new() { PropertyNameCaseInsensitive = true };

    public async Task<List<Person>> GetPeopleAsync()
    {
        //throw new NotImplementedException("Jeremy did not implement GetPeopleAsync");

        HttpResponseMessage response = 
            await client.GetAsync("people");

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Unable to retrieve People. Status code {response.StatusCode}");

        var stringResult = 
            await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<Person>>(stringResult, options);
        if (result is null)
            throw new JsonException("Unable to deserialize List<Person> object (json object may be empty)");
        return result;
    }

    public Person GetPerson(int id)
    {
        // Note: This method uses a hard-coded dataset.
        // It does not use the service.
        var result = People.GetPeople().FirstOrDefault(p => p.Id == id);
        if (result is null)
            throw new Exception($"Unable to locate Person object: ID={id}");
        Thread.Sleep(1000);
        return result;
    }

    public Task<Person> GetPersonAsyncWithTask(int id)
    {
        Task<List<Person>> peopleTask = GetPeopleAsync();
        Task<Person> result = peopleTask.ContinueWith(task =>
        {
            List<Person> people = task.Result;
            Person selectedPerson = people.Single(p => p.Id == id);
            return selectedPerson;
        });
        return result; // Task<Person>
    }

    public async Task<Person> GetPersonAsyncWithAwait(int id)
    {
        List<Person> people = await GetPeopleAsync();
        Person selectedPerson = people.Single(p => p.Id == id);
        return selectedPerson; // Person
    }


    public async Task<Person> GetPersonAsync(int id)
    {
        HttpResponseMessage response =
            await client.GetAsync($"people/{id}");

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Unable to retrieve People. Status code {response.StatusCode}");

        var stringResult =
            await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Person>(stringResult, options);
        if (result is null)
            throw new JsonException("Unable to deserialize Person object (json object may be empty)");
        return result;
    }

    public async Task<List<int>> GetIdsAsync(
        CancellationToken cancelToken = new())
    {
        HttpResponseMessage response = 
            await client.GetAsync("people/ids", cancelToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Unable to retrieve IDs. Status code {response.StatusCode}");

        var stringResult = 
            await response.Content.ReadAsStringAsync(cancelToken).ConfigureAwait(false);
        var result = JsonSerializer.Deserialize<List<int>>(stringResult);
        if (result is null)
            throw new JsonException("Unable to deserialize List<int> object (json object may be empty)");
        return result;
    }

    public async Task<List<Person>> GetPeopleAsync(IProgress<int> progress,
        CancellationToken cancelToken = new())
    {
        progress.Report(0);
        List<int> ids = await GetIdsAsync(cancelToken).ConfigureAwait(false);
        var people = new List<Person>();

        for (int i = 0; i < ids.Count; i++)
        {
            cancelToken.ThrowIfCancellationRequested();

            int id = ids[i];
            var person = await Task.Run(() => GetPerson(id)).ConfigureAwait(false);

            int percentComplete = (int)((i + 1) / (float)ids.Count * 100);
            progress.Report(percentComplete);

            people.Add(person);
        }

        return people;
    }

    public async IAsyncEnumerable<Person> GetPeopleStream(IProgress<int> progress,
        [EnumeratorCancellation] CancellationToken cancelToken = new())
    {
        progress.Report(0);
        List<int> ids = await GetIdsAsync(cancelToken).ConfigureAwait(false);

        for (int i = 0; i < ids.Count; i++)
        {
            cancelToken.ThrowIfCancellationRequested();
            int id = ids[i];
            var person = await GetPersonAsync(id).ConfigureAwait(false);

            int percentComplete = (int)((i + 1) / (float)ids.Count * 100);
            progress.Report(percentComplete);

            yield return person;
        }
        progress.Report(100);
    }

    public async IAsyncEnumerable<Person> GetPeopleAsyncEnumerable(IProgress<int> progress,
        [EnumeratorCancellation]CancellationToken cancelToken = new())
    {
        progress.Report(0);
        List<int> ids = await GetIdsAsync(cancelToken).ConfigureAwait(false);

        for (int i = 0; i < ids.Count; i++)
        {
            cancelToken.ThrowIfCancellationRequested();
            int id = ids[i];
            var person = await GetPersonAsync(id).ConfigureAwait(false);

            int percentComplete = (int)((i + 1) / (float)ids.Count * 100);
            progress.Report(percentComplete);

            yield return person;
        }
        progress.Report(100);
    }

    //public IAsyncEnumerable<Person> GetPeopleAsyncEnumerable(IProgress<int> progress,
    //    CancellationToken cancelToken = new())
    //{
    //    Channel<Person> channel = Channel.CreateUnbounded<Person>();

    //    Task<List<int>> idTask = GetIdsAsync(cancelToken);

    //    idTask.ContinueWith(t =>
    //    {
    //        List<int> ids = t.Result;
    //        for (int i = 0; i < ids.Count; i++)
    //        {
    //            cancelToken.ThrowIfCancellationRequested();

    //            int id = ids[i];
    //            var person = GetPerson(id);

    //            int percentComplete = (int)((i + 1) / (float)ids.Count * 100);
    //            progress.Report(percentComplete);

    //            channel.Writer.TryWrite(person);
    //        }
    //    })
    //        .ContinueWith(_ => channel.Writer.Complete());

    //    return channel.Reader.ReadAllAsync();
    //}

}