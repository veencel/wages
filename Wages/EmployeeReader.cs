using System.IO;

namespace Wages
{
    class EmployeeReader
    {
        public Employee[] Read(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Employee[] employees = new Employee[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                employees[i] = CreateEmployee(lines[i]);
            }

            return employees;
        }

        private Employee CreateEmployee(string line)
        {
            string[] parts = line.Split(';');

            int identifier = int.Parse(parts[0]);
            int hourlyWage = int.Parse(parts[2]);

            return new Employee(identifier, parts[1], hourlyWage);
        }
    }
}
