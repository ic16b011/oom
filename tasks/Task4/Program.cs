using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Task4
{
    interface IClass
    {
        string Name { get; }
        void setPlace(string newPlace);
    }

    public class Hobby : IClass
    {
        private int hobbieyears;

        public Hobby(string name, string place)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name empty");
            if (string.IsNullOrWhiteSpace(place)) throw new Exception("Place empty");

            Name = name;
            Place = place;
        }

        public string Name { get; }
        public string Place { set; get; }

        public void setPlace(string newPlace)
        {
            Place = newPlace;
            Console.WriteLine("New Place Hobby: " + Place);
        }

        public void UpdateHobbyYears(int newyears)
        {
            if (newyears < 0) throw new ArgumentException("Years cannot be negative", newyears.ToString());
            hobbieyears = newyears;
            Console.WriteLine("Hobby Years: " + hobbieyears);
        }
    }

    public class Friends : IClass
    {
        public Friends(string name, string place)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name empty");
            if (string.IsNullOrWhiteSpace(place)) throw new Exception("Place empty");

            Name = name;
            Place = place;
        }

        public string Name { get; }
        public string Place { set; get; }

        public void setPlace(string newPlace)
        {
            if (string.IsNullOrWhiteSpace(newPlace)) throw new Exception("newPlace empty");

            Place = newPlace;
            Console.WriteLine("New Place Friend: " + Place);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var newHobby = new Hobby("Fußball", "Sportplatz");
            var newHobby2 = new Hobby("Programmieren", "FH");
            string newPlace;
            int i = 0;

            Console.WriteLine("Hobby Name: " + newHobby.Name);
            Console.WriteLine("Hobby Place: " + newHobby.Place);
            newHobby.UpdateHobbyYears(5);
            newHobby.UpdateHobbyYears(8);

            Console.Write("Set new Place: ");
            newPlace = Console.ReadLine();
            newHobby.setPlace(newPlace);

            var newFriend = new Friends("Alex", "Wien");
            var newFriend2 = new Friends("Bianca", "Wien");

            var objects = new IClass[] { newHobby, newHobby2, newFriend, newFriend2 };
            string s = JsonConvert.SerializeObject(objects);
            Console.WriteLine(s);

            while (i < objects.Count())
            {
                objects[i].setPlace("Wien_Test");
                i++;
            }

            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            string json = JsonConvert.SerializeObject(newFriend, settings);

            var cwd = Directory.GetCurrentDirectory();
            var file = Path.Combine(cwd, "friends.json");
            File.WriteAllText(file, json);

            var jsonread = File.ReadAllText(file);
            Friends newFriend3 = JsonConvert.DeserializeObject<Friends>(jsonread, settings);
            Console.WriteLine(newFriend.Name + " " + newFriend.Place);
            Console.WriteLine(newFriend3.Name + " " + newFriend3.Place);

            Console.Write("Zum Beenden Taste druecken");
            Console.ReadLine();
        }
    }
}
