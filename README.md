# 2-Day Virtual Seminar: Asynchronous and Parallel Programming in C#
*Level: Intermediate*

More information and registration link:  
[Asynchronous and Parallel Programming in C#](https://vslive.com/events/training-seminars/2025/june24/home.aspx)

Asynchronous programming is a critical skill in C#, especially since so many of the built-in libraries are asynchronous -- including interactions with services and databases. On the server, asynchronous code can keep our servers free to handle more requests. In the desktop and mobile worlds, asynchronous code can keep the UI responsive. A subset of asynchronous programming is parallel programming. With parallel programming, you can run multiple operations at the same time -- speeding up processes and using resources more effectively. The ultimate goal is to give the best experience to your users.  

But there are also pitfalls. If you do not handle asynchronous code correctly, you can create blocking operations that result in deadlocks, causing an application to hang indefinitely. You can also lose visibility to errors or cause performance issues. These are all things best avoided.  

In this 2-day virtual seminar, you will get a deeper understanding of asynchronous and parallel programming, learn how to get those positive results, and see techniques to avoid the pitfalls. In addition to lectures with lots of sample code, you'll go hands-on with labs designed to make you comfortable with the topics.  

Here are the main topics we'll cover:  
* Calling asynchronous methods that return a Task.  
* Using continuations to wait for a Task to complete and get the results.  
* Using "await" to wait for a Task to complete and get the results.  
* Dealing with exceptions.  
* Canceling an asynchronous process.  
* Getting progress reports from a long-running asynchronous process.  
* Working with asynchronous methods in desktop applications and MVC controllers.  
* Writing your own asynchronous methods.  
* Handling cancellation requests in those methods.  
* Running code in parallel using Tasks, Channels, and Parallel.ForEachAsync.  
* Dealing with exceptions in parallel code.  

Along the way, you'll also learn:  
* Differences between .NET Framework 4.8 and .NET 8/9.  
* Where (and why) to use ConfigureAwait(false).  
* Limit what runs with TaskContinuationOptions.  
* Get the real exceptions from an AggregateException.  
* Use Task properties such as IsFaulted and IsCanceled for flow control.  
* When to use Task vs. ValueTask.  

The real world is not always ideal. When you add asynchronous code to an existing application, sometimes you need to break asynchrony. Some common practices are to use Task.Result, GetAwaiter().GetResult(), Wait() or WaitAll(), or the JoinableTaskFactory. Although none of these is ideal, you will see the various downsides (some worse than others) so you can select a workable solution for your project.  

At the end of the workshop, you will have a good understanding of asynchronous programming and can start using it more effectively in your own projects.  

## Pre-requisites  
You will need a basic understanding of C# and object-oriented programming (classes, inheritance, methods, and properties). No prior experience with asynchronous programming is necessary; we'll take care of that as we go.  

Attendee Workstation Requirements:  
You must provide your own computer (Windows or Mac) for this hands-on lab workshop with a camera, wired Internet connection, speakers, and a microphone with the following technologies installed:  

* You need to have the .NET 8 or .NET 9 SDK installed as well as the code editor of your choice (Visual Studio 2022 Community Edition or Visual Studio Code are both good (free) choices).  
* Interactive labs, web application samples, and console samples will work with Windows, macOS, and Linux (anywhere .NET 8/9 will run).  
* WPF desktop samples will only work on Windows machines. There are equivalent web and console examples for these projects.  

**Links**  

* .NET 9.0 SDK  
[https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)

* Visual Studio 2022 (Community)  
[https://visualstudio.microsoft.com/downloads/](https://visualstudio.microsoft.com/downloads/)
Note: Install the "ASP.NET and web development" workload for the labs and samples. Include ".NET desktop development" for "digit-display" sample and WPF-based samples.

* Visual Studio Code  
[https://code.visualstudio.com/download](https://code.visualstudio.com/download)

## Running the Samples

The sample code use .NET 8 or .NET 9. The console and web samples will run on all Window, macOS, and Linux versions that support .NET. The desktop samples are Windows-only. (Note: there is also a limited set of .NET Framework samples when there are relevant differences.)  

Samples have been tested with Visual Studio 2022 and Visual Studio Code.

All samples require the "Person.Service" web service be running. To start the service, navigate to the "Person.Service" folder from the command line and type "dotnet run".

```
C:\async-virtual-seminar\People.Service> dotnet run
```  

The service can be found at [http://localhost:9874/people](http://localhost:9874/people)

## Project Layout

The "DemoCode" folder contains the code samples used in the workshop.  
**Shared Projects**  
* *People.Service*  
A web service that supplies data for the sample projects.  
* *TaskAwait.Shared*  
A library with data types that are shared across projects (primarily the "Person" type).  
* *TaskAwait.Library*  
A library with asynchronous methods that access the web service. These methods are called in the various applications detailed below.  
Relevant file: **PersonReader.cs**

**Concurrent Samples**  
The Concurrent samples run asynchronous methods, get results, handle exceptions, and support cancellation (unless otherwise noted).
* *Concurrent.UI.Console*  
A console application  (Windows, macOS, Linux)  
Relevant file: **Program.cs**
* *Concurrent.UI.Desktop*  
A WPF desktop application (Windows only).  
Relevant file: **MainWindow.xaml.cs**  
* *Concurrent.UI. Web*  
A web application (Windows, macOS, Linux).  
Relevant file: **Controllers/PeopleController.cs**  

**Parallel Samples**  
The Parallel samples use Task to run asynchronous methods in parallel - also get results, handle exceptions, and support cancellation (unless otherwise noted).
* *Parallel.Basic*  
A console application that does not support cancellation or error handling (Windows, macOS, Linux).  
Relevant file: **Program.cs**
* *Parallel.Basic.WithExceptions*  
A console application (same as above) with specific code for error handling (Windows, macOS, Linux).  
Relevant file: **Program.cs**
* *Parallel.UI.Console*  
A console application (Windows, macOS, Linux).  
Relevant file: **Program.cs**
* *Parallel.UI.Desktop*  
A WPF desktop application (Windows only).  
Relevant file: **MainWindow.xaml.cs**  
* *Parallel.UI. Web*  
A web application (Windows, macOS, Linux).  
Note: this application does not support cancellation.  
Relevant file: **Controllers/PeopleController.cs**  

**Progress Reporting**  
The Progress Reporting samples show how to report progress from an asynchronous method - in this case, as a percentage complete and optional message. These also get results, handle exceptions, and support cancellation.
* *ProgressReport.UI.Console*  
A console application that reports percentage complete progress through text. Ex: "21% Complete" (Windows, macOS, Linux).  
Relevant file: **Program.cs**
* *Parallel.UI.Desktop*  
A WPF desktop application that  reports percentage complete progress through a graphical progress bar (Windows only).  
Relevant file: **MainWindow.xaml.cs**  
* *TaskAwait.Library*  
This shared library contains a method that supports progress reporting.  
Relevant methods:
```c#
public async Task<List<Person>> GetPeopleAsync(IProgress<int> progress,
    CancellationToken cancelToken = new CancellationToken()) {...}

public async Task<List<Person>> GetPeopleAsync(IProgress<(int, string)> progress,
    CancellationToken cancelToken = new CancellationToken()) {...}

public async IAsyncEnumerable<List<Person>> GetPeopleAsyncEnumerable(IProgress<int> progress,
    [EnumeratorCancellation] CancellationToken cancelToken = new CancellationToken()) {...}
```

**Breaking Async**  
The Breaking Async samples show how to call asynchronous code from methods that cannot be asynchronous themselves (recommendation is to use JoinableTaskFactory). There is also a static factory method example as an option when you need to run async code inside an object constructor.  
* *NoAsync.UI.Desktop*  
A WPF application that shows when the library options are blocking and deadlocking (Windows).  
Relevant file: **MainWindow.xaml.cs**  
* *NoAsync.Library*  
A library with code that needs to bread async.  
Relevant file: **APIReader.cs** - call async from inside a non-async method.  
Relevant file: **AsyncConstructorReader.cs** - static factory method for async creation.


Hands-On Labs  
--------------
The "Labs" folder contains hands-on labs. The labs are integrated throughout the seminar.    

* [Lab 01 - Recommended Practices and Continuations](Labs/Lab01/)
* [Lab 02 - Adding Async to an Existing Application](Labs/Lab02/)
* [Lab 03 - Adding Progress Reporting to an Application](Labs/Lab03/)  
* [Lab 04 - Parallel Practices](Labs/Lab04/)
* [Lab 05 - Working with Exceptions in Parallel Loops](Labs/Lab05/)
* [Lab BONUS - Working with AggregateException](Labs/LabBONUS-AggregateException/)
* [Lab BONUS - Unit Testing Asynchronous Methods](Labs/LabBONUS-UnitTesting/)

Each lab consists of the following:

* **Labxx-Instructions** (Markdown / PDF)  
A markdown file containing the lab instructions. This includes the scenario, a set of goals, and step-by-step instructions. This can be viewed on GitHub or in Visual Studio Code (just click the "Open Preview to the Side" button in the upper right corner).  
*Note: A PDF version is also available.*  

* **Starter** (Folder)  
This folder contains the starting code for the lab.

* **Completed** (Folder)  
This folder contains the completed solution. If at any time, you get stuck during the lab, you can check this folder for a solution.

Additional Resources
--------------------
**Related Articles (by Jeremy)**
* Why Do You Have to Return "Task" Whenever You "await" Something in a Method in C#?  
  [Article](https://jeremybytes.blogspot.com/2023/08/why-do-you-have-to-return-task-whenever.html)  
  [Video](https://www.youtube.com/watch?v=3kuwLDibFDE)
* [Don't Use "Task.WhenAll" for Interdependent Tasks](https://jeremybytes.blogspot.com/2023/10/dont-use-taskwhenall-for-interdependent.html)  
* [Looking at Producer/Consumer Dependencies: Bounded vs. Unbounded Channels](https://jeremybytes.blogspot.com/2023/10/looking-at-producerconsumer.html)  
* [Producer/Consumer Exception Handling - A More Reliable Approach](https://jeremybytes.blogspot.com/2023/10/producerconsumer-exception-handling.html)  
* ["await.WhenAll" Shows 1 Exception - Here's How to See Them All](https://jeremybytes.blogspot.com/2020/09/await-taskwhenall-shows-one-exception.html)

**Articles & Videos (by Jeremy)**  
Each of these has a lot of supporting links:  
* [I'll Get Back to You: Task, Await, and Asynchronous Programming in C#](http://www.jeremybytes.com/Demos.aspx#TaskAndAwait) (Includes progress reporting)  
* [Run Faster: Parallel Programming in C#](http://www.jeremybytes.com/Demos.aspx#ParallelProgramming)  
* [Learn to Love Lambdas in C# (and LINQ, Too!)](http://www.jeremybytes.com/Demos.aspx#LLL)  
* [Get Func-y: Delegates in .NET](http://www.jeremybytes.com/Demos.aspx#GF)  

**BackgroundWorker Component**  
* [BackgroundWorker Component and .NET 6](https://github.com/jeremybytes/backgroundworker-dotnet6)  
* [BackgroundWorker Component - "I'm not Dead, Yet!"](https://jeremybytes.blogspot.com/2012/05/backgroundworker-component-im-not-dead.html)  
* [Keep Your UI Responsive with the BackgroundWorker Component](http://www.jeremybytes.com/Demos.aspx#KYUIR)  

**Other Resources**  

David Fowler  
* [ASP.NET Core Diagnostic Scenarios / Async Guidance](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md)  
Note: This guidance is targeted toward ASP.NET Core, although the guidance applies to most other enivronments.  

Stephen Cleary has lots of great articles, books, and practical advice.
* .NET 8 - [ConfigureAwait in .NET 8](https://blog.stephencleary.com/2023/11/configureawait-in-net-8.html) - Stephen Cleary
* [Don't Block on Async Code](https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html) - Stephen Cleary
* [Async/Await - Best Practices in Asynchronous Programming](https://docs.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming) - Stephen Cleary  
* [ASP.NET Core SynchronizationContext](https://blog.stephencleary.com/2017/03/aspnetcore-synchronization-context.html) - Stephen Cleary  
* [There Is No Thread](https://blog.stephencleary.com/2013/11/there-is-no-thread.html) - Stephen Cleary  

Stephen Toub has great articles, too (generally with advanced insights).
* [Do I Need to Dispose of Tasks?](https://devblogs.microsoft.com/pfxteam/do-i-need-to-dispose-of-tasks/) - Stephen Toub  
* [Understanding the Whys, Whats, and Whens of ValueTask](https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/) - Stephen Toub  
* [ConfigureAwait FAQ](https://devblogs.microsoft.com/dotnet/configureawait-faq/) - Stephen Toub  

For more information, visit [jeremybytes.com](http://www.jeremybytes.com).  

---
