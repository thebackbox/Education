using System;
using System.Collections.Generic;
using System.Threading;

namespace Delegates {
    internal class Program {
        public delegate int BinaryOp(int x, int y);

        private static void Main(string[] args) {
            // First, make a Car object. 
            Car c1 = new Car("SlugBug", 100, 10);

            // Now, tell the car which method to call 
            // when it wants to send us messages.  
            c1.RegisterWithCarEngine(OnCarEngineEvent);
            var s = new Program();
            c1.RegisterWithCarEngine(s.Hey);
            c1.UnRegisterWithCarEngine(s.Hey);
            c1.UnRegisterWithCarEngine(OnCarEngineEvent);

            c1.hey = str => Console.WriteLine(str);

            var asdf = new Car.CarEngineHandler(OnCarEngineEvent);

            // Speed up (this will trigger the events). 
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            new GenericDelegates().Main();
            new Event().Main();

            Console.ReadLine();
        }

        // This is the target for incoming events.  
        public static void OnCarEngineEvent(string msg) {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }

        public void Hey(string str) {
            Console.WriteLine(str);
        }

        public void Hey2(string str) {
            Console.WriteLine(str);
        }

        public class Car {
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

            public delegate void CarEngineHandler(string msgForCaller);

            private CarEngineHandler listOfHandlers;

            public delegate void Mydel(string str);

            public Mydel hey;

            public void RegisterWithCarEngine(CarEngineHandler methodToCall) {
                listOfHandlers += methodToCall;
            }
            public void UnRegisterWithCarEngine(CarEngineHandler methodToCall) {
                listOfHandlers -= methodToCall;
            }
            public void Accelerate(int delta) {

                hey("hhsdf");
                // If this car is "dead," send dead message. 
                if (carIsDead) {
                    if (listOfHandlers != null)
                        listOfHandlers("Sorry, this car is dead...");
                }
                else {
                    CurrentSpeed += delta;

                    // Is this car "almost dead"? 
                    if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null) {
                        listOfHandlers("Careful buddy! Gonna blow!");
                    }
                    if (CurrentSpeed >= MaxSpeed)
                        carIsDead = true;
                    else
                        Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }
}
