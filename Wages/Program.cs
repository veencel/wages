using System;

namespace Wages
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeReader employeeReader = new EmployeeReader();

            Employee[] employees = employeeReader.Read("workers.txt");

            EntryReader entryReader = new EntryReader(employees);

            Entry[] entries = entryReader.Read("entries.txt");

            WageManager manager = new WageManager(employees, entries);

            Console.WriteLine("HR Segédprogram");

            while (true)
            {
                DrawMenu();

                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ListDailyEntries(manager.GetDailyEntries());
                        break;
                    case "2":
                        Console.WriteLine("Adja meg a felhasználó nevét:");
                        ShowAttendanceSheet(manager.GetAttendanceSheet(Console.ReadLine()));
                        break;
                    case "3":
                        ShowWages(manager.GetWages());
                        break;
                    case "4":
                        ShowWageCost(manager.CalculateWageCost());
                        break;
                    case "5":
                        return;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DrawMenu()
        {
            Console.WriteLine("Válasszon a menüpontok közül");
            Console.WriteLine("1 - Dolgozók bejegyzéseinek megtekintése napi bontásban");
            Console.WriteLine("2 - Jelenléti ív lekérdezése");
            Console.WriteLine("3 - Fizetések megtekintése");
            Console.WriteLine("4 - Céges bérköltség megtekintése");
            Console.WriteLine("5 - Kilépés");
        }

        private static void ListDailyEntries(WorkingDay[] days)
        {
            Console.WriteLine("Dolgozók bejegyzései napokra bontva");
            Console.WriteLine();

            foreach (WorkingDay day in days)
            {
                Console.WriteLine(day.Day);
                Console.WriteLine();

                foreach (Entry entry in day.Entries)
                {
                    Console.WriteLine($"{entry.Employee.Name} Érkezett: {entry.EnteredAt}  Távozott: {entry.LeavedAt}");
                }

                Console.WriteLine();
            }
        }

        private static void ShowWageCost(object wageCost)
        {
            Console.WriteLine("A cég teljes bérköltsége: " + wageCost);
        }

        private static void ShowWages(Employee[] employees)
        {
            Console.WriteLine("A munkavállalók bérei");
            Console.WriteLine();

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.Name} - {employee.MonthlyWage}");
            }
        }

        private static void ShowAttendanceSheet(Employee employee)
        {
            Console.WriteLine("Jelenléti ív - " + employee.Name);
            Console.WriteLine();

            foreach (Entry entry in employee.Entries)
            {
                Console.WriteLine(entry.EnteredAt.Date);
                Console.WriteLine($"{entry.EnteredAt} - {entry.LeavedAt}");
                Console.WriteLine("Bér: " + entry.Employee.GetDailyWage(entry));
                Console.WriteLine();
            }

            Console.WriteLine("Havi bér: " + employee.MonthlyWage);
        }
    }
}
