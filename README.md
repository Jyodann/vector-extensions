# Vector Extensions

## Extension functions for Common vector operations

Gives you additional extension functions for Unity's `Vector2`, `Vector2Int`, `Vector3`, `Vector3Int` and `Vector4` so that they read more naturally.

## Installation

To install this package, go to `Window > Package Manager > Click on the '+' Button > Install package from git URL` 
then paste this URL: `https://github.com/Jyodann/vector-extensions.git`

## Usage

For example, to get the Distance between two Vectors:

```csharp
var firstVector = Vector2.zero;
var secondVector = Vector2.one;

// Equivalent to: 
// Vector3.Distance(firstVector, secondVector);
var distance = firstVector.DistanceTo(secondVector);
```

It also has convenience functions for Distance Comparisons: 

```csharp
var firstVector = Vector2.zero;
var secondVector = Vector2.one;

// False
firstVector.IsLongerLengthThan(secondVector);

// True
firstVector.IsShorterLengthThan(secondVector);

// False 
firstVector.IsSameLengthAs(secondVector);

```

As well as introduces a `Direction` function to get the direction vector given two points, it essentially takes `Destination - Origin`

```csharp
var origin = Vector3.zero;
var destination = Vector3.one;

var dir = Vector3Extensions.Direction(origin, destination);
var dir_norm = Vector3Extensions.DirectionNormalized(origin, destination);

origin.DirectionTo(destination);
origin.DirectionNormalizedTo(destination);
```

## Bugs

This package is still being tested, if you come across any bugs, please report them through a Pull Request. Thank you. 

