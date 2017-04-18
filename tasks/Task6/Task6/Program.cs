using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Task4
{
    /* Interface für Klassen (was sollen die Klassen können?) */
    interface IClass
    {
        string Name { get; }
        void SetPlace(string newPlace);
    }


    /* Klasse Hobby implementiert IClass */
    public class Hobby : IClass
    {
        /* private Field */
        private int hobbieyears;


        /* Konstruktor */
        public Hobby(string name, string place)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name empty");
            if (string.IsNullOrWhiteSpace(place)) throw new Exception("Place empty");

            Name = name;
            Place = place;
        }


        /* public Properties */
        public string Name { get; }
        public string Place { set; get; }


        /* Methode */
        public void SetPlace(string newPlace)
        {
            if (string.IsNullOrWhiteSpace(newPlace)) throw new Exception("Place empty");
            Place = newPlace;
            Console.WriteLine("New Place Hobby: " + Place);
        }


        /* Methode */
        public void UpdateHobbyYears(int newyears)
        {
            if (newyears < 0) throw new ArgumentException("Years cannot be negative", newyears.ToString());
            hobbieyears = newyears;
            Console.WriteLine("Hobby Years: " + hobbieyears);
        }
    }


    /* Klasse Friends implementiert IClass */
    public class Friends : IClass
    {
        /* Konstruktor */
        public Friends(string name, string place)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name empty");
            if (string.IsNullOrWhiteSpace(place)) throw new Exception("Place empty");

            Name = name;
            Place = place;
        }


        /* Properties */
        public string Name { get; }
        public string Place { set; get; }


        /* Methode */
        public void SetPlace(string newPlace)
        {
            if (string.IsNullOrWhiteSpace(newPlace)) throw new Exception("newPlace empty");
            Place = newPlace;
            Console.WriteLine("New Place Friend: " + Place);
        }
    }


    /* Klasse Program */
    class Program
    {
        /* async Task2 */
        static async Task<bool> WaitTask()
        {
            await Task.Delay(1000);
            return true;
        }


        /* main */
        static void Main(string[] args)
        {
            /* Anlegen einiger Objekte */
            var newHobby = new Hobby("Fußball", "Sportplatz");
            var newHobby2 = new Hobby("Programmieren", "FH");
            var newFriend = new Friends("Alex", "Wien");
            var newFriend2 = new Friends("Bianca", "Wien");
            int i = 0;


            /* Ausgabe des Inhalts von newHobby und HobbyYears ändern */
            Console.WriteLine("Hobby Name: " + newHobby.Name);
            Console.WriteLine("Hobby Place: " + newHobby.Place);
            newHobby.UpdateHobbyYears(5);
            newHobby.UpdateHobbyYears(8);


            /* Ändern von Place von newHobby */
            Console.Write("Set new Place: ");
            string newPlace = Console.ReadLine();
            newHobby.SetPlace(newPlace);


            /* IClass Array mit ein paar Objekten anlegen und Place ändern */
            var objects = new IClass[] { newHobby, newHobby2, newFriend, newFriend2 };

            while (i < objects.Count())
            {
                objects[i].SetPlace("Wien_Test");
                i++;
            }


            /* Einstellungen für Json Datei festlegen und Json Datei im aktuellen Directory anlegen mit dem Inhalt des Objekts newFriend */
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };
            string json = JsonConvert.SerializeObject(newFriend, settings);
            var cwd = Directory.GetCurrentDirectory();
            var file = Path.Combine(cwd, "friends.json");
            File.WriteAllText(file, json);


            /* Inhalt der zuvor angelegten Json Datei lesen und auf die Console ausgeben */
            var jsonread = File.ReadAllText(file);
            Friends newFriend3 = JsonConvert.DeserializeObject<Friends>(jsonread, settings);
            Console.WriteLine(newFriend.Name + " " + newFriend.Place);
            Console.WriteLine(newFriend3.Name + " " + newFriend3.Place);


            /* Pull Beispiel, neues Hobby anlegen und Place über Subject ändern */
            var producer = new Subject<string>();
            var newHobby3 = new Hobby("Test", "Test");
            producer.Subscribe(x => newHobby3.SetPlace(x));
            for(i = 0; i < 2; i++)
            {
                Console.Write("New Place Hobby3: ");
                var temp = Console.ReadLine();
                producer.OnNext(temp);
            }


            /* async Task1 */
            Task<bool> result = Task.Run(() => {
            for (int counter = 0; counter < 1000; counter++)
                { if (counter == 999) return true;}
                return false;
             });

            result.ContinueWith(t => Console.WriteLine("Schleife completed"));


            /* async Task2 */
            Task<bool> temp2 = WaitTask();
            temp2.ContinueWith(t => Console.WriteLine("Task Delay done"));


            /* IObservable für linke Pfeiltaste in Windows Form, KeyDown --> wenn Key gedrückt wird */
            var w = new Form();
            IObservable<Keys> moves = Observable.FromEventPattern<KeyEventArgs>(w, "KeyDown")
                .Select(u => u.EventArgs.KeyCode);

            var subscription = moves
                .Where(e => e.Equals(Keys.Left))
                .Subscribe(e => Console.WriteLine("Key Left pressed"));

            Application.Run(w);


            /* Beenden des Programms */
            Console.WriteLine("Zum Beenden Taste druecken");
            Console.ReadLine();
        }
    }
}
