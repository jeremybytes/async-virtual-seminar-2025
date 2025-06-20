﻿using Microsoft.EntityFrameworkCore;
using PeopleViewer.Common;

namespace PersonDataReader.SQL;

internal class SQLReader : IPersonReader, IDisposable
{
    private readonly PersonContext context;

    public SQLReader(string sqlFileName)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PersonContext>();
        optionsBuilder.UseSqlite($"Data Source={sqlFileName}");
        var options = optionsBuilder.Options;
        context = new PersonContext(options);
    }

    public async Task<IReadOnlyCollection<Person>> GetPeople()
    {
        await Task.Delay(1);
        return context.People!.ToList();
    }

    public Task<Person?> GetPerson(int id)
    {
        return context.People!.FirstOrDefaultAsync(p => p.Id == id);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                context.Dispose();
            }
            disposedValue = true;
        }
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(true);
    }
    #endregion
}

