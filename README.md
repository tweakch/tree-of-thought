# tree-of-thought

Problem solving

> dotnet run

> dotnet run -- --problem "Test"

> dotnet run -- --problem "Test" --tree-of-thought

## DevLog

### 02.11.2023

In der .NET-Umgebung gibt es verschiedene Speicherbereiche, in denen Daten gespeichert werden können. Hier ist eine detailliertere Erklärung dieser Bereiche:

### Stack

> ÖV zur Rush Hour, Pringles Packung, Kleiderschrank (LIFO)

Der Stack ist ein Speicherbereich, der für die schnelle Speicherung und Entfernung von Daten optimiert ist. Der Stack folgt dem Last-In-First-Out (LIFO)-Prinzip. Wenn eine Methode aufgerufen wird, wird ein "Stack Frame" für diese Methode erstellt, das alle lokalen Variablen, Parameter und die Rückgabeadresse enthält. Sobald die Methode beendet ist, wird das Stack Frame entfernt (oder "abgebaut"), wodurch der Speicherplatz freigegeben wird. Dies macht den Stack zu einem sehr schnellen, aber beschränkten Speicherbereich.

**Typische Elemente im Stack:**

- Lokale Variablen
- Werttypen
- Referenzen zu Heap-Objekten
- Methode Parameter
- Rückgabewerte

### Heap

> Automatisches Lagerhaus (Managed Heap) mit Lagermitarbeiter (Garbage Collection)

Im Gegensatz zum Stack ist der Heap ein Speicherbereich, der für die langfristige Speicherung von Daten verwendet wird. Der Heap ist flexibler, aber in der Regel langsamer als der Stack. Hier werden Instanzen von Klassen (Referenztypen) gespeichert. Der Heap wird von einem Prozess namens "Garbage Collection" verwaltet, der nicht verwendete Objekte entfernt, um Speicherplatz freizugeben.

**Typische Elemente im Heap:**

- Objekte (Instanzen von Klassen)
- Mitglieder von Objekten
- `static` Variablen

### Code-Segment

Dies ist der Speicherbereich, in dem der ausführbare Code der Anwendung gespeichert ist. Konstanten (`const`) werden oft direkt in diesem Bereich eingebettet. Das heisst, sie existieren als Teil des Codes und nehmen keinen eigenen Speicherplatz im Stack oder Heap ein.

### High-Frequency Heap

Dies ist ein spezieller Bereich des Heaps, der für `static` Variablen reserviert ist. Diese Variablen haben eine Lebensdauer, die an die Laufzeit der Anwendung (oder genauer gesagt, an die Lebensdauer der AppDomain) gebunden ist. 

### Codebeispiel

```csharp
using System;

public struct MyStruct  // Werttyp
{
    public int Value;
}

public class MyClass // Referenztyp
{
    public int Value;
}

public class Program
{
    // Statische Variable (speziell auf dem Heap)
    public static int MyStaticVariable = 10;

    // Konstante (im Code eingebettet)
    public const int MyConstant = 42;

    // Instanzvariable (auf dem Heap)
    public int MyInstanceVariable = 5;

    static void Main(string[] args)
    {
        // Lokale Variable (value type auf dem Stack)
        int localValue = 100;

        // Lokale Variable (Referenztyp, Referenz auf dem Stack, Objekt auf dem Heap)
        MyClass localClass = new MyClass();

        // Nutzung einer statischen Variable
        Console.WriteLine("Statische Variable: " + MyStaticVariable);

        // Nutzung einer Konstanten
        Console.WriteLine("Konstante: " + MyConstant);

        // Erzeugung einer Instanz und Zugriff auf eine Instanzvariable
        Program program = new Program();
        Console.WriteLine("Instanzvariable: " + program.MyInstanceVariable);

        // Nutzung von lokalen Variablen
        Console.WriteLine("local value type: " + localValue);
        localClass.Value = 200;
        Console.WriteLine("local reference type: " + localClass.Value);

        // Nutzung von Werttypen
        MyStruct myStruct = new MyStruct();
        myStruct.Value = 300;
        Console.WriteLine("value type: " + myStruct.Value);

        // Nutzung von Referenztypen
        MyClass myClass = new MyClass();
        myClass.Value = 400;
        Console.WriteLine("Referenztyp-Variable: " + myClass.Value);
    }
}
```

Ich habe dir hier noch ein Beispiel-Code. Folgende "Elemente" werden darin verwendet:

- `MyStaticVariable` ist eine statische Variable, die im speziellen Bereich des Heaps gespeichert wird.
- `MyConstant` ist eine Konstante, deren Wert direkt im Code eingebettet wird.
- `MyInstanceVariable` ist eine Instanzvariable, die auf dem Heap gespeichert wird.
- `localValue` ist eine lokale Variable vom Werttyp, die auf dem Stack gespeichert wird.
- `localClass` ist eine lokale Variable vom Referenztyp, wobei die Referenz auf dem Stack und das Objekt auf dem Heap gespeichert wird.
- `myStruct` ist eine Variable vom Werttyp, die auf dem Stack gespeichert wird.
- `myClass` ist eine Variable vom Referenztyp, wobei die Referenz auf dem Stack und das Objekt auf dem Heap gespeichert wird.

Als Tabelle

| Beispiel             | Elementtyp                    | Speicherort                         | Lebensdauer                                                   |
| -------------------- | ----------------------------- | ----------------------------------- | ------------------------------------------------------------- |
| `MyStaticVariable`   | Statische Variable            | Spezieller Bereich des Heaps        | Während der gesamten Laufzeit des Programms                   |
| `MyConstant`         | Konstante                     | Direkt im Code                      | Während der gesamten Laufzeit des Programms                   |
| `MyInstanceVariable` | Instanzvariable               | Heap                                | Solange die Instanz existiert                                 |
| `localValue`         | Lokale Variable (Werttyp)     | Stack                               | Solange die Methode ausgeführt wird, in der sie definiert ist |
| `localClass`         | Lokale Variable (Referenztyp) | Referenz auf Stack, Objekt auf Heap | Solange die Methode ausgeführt wird, in der sie definiert ist |
| `myStruct`           | Variable (Werttyp)            | Stack                               | Solange die Methode ausgeführt wird, in der sie definiert ist |
| `myClass`            | Variable (Referenztyp)        | Referenz auf Stack, Objekt auf Heap | Solange die Methode ausgeführt wird, in der sie definiert ist |

> **Wichtig**: Entscheidungen über den Speicherort von Elementen werden schlussendlich von der .NET Runtime und dem Just-In-Time-Compiler (JIT) getroffen. Diese Entscheidungen können von vielen Faktoren abhängen, einschliesslich Leistungsoptimierungen, daher ist diese Übersicht eine Vereinfachung.

### Weiterführende Infos

[Memory Usage Inside the CLR](https://mattwarren.org/2017/07/10/Memory-Usage-Inside-the-CLR/#:~:text=MANAGED%20DEBUGGING%20with%20WINDBG,explain%20me%20the%20CLR%E2%80%99s%20%E2%80%9CHighFrequencyHeap%E2%80%9D)



### 26.10.2023

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

