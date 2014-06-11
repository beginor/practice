using System.Collections.Generic;

namespace CandySearch {

    public class Candy {

        public string Category { get; set; }

        public string Name { get; set; }

        public Candy(string category, string name) {
            Category = category;
            Name = name;
        }

        public static IList<Candy> DefaultList() {
            return new List<Candy> {
                new Candy("chocolate", "chocolate bar"),
                new Candy("chocolate", "chocolate chip"),
                new Candy("chocolate", "dark chocolate"),
                new Candy("hard", "lollipop"),
                new Candy("hard", "candy cane"),
                new Candy("hard", "jaw breaker"),
                new Candy("other", "caramel"),
                new Candy("other", "sour chew"),
                new Candy("other", "peanut butter cup"),
                new Candy("other", "gummi bear")
            };
        }

    }

}

