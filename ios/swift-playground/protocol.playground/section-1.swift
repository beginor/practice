// Playground - noun: a place where people can play

import UIKit

protocol SomeProtocol {
    var mustBeSettable: Int { get set }
    var doesNotNeedToBeSettable: Int { get }
    
    class var someTypeProperty: Int { get set }
}

protocol FullyNamed {
    var fullName: String { get }
}

struct Person : FullyNamed {
    var fullName: String;
}
let john = Person(fullName: "John Appleseed");

class StarShip : FullyNamed {
    var prefix: String?
    var name: String;
    init(name: String, prefix: String? = nil) {
        self.name = name;
        self.prefix = prefix;
    }
    var fullName: String {
        return (prefix != nil ? prefix! + " " : " ") + name;
    }
}
var ncc1701 = StarShip(name: "Enterprise", prefix: "USS");
ncc1701.fullName;

protocol RandomNumberGenerator {
    func random() -> Double
}

class LinearCongruentialGenerator : RandomNumberGenerator {
    var lastRandom = 42.0;
    let m = 139968.0;
    let a = 3877.0;
    let c = 29573.0;
    func random() -> Double {
        lastRandom = ((lastRandom * a + c) % m);
        return lastRandom / m;
    }
}

let generator = LinearCongruentialGenerator();
generator.random();
generator.random();

protocol Togglable {
    mutating func toggle()
}

enum OnOffSwitch : Togglable {
    case Off, On;
    mutating func toggle() {
        switch self {
        case Off:
            self = On;
        case On:
            self = Off;
        }
    }
}

var s = OnOffSwitch.Off;
s.toggle();

class Dice {
    let sides: Int;
    let generator: RandomNumberGenerator;
    init(sides: Int, generator: RandomNumberGenerator) {
        self.sides = sides;
        self.generator = generator;
    }
    func roll() -> Int {
        return Int(generator.random() * Double(sides)) + 1;
    }
}

let dice = Dice(sides: 6, generator: LinearCongruentialGenerator());
for _ in 1...5 {
    println("Random dice roll is \(dice.roll())");
}

protocol DiceGame {
    var dice: Dice { get }
    func play()
}

protocol DiceGameDelegate {
    func gameDidStart(game: DiceGame)
    func game(game: DiceGame, didStartNewTurnWithDiceRoll diceRoll:Int)
    func gameDidEnd(game: DiceGame)
}

class SnakesAndLadders : DiceGame {
    
    let finalSquare = 25;
    let dice = Dice(sides: 6, generator: LinearCongruentialGenerator());
    var square = 0;
    var board: [Int];
    var delegate: DiceGameDelegate?;
    
    init() {
        board = [Int](count: finalSquare + 1, repeatedValue: 0);
        board[03] = +08; board[06] = +11; board[09] = +09; board[10] = +02
        board[14] = -10; board[19] = -11; board[22] = -02; board[24] = -08
    }
    
    func play() {
        square = 0;
        delegate?.gameDidStart(self);
        gameLoop: while square != finalSquare {
            let diceRoll = dice.roll();
            delegate?.game(self, didStartNewTurnWithDiceRoll: diceRoll);
            switch square + diceRoll {
            case finalSquare:
                break gameLoop;
            case let newSquare where newSquare > finalSquare:
                continue gameLoop;
            default:
                square += diceRoll;
                square += board[square];
            }
        }
        delegate?.gameDidEnd(self);
    }
}

class DiceGameTracker: DiceGameDelegate {
    var numberOfTurns = 0
    func gameDidStart(game: DiceGame) {
        numberOfTurns = 0
        if game is SnakesAndLadders {
            println("Started a new game of Snakes and Ladders")
        }
        println("The game is using a \(game.dice.sides)-sided dice")
    }
    func game(game: DiceGame, didStartNewTurnWithDiceRoll diceRoll: Int) {
        ++numberOfTurns
        println("Rolled a \(diceRoll)")
    }
    func gameDidEnd(game: DiceGame) {
        println("The game lasted for \(numberOfTurns) turns")
    }
}

let tracker = DiceGameTracker();
let game = SnakesAndLadders();
game.delegate = tracker;
game.play();
