using System;

namespace Wages
{
    class WorkingDay
    {
        public DateTime Day { get; }
        public Entry[] Entries { get; private set; }

        public WorkingDay(DateTime day, Entry[] entries)
        {
            Day = day;
            Entries = entries;
        }

        public void AddEntry(Entry entry)
        {
            Entry[] newEntries = new Entry[Entries.Length + 1];

            for (int i = 0; i < Entries.Length; i++)
            {
                newEntries[i] = Entries[i];
            }

            newEntries[Entries.Length] = entry;

            Entries = newEntries;
        }
    }
}
