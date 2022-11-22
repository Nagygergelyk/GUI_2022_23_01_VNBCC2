using GUI_2022_23_01_VNBCC2.Logic;
using GUI_2022_23_01_VNBCC2.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_2022_23_01_VNBCC2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IMenuLogic, MenuLogic>()
                    .AddSingleton<INewGameWindowService, NewGameViaWindow>()
                    .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                    .BuildServiceProvider()
            );
        } 
    }
}
