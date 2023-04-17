using System;
using System.Collections.Immutable;

namespace Demo.Provider.Service
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    using System.Collections.Concurrent;
    using Models;

    public class Database
    {
        private readonly ConcurrentDictionary<Guid, Person> _database;

        public Database(IReadOnlyCollection<Person> initial)
        {
            this._database = new ConcurrentDictionary<Guid, Person>(initial.ToDictionary(p => p.PersonId));
        }

        public IReadOnlyCollection<Person> All() => _database.Values.ToImmutableList();
        public bool Get(Guid id, out Person person) => _database.TryGetValue(id, out person);
        public bool Remove(Guid id) => _database.TryRemove(id, out _);

        public void Update(Guid id, Person person)
        {
            person.PersonId = id;
            _database.AddOrUpdate(id, person, (_, _) => person);
        }

        public void RemoveAll()
        {
            _database.Clear();
        }
    }
}