using System;

namespace OOP_Enums_Assignment
{
    // Exercise 1 - Traffic Light
    enum TrafficLight { Red, Yellow, Green }

    class TrafficLightSystem
    {
        private TrafficLight light;
        private bool pedWaiting;

        public TrafficLightSystem()
        {
            light = TrafficLight.Red;
            pedWaiting = false;
        }

        // cycle through lights
        public void CycleLight()
        {
            if (light == TrafficLight.Red)
                light = TrafficLight.Green;
            else if (light == TrafficLight.Green)
                light = TrafficLight.Yellow;
            else
                light = TrafficLight.Red;

            Console.WriteLine($"Light is now: {light}");
        }

        // pedestrian crossing
        public void PedestrianCross()
        {
            pedWaiting = true;
            Console.WriteLine("Pedestrian wants to cross...");

            if (light == TrafficLight.Green)
            {
                light = TrafficLight.Yellow;
                Console.WriteLine("Changing to Yellow...");
                System.Threading.Thread.Sleep(1000);
                light = TrafficLight.Red;
                Console.WriteLine("Red light - pedestrian can cross now!");
                pedWaiting = false;
            }
        }

        public void CheckLight()
        {
            if (light == TrafficLight.Green)
                Console.WriteLine("Go!");
            else if (light == TrafficLight.Yellow)
                Console.WriteLine("Slow down");
            else
                Console.WriteLine("Stop!");
        }

        // simulating 3 intersections
        public static void MultipleIntersections()
        {
            Console.WriteLine("\n--- Multiple Intersections ---");
            TrafficLightSystem t1 = new TrafficLightSystem();
            TrafficLightSystem t2 = new TrafficLightSystem();
            TrafficLightSystem t3 = new TrafficLightSystem();

            Console.WriteLine("Intersection 1:");
            t1.CycleLight();

            Console.WriteLine("\nIntersection 2:");
            t2.CycleLight();

            Console.WriteLine("\nIntersection 3:");
            t3.PedestrianCross();
        }
    }

    // Exercise 2 - Game Character
    enum CharacterStatus { Healthy, Poisoned, Paralyzed, Dead }

    class GameCharacter
    {
        private CharacterStatus status;
        private int hp;
        private string name;

        public GameCharacter(string n)
        {
            name = n;
            status = CharacterStatus.Healthy;
            hp = 100;
        }

        // check if player can move
        public void CanMove()
        {
            Console.WriteLine($"\n{name} status: {status}");

            if (status == CharacterStatus.Paralyzed || status == CharacterStatus.Dead)
            {
                Console.WriteLine("Can't move!");
            }
            else if (status == CharacterStatus.Poisoned)
            {
                Console.WriteLine("Moving slow...");
                hp -= 5; // poison damage
                Console.WriteLine($"HP: {hp}");
            }
            else
            {
                Console.WriteLine("Moving normal");
            }
        }

        // healing items
        public void UseItem(string item)
        {
            Console.WriteLine($"\nUsed {item}");

            if (item == "Health Potion")
            {
                status = CharacterStatus.Healthy;
                hp = 100;
                Console.WriteLine("Fully healed!");
            }
            else if (item == "Antidote")
            {
                if (status == CharacterStatus.Poisoned)
                {
                    status = CharacterStatus.Healthy;
                    Console.WriteLine("Poison removed");
                }
            }
            else if (item == "Cure")
            {
                if (status == CharacterStatus.Paralyzed)
                {
                    status = CharacterStatus.Healthy;
                    Console.WriteLine("Can move again");
                }
            }
        }

        // combat damage
        public void GetHit(string attack)
        {
            Console.WriteLine($"\n{name} got hit by {attack}");

            if (attack == "Poison Arrow")
            {
                status = CharacterStatus.Poisoned;
                hp -= 20;
                Console.WriteLine("Poisoned!");
            }
            else if (attack == "Stun")
            {
                status = CharacterStatus.Paralyzed;
                Console.WriteLine("Paralyzed!");
            }
            else if (attack == "Critical")
            {
                hp -= 50;
                if (hp <= 0)
                {
                    status = CharacterStatus.Dead;
                    hp = 0;
                    Console.WriteLine("Died!");
                }
            }
            else
            {
                hp -= 10;
            }

            Console.WriteLine($"HP: {hp}");
        }
    }

    // Exercise 3 - File Permissions
    [Flags]
    enum FilePermission { Read = 1, Write = 2, Execute = 4 }

    class FileSystem
    {
        private FilePermission perms;
        private string filename;

        public FileSystem(string f, FilePermission p)
        {
            filename = f;
            perms = p;
        }

        public void ShowPermissions()
        {
            Console.WriteLine($"\nFile: {filename}");
            Console.WriteLine($"Permissions: {perms}");

            if ((perms & FilePermission.Read) == FilePermission.Read)
                Console.WriteLine("- Can Read");

            if ((perms & FilePermission.Write) == FilePermission.Write)
                Console.WriteLine("- Can Write");

            if ((perms & FilePermission.Execute) == FilePermission.Execute)
                Console.WriteLine("- Can Execute");
        }

        public void TryRead()
        {
            Console.WriteLine($"\nReading {filename}...");
            if ((perms & FilePermission.Read) == FilePermission.Read)
                Console.WriteLine("Read successful");
            else
                Console.WriteLine("Can't read!");
        }

