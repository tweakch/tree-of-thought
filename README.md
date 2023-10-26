# tree-of-thought

Problem solving

> dotnet run

> dotnet run -- --problem "Test"

> dotnet run -- --problem "Test" --tree-of-thought

## DevLog

```cs
/*

public        <v                  protected - v                        private  .           

interface 
abstract
methode nützlich für andere

     class ArgumentProcessor 
> 
 |                              
 |   statisch => 1x pro Programm                       
 |   Process                     
 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
 |                       
 |   dynamisch => 1x pro Instanz                                     
 |                                                                      _handlers                  
 |                       
 -----------------------
*/

using System.Runtime.Intrinsics.Arm;

abstract class Vehicle
{
    public static readonly int InstanceCount = 0;
    public const int WHEELS_NUMBER = 4;

    Vehicle(){
        InstanceCount++;
    }

    ~Vehicle(){
        InstanceCount--;
    }
}

// zur compilezeit "eingebunden"
//=> compile: Sha256(const wheels = 0)=> 0x1234567890abcdef
//=> compile: Sha256(const wheels = 1)=> 0xfedcba0987654321

// zur laufzeit "initialisiert"
//=> compile: Sha256(static wheels = 1)=> 0xabcdef1234567890
//=> compile: Sha256(static wheels = 0)=> 0xabcdef1234567890

class Bike : Vehicle{
}

class Car : Vehicle{
}

class Program
{
    static void Main(string[] args)
    {   
        Bike mountainBike = new Bike();
        mountainBike.Wheels = 2;

        Bike longTandem = new Bike();
        longTandem.Wheels = 3;

        Car audi = new Car();

        Console.WriteLine("Hello World!");
        Console.WriteLine(mountainBike.Wheels);
        Console.WriteLine(longTandem.Wheels);
        Console.WriteLine(audi.Wheels);
    }
}
```

