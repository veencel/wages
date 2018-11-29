using System;
using System.IO;

namespace Wages
{
    class EntryReader
    {
        private Employee[] Employees { get; }

        public EntryReader(Employee[] employees)
        {
            Employees = employees;
        }

        public Entry[] Read(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Entry[] entries = new Entry[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                entries[i] = CreateEntry(lines[i]);
            }

            return entries;
        }

        private Entry CreateEntry(string line)
        {
            string[] parts = line.Split('#');

            int identifier = int.Parse(parts[0]);
            Employee employee = FindEmployee(identifier);

            DateTime enteredAt = DateTime.Parse(parts[1]);
            DateTime leavedAt = DateTime.Parse(parts[2]);

            return new Entry(employee, enteredAt, leavedAt);
        }

        private Employee FindEmployee(int identifier)
        {
            Employee sought = null;

            foreach (Employee employee in Employees)
            {
                if (employee.Identifier == identifier)
                {
                    sought = employee;
                }
            }

            return sought;
        }
    }
}
