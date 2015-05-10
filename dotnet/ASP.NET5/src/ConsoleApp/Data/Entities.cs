//using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Data {

    public interface IBaseData<TId> where TId : System.IComparable<TId> {

        TId Id { get; set; }

        string Name { get; set; }

    }

    public abstract class BaseData<TId> : IBaseData<TId> where TId : System.IComparable<TId> {

        public virtual TId Id { get; set; }

        //[Required]
        public virtual string Name { get; set; }

    }

    public class BaseInt32Data : BaseData<int> {

        public override int Id {
            get {
                return base.Id;
            }
            set {
                base.Id = value;
            }
        }

    }

    public class BaseStringData : BaseData<string> { }

    public class Category : BaseInt32Data {

        public string Description { get; set; }

    }

    public class Product : BaseInt32Data {

        public Category Category { get; set; }

        public double Price { get; set; }

        public double Discontinued { get; set; }

    }

}