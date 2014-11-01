// Playground - noun: a place where people can play

struct Vector2D {
    
    var x = 0.0, y = 0.0;

}

func + (left: Vector2D, right: Vector2D) -> Vector2D {
    return Vector2D(x: left.x + right.x, y: left.y + right.y);
}

prefix func - (vector: Vector2D) -> Vector2D {
    return Vector2D(x: -vector.x, y: -vector.y);
}

func += (inout left: Vector2D, right: Vector2D) {
    left = left + right;
}

prefix func ++ (inout v: Vector2D) -> Vector2D {
    v += Vector2D(x: 1.0, y: 1.0);
    return v;
}

var a = Vector2D(x: 1, y: 2);
var b = Vector2D(x: 2, y: 1);
let c = a + b;
let d = -c;

a += c;


