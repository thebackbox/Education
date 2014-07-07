using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace Delegates {
    public class Event {
        public void Main() {
            Console.WriteLine("***** Fun with Events *****\n");
            Car c1 = new Car("SlugBug", 100, 10);

            c1.myDel = () => Console.WriteLine("jheeeeeeeeeeee");
            c1.myDel += () => Console.WriteLine("!!!!!!!!!!!");

            // Register event handlers. 
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;

            Car.CarEngineHandler d = CarExploded;
            c1.Exploded += d;

            Debug.WriteLineIf(true, "Hello there pal!");

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            // Remove CarExploded method 
            // from invocation list. 
            c1.Exploded -= d;

            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);
            Console.ReadLine();
        }

        public static void CarAboutToBlow(object sender, string msg)
        {
            Console.WriteLine(msg);
        }

        public static void CarIsAlmostDoomed(object sender, string msg) { Console.WriteLine("=> Critical Message from Car: {0}", msg); }

        public static void CarExploded(object sender, string msg) { Console.WriteLine(msg); }
    }

    public class Car
    {
        public Action myDel;

        // This delegate works in conjunction with the 
        // Car's events. 
        public delegate void CarEngineHandler(object sender, string msg);
        // This car can send these events. 
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool carIsDead;
        public Car() {
            MaxSpeed = 100;
        }
        public Car(string name, int maxSp, int currSp) {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        public void Accelerate(int delta)
        {
            myDel();

            // If the car is dead, fire Exploded event. 
            if (carIsDead) {
                if (Exploded != null)
                    Exploded(this, "Sorry, this car is dead...");
            }
            else {
                CurrentSpeed += delta;

                // Almost dead? 
                if (10 == MaxSpeed - CurrentSpeed
                  && AboutToBlow != null) {
                    AboutToBlow(this, "Careful buddy!  Gonna blow!");
                }

                // Still OK! 
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

    }
}
