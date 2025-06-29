﻿using Ninject;
using PeopleViewer.Common;
using PersonDataReader.SQL;
using System.Windows;

namespace PeopleViewer.Desktop.Ninject;

public partial class App : Application
{
    IKernel Container = new StandardKernel();

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ConfigureContainer();
        ComposeObjects();
        Application.Current.MainWindow.Title = "With Dependency Injection - Ninject";
        Application.Current.MainWindow.Show();
    }

    private void ConfigureContainer()
    {
        Container.Bind<IPersonReader>().To<SQLReaderProxy>()
            .InSingletonScope()
            .WithConstructorArgument<string>(
                AppDomain.CurrentDomain.BaseDirectory + "People.db");
    }

    private void ComposeObjects()
    {
        Application.Current.MainWindow = Container.Get<PeopleViewerWindow>();
    }
}
