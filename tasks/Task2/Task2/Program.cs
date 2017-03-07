using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public class Hobby
    {
        private int hobbieyears;

        public Hobby(string name, string place)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name empty");

            Name = name;
            Place = place;
        }

        public string Name { get; }
        public string Place { get; }
        
        public void UpdateHobbyYears(int newyears)
        {
            if (newyears < 0) throw new ArgumentException("Years cannot be negative", newyears.ToString());
            hobbieyears = newyears;
            Console.WriteLine("Hobby Years: " + hobbieyears);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hobby newHobby = new Hobby("Fußball", "Sportplatz");
            Console.WriteLine("Hobby Name: " + newHobby.Name);
            Console.WriteLine("Hobby Place: " + newHobby.Place);
            newHobby.UpdateHobbyYears(5);
            newHobby.UpdateHobbyYears(8);
        }
    }
}
