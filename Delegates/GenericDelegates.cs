using System;

namespace Delegates {
    public class GenericDelegates {
        public delegate void MyGenericDelegate<T>(T arg);
        public void Main() {
            Console.WriteLine("***** Generic Delegates *****\n");

            // Register targets. 
            MyGenericDelegate<string> strTarget = StringTarget;
            strTarget("Some string data");

            Action<int> dd = IntTarget;


            MyGenericDelegate<int> intTarget = IntTarget;
            var intTarasdfget = new Action<int>(IntTarget);
            intTarget(9);

        }
        static void StringTarget(string arg) {
            Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
        }

        static void IntTarget(int arg) {
            Console.WriteLine("++arg is: {0}", ++arg);
        }

    }
}
