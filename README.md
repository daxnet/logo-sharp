# Logo Sharp
Logo programming language for managed world.

[![Build status](https://dev.azure.com/sunnycoding/LogoSharp/_apis/build/status/LogoSharp%20Library%20Build%20Pipeline)](https://dev.azure.com/sunnycoding/LogoSharp/_build/latest?definitionId=6) [![NuGet Badge](https://buildstats.info/nuget/LogoSharp?includePreReleases=true)](https://www.nuget.org/packages/LogoSharp/)

## What's Logo?
Logo is a programming language that controls a turtle on the screen to draw amazing pictures, like below:

![alt text](https://raw.githubusercontent.com/daxnet/logo-sharp/master/assets/logosharp_demo.gif "LogoSharp Quick Demo")

More beautiful pictures drawn by LogoSharp:

- Box Picture
  
  ![alt text](https://raw.githubusercontent.com/daxnet/logo-sharp/master/assets/1.png "LogoSharp Quick Demo")

- Beautiful Flower
  
  ![alt text](https://raw.githubusercontent.com/daxnet/logo-sharp/master/assets/2.png "LogoSharp Quick Demo")

- Square Flower
  
  ![alt text](https://raw.githubusercontent.com/daxnet/logo-sharp/master/assets/4.png "LogoSharp Quick Demo")

- Web
  
    ![alt text](https://raw.githubusercontent.com/daxnet/logo-sharp/master/assets/6.png "LogoSharp Quick Demo")

Logo is widely used in computer education for kids, as it is simple and interesting. LogoSharp is a .NET implementation of the Logo programming language which is based on the Irony parser generator.

## How to use LogoSharp?
It is very simple and straightforward to use LogoSharp in your .NET projects that is either based on .NET Framework 4.6.1 or NetStandard 2.0. This means that you can make your LogoSharp app working with .NET Core and thereby provides the cross-platform capability.

1. Install LogoSharp NuGet Package, for example:
    ``` 
    Install-Package LogoSharp -Version 0.9.20-preview
    ```
2. Write your first app:
   ```csharp
    static void Main(string[] args)
    {
        var logo = new Logo();
        logo.Forward += (s, e)
            => Console.WriteLine($"Forwarded {e.Steps} steps.");
        logo.Execute("FD 102");
    }
   ```
3. Run your app, you should get the message `Forwarded 102 steps.` on your console

Basically, a Logo program code is provided to the `Execute` method of the `logo` instance, LogoSharp will execute the code and emit the events. Therefore, event handlers that subscribe to a particular event will be hit once the execution of the code emits the subscribed event.

For more information about how to use LogoSharp, please refer to the `LogoSharp.Drawing` project.

## Key Features

LogoSharp provides the following commands and features:

- Basic Pen Commands
  - PENDOWN/PD
  - PENUP/PU
  - SETPENCOLOR/SETPC/PC
  - SETPENSIZE
  - PENERASE/PE
  - PENNORMAL/PN
- Basic Drawing Commands
  - LEFT/LT
  - RIGHT/RT
  - FORWARD/FD
  - BACKWARD/BK/BACK
  - DELAY
  - DRAW/CLS/CLEARSCR/CLEARSCREEN/CS
- Turtle Control Commands
  - HOME
  - SHOWTURTLE/ST
  - HIDETURTLE/HT
- Flow Control Commands
  - REPEAT and RepCount
- Language Features
  - Variables (The MAKE command)
  - Expressions
  - Procedures
  - Function Calls
    - SQRT
    - RANDOM
  - Inline Comments

## Limitations

- IF/WHILE statement is not yet supported, will be added soon
- Code editing doesn't support multi-line format
- Logo commands other than the ones listed above are not supported. More will be added in future
- Function calls need to be surrounded by the braces, for example, {SQRT 2} or {RANDOM 100}

## License
MIT
