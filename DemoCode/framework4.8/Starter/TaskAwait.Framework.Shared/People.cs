﻿using System;
using System.Collections.Generic;

namespace TaskAwait.Framework.Shared
{
    public static class People
    {
        public static List<Person> GetPeople()
        {
            return new List<Person>()
            {
                new Person(1, "John", "Koenig", new DateTime(1975, 10, 17), 6, ""),
                new Person(2, "Dylan", "Hunt", new DateTime(2000, 10, 2), 8, ""),
                new Person(3, "Leela", "Turanga", new DateTime(1999, 3, 28), 8, "{1} {0}"),
                new Person(4, "John", "Crichton", new DateTime(1999, 3, 19), 7, ""),
                new Person(5, "Dave", "Lister", new DateTime(1988, 2, 15), 9, ""),
                new Person(6, "Laura", "Roslin", new DateTime(2003, 12, 8), 6, ""),
                new Person(7, "John", "Sheridan", new DateTime(1994, 1, 26), 6, ""),
                new Person(8, "Dante", "Montana", new DateTime(2000, 11, 1), 5, ""),
                new Person(9, "Isaac", "Gampu", new DateTime(1977, 9, 10), 4, ""),
                new Person(10, "Naomi", "Nagata", new DateTime(2015, 11, 23), 7, ""),
                new Person(11, "John", "Boon", new DateTime(1993, 01, 06), 5, ""),
                new Person(12, "Kerr", "Avon", new DateTime(1978, 01, 02), 8, ""),
                new Person(13, "Ed", "Mercer", new DateTime(2017, 09, 10), 8, ""),
                new Person(14, "Devon", "", new DateTime(1973, 09, 23), 4, "{0}"),
            };
        }
    }
}
