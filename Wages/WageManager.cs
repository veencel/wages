namespace Wages
{
    class WageManager
    {
        private Employee[] Employees;
        private Entry[] Entries;

        public WageManager(Employee[] employees, Entry[] entries)
        {
            Employees = employees;
            Entries = entries;

            foreach (Employee employee in Employees)
            {
                SetEntries(employee);
            }
        }

        public WorkingDay[] GetDailyEntries()
        {
            WorkingDay[] days = new WorkingDay[Entries.Length];
            int daysCount = 0;

            foreach (Entry entry in Entries)
            {
                WorkingDay day = null;

                for (int i = 0; i < daysCount; i++)
                {
                    if (days[i].Day == entry.EnteredAt.Date)
                    {
                        day = days[i];
                        break;
                    }
                }

                if (day == null)
                {
                    day = new WorkingDay(entry.EnteredAt.Date, new Entry[] {entry});
                    days[daysCount++] = day;
                }
                else
                {
                    day.AddEntry(entry);
                }
            }

            WorkingDay[] trimmed = new WorkingDay[daysCount];

            for (int i = 0; i < daysCount; i++)
            {
                trimmed[i] = days[i];
            }

            return trimmed;
        }

        public Employee GetAttendanceSheet(string employeeName)
        {
            Employee sought = null;

            foreach (Employee employee in Employees)
            {
                if (employee.Name == employeeName)
                {
                    sought = employee;
                    break;
                }
            }

            return sought;
        }

        public Employee[] GetWages()
        {
            Employee[] sorted = new Employee[Employees.Length];
            int sortedCount = 0;

            while (sortedCount != Employees.Length)
            {
                Employee max = null;

                for (int i = 0; i < Employees.Length; i++)
                {
                    bool alreadyAdded = false;
                    for (int j = 0; j < sortedCount; j++)
                    {
                        if (Employees[i].Identifier == sorted[j].Identifier)
                        {
                            alreadyAdded = true;
                        }
                    }

                    if (!alreadyAdded && (max == null || max.MonthlyWage < Employees[i].MonthlyWage))
                    {
                        max = Employees[i];
                    }
                }

                sorted[sortedCount++] = max;
            }

            return sorted;
        }

        public double CalculateWageCost()
        {
            double wageCost = 0;

            foreach (Employee employee in Employees)
            {
                wageCost += employee.MonthlyWage;
            }

            return wageCost;
        }

        private void SetEntries(Employee employee)
        {
            Entry[] entries = new Entry[Entries.Length];
            int entryCount = 0;

            foreach (Entry entry in Entries)
            {
                if (entry.Employee.Identifier == employee.Identifier)
                {
                    entries[entryCount++] = entry;
                }
            }

            Entry[] trimmed = new Entry[entryCount];

            for (int i = 0; i < entryCount; i++)
            {
                trimmed[i] = entries[i];
            }

            employee.SetEntries(trimmed);
        }
    }
}
