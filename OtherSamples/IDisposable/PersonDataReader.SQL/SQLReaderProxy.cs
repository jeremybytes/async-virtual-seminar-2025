﻿using PeopleViewer.Common;

namespace PersonDataReader.SQL;

public class SQLReaderProxy : IPersonReader
{
    string sqlFileName;

    public SQLReaderProxy(string sqlFileName)
    {
        this.sqlFileName = sqlFileName;
    }

    public async Task<IReadOnlyCollection<Person>> GetPeople()
    {
        using SQLReader reader = new(sqlFileName);
        return await reader.GetPeople();
    }

    public async Task<Person?> GetPerson(int id)
    {
        using SQLReader reader = new(sqlFileName);
        return await reader.GetPerson(id);
    }
}
