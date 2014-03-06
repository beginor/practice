using System;

namespace TouchTest {

	public abstract class Animal<T> where T : Animal<T> {

		public string Name {
			get;
			set;
		}

		public abstract void MakeFriends(T animal);

	}

	public class Cat : Animal<Cat> {

		public override void MakeFriends(Cat animal) {
			Console.WriteLine("Cat {0} make friends with Cat {1}", this.Name, animal.Name);
		}
	}

	public class Dog : Animal<Cat> {

		public override void MakeFriends(Cat animal) {
			Console.WriteLine("Dot {0} make friends with Cat {1}", this.Name, animal.Name);
		}
	}
}

