# 2-Day Virtual Seminar: Asynchronous and Parallel Programming in C#
*Level: Intermediate*

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

Pre-requisites:  
You will need a basic understanding of C# and object-oriented programming (classes, inheritance, methods, and properties). No prior experience with asynchronous programming is necessary; we'll take care of that as we go.  

Attendee Workstation Requirements:  
You must provide your own computer (Windows or Mac) for this hands-on lab workshop with a camera, wired Internet connection, speakers, and a microphone with the following technologies installed:  

* You need to have the .NET 8 or .NET 9 SDK installed as well as the code editor of your choice (Visual Studio 2022 Community Edition or Visual Studio Code are both good (free) choices).  
* Interactive labs, web application samples, and console samples will work with Windows, macOS, and Linux (anywhere .NET 8/9 will run).  
* WPF desktop samples will only work on Windows machines. There are equivalent web and console examples for these projects.  

---
