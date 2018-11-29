namespace Wages
{
    class Employee
    {
        public int Identifier { get; }
        public string Name { get; }
        public int HourlyWage { get; }
        public Entry[] Entries { get; private set; }

        public double MonthlyWage
        {
            get
            {
                double wage = 0;

                foreach (Entry entry in Entries)
                {
                    wage += GetDailyWage(entry);
                }

                return wage;
            }
        }

        public Employee(int identifier, string name, int hourlyWage)
        {
            Identifier = identifier;
            Name = name;
            HourlyWage = hourlyWage;
            Entries = new Entry[0];
        }

        public void SetEntries(Entry[] entries)
        {
            Entries = entries;
        }

        public double GetDailyWage(Entry entry)
        {
            double workedHours = entry.WorkedMinutes / 60;

            return workedHours * HourlyWage;
        }
    }
}