        public void TryWrite()
        {
            Console.WriteLine($"\nWriting to {filename}...");
            if ((perms & FilePermission.Write) == FilePermission.Write)
                Console.WriteLine("Write successful");
            else
                Console.WriteLine("Can't write!");
        }

        public void TryExecute()
        {
            Console.WriteLine($"\nExecuting {filename}...");
            if ((perms & FilePermission.Execute) == FilePermission.Execute)
                Console.WriteLine("Execute successful");
            else
                Console.WriteLine("Can't execute!");
        }

        // different user roles
        public static void UserRoles()
        {
            Console.WriteLine("\n--- User Roles ---");

            // admin can do everything
            FileSystem admin = new FileSystem("admin.txt",
                FilePermission.Read | FilePermission.Write | FilePermission.Execute);
            Console.WriteLine("\nAdmin:");
            admin.ShowPermissions();

            // normal user
            FileSystem user = new FileSystem("user.txt",
                FilePermission.Read | FilePermission.Write);
            Console.WriteLine("\nUser:");
            user.ShowPermissions();

            // guest can only read
            FileSystem guest = new FileSystem("guest.txt", FilePermission.Read);
            Console.WriteLine("\nGuest:");
            guest.ShowPermissions();
        }

        // security test
        public static void SecurityTest()
        {
            Console.WriteLine("\n--- Security Test ---");

            FileSystem secure = new FileSystem("system.exe",
                FilePermission.Read | FilePermission.Execute);

            secure.TryRead();
            secure.TryWrite(); // should fail
            secure.TryExecute();
        }
    }

    // Exercise 4 - Days of Week
    enum DayOfWeek { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    class CalendarSystem
    {
        private DayOfWeek day;

        public CalendarSystem(DayOfWeek d)
        {
            day = d;
        }

        public void ShowDay()
        {
            Console.WriteLine($"\nToday: {day} (day number {(int)day})");

            if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                Console.WriteLine("Weekend!");
            else
                Console.WriteLine("Weekday");
        }

        // save to database
        public void SaveDB()
        {
            int num = (int)day;
            string name = day.ToString();

            Console.WriteLine("\nSaving to database...");
            Console.WriteLine($"Number: {num}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine("Saved!");
        }

        // weekly schedule
        public void WeekSchedule()
        {
            Console.WriteLine("\n--- Week Schedule ---");

            for (int i = 1; i <= 7; i++)
            {
                DayOfWeek d = (DayOfWeek)i;
                string task = "";

                if (d == DayOfWeek.Monday)
                    task = "Meeting at 10 AM";
                else if (d == DayOfWeek.Wednesday)
                    task = "Project due";
                else if (d == DayOfWeek.Friday)
                    task = "Submit report";
                else if (d == DayOfWeek.Saturday || d == DayOfWeek.Sunday)
                    task = "Off day";
                else
                    task = "Regular work";

                Console.WriteLine($"{d}: {task}");
            }
        }

        // reminders
        public static void Reminders()
        {
            Console.WriteLine("\n--- Reminders ---");

            DayOfWeek[] work = { DayOfWeek.Monday, DayOfWeek.Tuesday,
                DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

            Console.WriteLine("\nWorkdays:");
            foreach (DayOfWeek d in work)
            {
                Console.WriteLine($"{d}: Wake at 7, Work at 9");
            }

            Console.WriteLine("\nWeekend:");
            Console.WriteLine("Saturday: Shopping");
            Console.WriteLine("Sunday: Family time");
        }

        public void DaysToWeekend()
        {
            int current = (int)day;

            if (current < 6)
            {
                int left = 6 - current;
                Console.WriteLine($"\n{left} days until weekend");
            }
            else
            {
                Console.WriteLine("\nIt's weekend!");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("    OOP & ENUMS ASSIGNMENT");
            Console.WriteLine("====================================\n");

            // EXERCISE 1
            Console.WriteLine("\n*** EXERCISE 1: Traffic Light ***");
            TrafficLightSystem traffic = new TrafficLightSystem();
            traffic.CycleLight();
            traffic.CheckLight();
            traffic.CycleLight();
            traffic.CheckLight();
            traffic.PedestrianCross();
            TrafficLightSystem.MultipleIntersections();

            // EXERCISE 2
            Console.WriteLine("\n\n*** EXERCISE 2: Game Character ***");
            GameCharacter player = new GameCharacter("Player1");
            player.CanMove();
            player.GetHit("Poison Arrow");
            player.CanMove();
            player.UseItem("Antidote");
            player.CanMove();
            player.GetHit("Stun");
            player.CanMove();
            player.UseItem("Cure");
            player.GetHit("Critical");

            // EXERCISE 3
            Console.WriteLine("\n\n*** EXERCISE 3: File Permissions ***");
            FilePermission myPerms = FilePermission.Read | FilePermission.Write;
            FileSystem file = new FileSystem("doc.txt", myPerms);
            file.ShowPermissions();
            file.TryRead();
            file.TryWrite();
            file.TryExecute();
            FileSystem.UserRoles();
            FileSystem.SecurityTest();

            // EXERCISE 4
            Console.WriteLine("\n\n*** EXERCISE 4: Days of Week ***");
            CalendarSystem cal = new CalendarSystem(DayOfWeek.Wednesday);
            cal.ShowDay();
            cal.SaveDB();
            cal.WeekSchedule();
            cal.DaysToWeekend();
            CalendarSystem.Reminders();

            Console.WriteLine("\n\n====================================");
            Console.WriteLine("         ALL DONE!");
            Console.WriteLine("====================================");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}