using System;

namespace Wages
{
    class Entry
    {
        public Employee Employee;
        public DateTime EnteredAt;
        public DateTime LeavedAt;

        public double WorkedMinutes
        {
            get { return (LeavedAt - EnteredAt).TotalMinutes; }
        }

        public Entry(Employee employee, DateTime enteredAt, DateTime leavedAt)
        {
            Employee = employee;
            EnteredAt = enteredAt;
            LeavedAt = leavedAt;
        }
    }
}
