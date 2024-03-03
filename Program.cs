using System.Reflection;

namespace SealedClass
{
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
        public double PayExec();
    }
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }
        public virtual double PayExec()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s yearly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }

    }
    class Program
    {
        class Executive : Employee
        {
            public string Title { get; set; }
            public double Salary { get; set; }

            public Executive() : base()
            {
                Title = string.Empty;
                Salary = 0;
            }
            public Executive(int id, string firstName, string lastName, string title)
                : base(id, firstName, lastName)
            {
                //Salary = salary;
                Title = title;
            }
            public sealed override double Pay()
            {
                return base.PayExec();
            }
        }
        static void Main(string[] args)
        {
            //employee object
            Employee george = new Employee(5, "George", "Jetson");
            //Console.WriteLine(george.Fullname());
            Console.WriteLine($"{george.Fullname()} makes {george.Pay()} per week");

            //executive object using parameterized constructor
            Executive fred = new Executive(10, "Fred", "Flinstone", "CEO");
            //Console.WriteLine(fred.Fullname());
            Console.WriteLine($"{fred.Fullname()} makes {fred.PayExec()} per year as {fred.Title}");
        }
    }
}