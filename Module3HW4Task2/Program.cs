using System.Security.Cryptography.X509Certificates;

namespace Module3HW4Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>()
            {
                new() {Id = 1, FirstName = "John", LastName = "Doe", Email = "jdoe@mail.com", Phone = "42352355" },
                new() {Id = 2, FirstName = "Bill", LastName = "Gates", Email = "bill_gates@mail.com", Phone = "12342142" },
                new() {Id = 3, FirstName = "Anna", LastName = "Lee", Email = "annalee@mail.com", Phone = "76547546" },
                new() {Id = 6, FirstName = "Anna", LastName = "Ahmatova", Email = "annahmatova@mail.com", Phone = "655414" },
                new() {Id = 4, FirstName = "Jimmy", LastName = "Wolsh", Email = "jimmywolsh@mail.com", Phone = "86575634" },
                new() {Id = 5, FirstName = "Sarah", LastName = "Stanford", Email = "sarahstan@mail.com", Phone = "34554667" },
            };
            Contact CheckFirstOrDefault(string name)
            {
                return contacts.FirstOrDefault(contact => contact.FirstName == name);
            }
            IEnumerable<Contact> CheckWhere(string query)
            {
                return contacts.Where(contact => contact.Email.Contains(query));
            }
            IEnumerable<object> CheckSelect()
            {
                return contacts.Select(contact => new {
                    FullName = contact.FirstName + " " + contact.LastName,
                    Email = contact.Email
                });
            }
            IEnumerable<Contact> CheckDistinct()
            {
                return contacts.DistinctBy(contact => contact.FirstName);
            }
            bool CheckAny(string name)
            {
                return contacts.Any(contact => contact.FirstName == name);
            }
            IEnumerable<Contact> CheckOrderByEmail()
            {
                return contacts.OrderBy(contact => contact.Email);
            }

            var result1 = CheckFirstOrDefault("Jimmy");
            Console.WriteLine("Result 1 " + result1.FirstName + " " + result1.LastName);

            var result2 = CheckWhere("anna");
            Console.WriteLine("result 2");
            foreach (var item in result2)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            var result3 = CheckSelect();
            Console.WriteLine("result 3");
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }

            var result4 = CheckDistinct();
            Console.WriteLine("result 4");
            foreach (var item in result4)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            var result5 = CheckAny("Bill");
            Console.WriteLine("result 5");
            Console.WriteLine(result5);

            var result6 = CheckOrderByEmail();
            Console.WriteLine("result 6");
            foreach (var item in result6)
            {
                Console.WriteLine(item.Email);
            }
        }
    }
}
