// Playground - noun: a place where people can play

func swapTwoValues<T>(inout a: T, inout b: T) {
    let tmp = a;
    a = b;
    b = tmp;
}

var someInt = 3;
var anotherInt = 107;
swapTwoValues(&someInt, &anotherInt);

var someString = "hello";
var anotherString = "world";
swapTwoValues(&someString, &anotherString);

struct Stack<T> {
    
    var items = [T]();
    
    mutating func push(item: T) {
        items.append(item);
    }
    
    mutating func pop() -> T {
        return items.removeLast();
    }
    
}

var stackOfString = Stack<String>();
stackOfString.push("uno");

func findIndex<T: Equatable>(array: [T], valueToFind: T) -> Int? {
    for (index, value) in enumerate(array) {
        if value == valueToFind {
            return index;
        }
    }
    return nil;
}

let doubleIndex = findIndex([3.14159, 0.1, 0.25], 9.3);
let stringIndex = findIndex(["Mike", "Malcolm", "Andrea"], "Andrea");

protocol Container {
    typealias ItemType;
    mutating func append(item: ItemType);
    var count: Int { get }
    subscript(i: Int) -> ItemType { get }
}

extension Array: Container {}

func allItemsMatch<C1: Container, C2: Container
    where C1.ItemType == C2.ItemType, C1.ItemType: Equatable>
    (someContainer:C1, anotherContainer: C2) -> Bool {
        
        if someContainer.count != anotherContainer.count {
            return false;
        }
        
        for i in 0..<someContainer.count {
            if someContainer[i] != anotherContainer[i] {
                return false;
            }
        }
    return true;
}