using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase db = new MyDatabase();

           
            foreach (var person in db.People)
            {
                Console.WriteLine("{0,-4}{1,-10}", person.Id, person.Name);
                foreach (var address in person.Addresses)
                {
                    Console.WriteLine("{0,25}", address.StreetName);
                }
            }
            Console.WriteLine("\n=================================\n");

            foreach (var address in db.Addresses)
            {
                Console.WriteLine("{0,-4}{1,-10}", address.Id, address.StreetName);
                foreach (var person in address.People)
                {
                    Console.WriteLine("{0,25}", person.Name);
                }
            }



           

        }
    }

    public class MyDatabase
    {
        public List<Person> People { get; set; } = new List<Person>();
        public List<Address> Addresses { get; set; } = new List<Address>();


        public MyDatabase()
        {
            //==========Seeding People
            Person p1 = new Person() { Id = 1, Name = "Markos" };
            Person p2 = new Person() { Id = 2, Name = "Maria" };
            Person p3 = new Person() { Id = 3, Name = "Giorgos" };

            //==========Seeding Addresses
            Address a1 = new Address() { Id = 1, StreetName = "Omonia" };
            Address a2 = new Address() { Id = 2, StreetName = "Exarxia" };
            Address a3 = new Address() { Id = 3, StreetName = "Biktoria" };




            //==========Assign Addresss to People
            p1.Addresses.Add(a1);
            p1.Addresses.Add(a2);
            p1.Addresses.Add(a3);

            p2.Addresses.Add(a1);

            p3.Addresses.Add(a2);
            p3.Addresses.Add(a3);


            //==========Assign People to Cards

            a1.People.Add(p1);
            a1.People.Add(p2);

            a2.People.Add(p1);
            a2.People.Add(p3);

            a3.People.Add(p1);
            a3.People.Add(p3);


            People.Add(p1);
            People.Add(p2);
            People.Add(p3);

            Addresses.Add(a1);
            Addresses.Add(a2);
            Addresses.Add(a3);

        }
    }


    //Many to Many
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
    }

    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }

        public List<Person> People { get; set; } = new List<Person>();
    }
}
    

