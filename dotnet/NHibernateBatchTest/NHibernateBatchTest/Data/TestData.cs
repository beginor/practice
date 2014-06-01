using System;

namespace NHibernateBatchTest.Data {

    public class TestData {

        public virtual string Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int Data1 { get; set; }

        public virtual int Data2 { get; set; }

        public virtual double Data3 { get; set; }

        public virtual DateTime UpdateTime { get; set; }

    }
}
