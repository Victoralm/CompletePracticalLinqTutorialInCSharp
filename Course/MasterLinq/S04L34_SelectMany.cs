using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class Person
    {
        public string Name { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
    public class S04L34_SelectMany
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();

            IEnumerable<Person> people = new List<Person>
            {
                new Person() {Name = "Bob", PhoneNumbers = new List<string>() {"123", "456"}},
                new Person() {Name = "John", PhoneNumbers = new List<string>() {"789", "453"}},
                new Person() {Name = "Jeff", PhoneNumbers = new List<string>() {"879", "146"}},
                new Person() {Name = "Jonny", PhoneNumbers = new List<string>() {"765", "481"}},
                new Person() {Name = "Buster", PhoneNumbers = new List<string>() {"284", "809"}},
            };

            /*
            [0]:
                [0]: "123"
                [1]: "456"
            [1]:
                [0]: "789"
                [1]: "453"
            ...
            */
            IEnumerable<List<string>> phoneList = people.Select(p => p.PhoneNumbers);

            /*
            [0]: "123"
            [1]: "456"
            [2]: "789"
            ...
            */
            IEnumerable<string> phoneNumbers = people.SelectMany(p => p.PhoneNumbers);

            /*
            [0]: {Name = Bob, child = "123"}
            [1]: {Name = Bob, child = "456"}
            [2]: {Name = John, child = "789"}
            ...
            */
            var personWithPhoneNumbers = people.SelectMany(p => p.PhoneNumbers, (person, phone) => new {person.Name, child = phone});

            foreach (var person in personWithPhoneNumbers)
            {
                Console.WriteLine($"\n{person}");
                Console.WriteLine($"Person: {person.Name}, Phone: {person.child}");
            }
        }
    }
}