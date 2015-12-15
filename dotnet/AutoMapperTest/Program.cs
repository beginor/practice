using System;

namespace AutoMapperTest {

    class A {

        public string A1 {
            get;
            set;
        }

        public string A2 {
            get;
            set;
        }

        public string A3 {
            get;
            set;
        }
    }

    class B {

        public string A1 {
            get;
            set;
        }

        public string A2 {
            get;
            set;
        }
    }

    class MainClass {
        
        public static void Main(string[] args) {
            AutoMapper.Mapper.CreateMap<A, B>();
            AutoMapper.Mapper.CreateMap<B, A>();

            var a = new A { A1 = "A1", A2 = "A2", A3 = "A3" };
            var b = new B { A1 = "B1", A2 = "B2" };

            AutoMapper.Mapper.Map(b, a);

            Console.WriteLine(a.A3);
            Console.ReadLine();
        }
    }
}
