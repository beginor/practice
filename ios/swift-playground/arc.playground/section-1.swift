// Playground - noun: a place where people can play

class Person {

    let name: String
    var apartment: Apartment?
    
    init(name: String) {
        self.name = name
        println("\(name) is being initialized")
    }
    
    deinit {
        println("\(name) is being deinitialized")
    }
    
}

class Apartment {
    
    let number: Int
    weak var tenant: Person?
    
    init(number: Int) {
        self.number = number
    }
    
    deinit {
        println("Apartment #\(number) is being deinitialized")
    }
}

var reference1: Person?
var reference2: Person?
var reference3: Person?

reference1 = Person(name: "John Appleseed")

reference2 = reference1
reference3 = reference1

reference1 = nil
reference2 = nil

reference3 = nil

var john: Person?
var number73: Apartment?

john = Person(name:"John")
number73 = Apartment(number: 73)

john!.apartment = number73
number73!.tenant = john

john = nil
number73 = nil

class Customer {
    
    let name: String
    var card: CreditCard?
    
    init(name: String) {
        self.name = name;
    }
    
    deinit { println("\(name) is being deinitialized.") }
    
}

class CreditCard {
    
    let number: Int
    unowned let customer: Customer
    
    init(number: Int, customer:Customer) {
        self.number = number;
        self.customer = customer
    }
    
    deinit { println("Card #\(number) is being deinitialized") }
    
}

class HTMLElement {
    
    let name:String
    let text:String?
    
    lazy var asHTML: () -> String = {
        [unowned self] in
        if let text = self.text {
            return "<\(self.name)>\(text)</\(self.name)>";
        } else {
            return "<\(self.name) />";
        }
    }
    
    init(name:String, text:String? = nil) {
        self.name = name;
        self.text = text;
    }
    
    deinit {
        println("\(name) is being deinitialized.");
    }
}

var paragraph:HTMLElement? = HTMLElement(name: "p", text: "hello,world");
println(paragraph!.asHTML());

paragraph = nil;
