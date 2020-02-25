using App.Data;
using App.Data.Services;
using Autofac;
using System;
using System.Linq;
using WPF.UI.Data;
using WPF.UI.ViewModel;

namespace WPF.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PersonManagerDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<PeopleDataService>().As<IPeopleDataService>();

            return builder.Build();
        }
    }
}
