using System;

namespace Sketches {
    class Program {
        static void Main(string[] args) {

            var var = new Lazy<LazyClass>();

            var lazyCls = new LazyClass(1, "Title");
            lazyCls.Title = "One";
            var title = lazyCls.Title;

            var isc = var.IsValueCreated;
            var ob = var.Value;
            isc = var.IsValueCreated;
        }
    }

    public class LazyClass {
        public LazyClass()
        {
            
        }
        private readonly int _code;
        private string _title;
        public LazyClass(int code, string title) {
            _code = code;
            _title = title;
        }
        public int Code { get { return _code; } }
        public string Title { get { return _title; } set { _title = value; } }
    }
}
