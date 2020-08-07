using MparWpf.Tests.Sorting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MparWpf.Tests.Sorting.DtaGrid2;
using MparWpf.Tests.Sorting.DtaGrid3;
using Microsoft.Extensions.DependencyInjection;
using MparWpf.Controllers.Context;
using Microsoft.EntityFrameworkCore;


namespace MparWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Private members
        private readonly ServiceProvider serviceProvider;
        #endregion

        #region Constructor
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlite("Data Source = Product.db");
            });
            services.AddSingleton<MainWindow>();
            serviceProvider = services.BuildServiceProvider();
        }
        #endregion
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();


            //MparWpf.Test.MainPage window = new MparWpf.Test.MainPage();
            //MparWpf.Test.UserViewModel VM = new MparWpf.Test.UserViewModel();
            //window.DataContext = VM;
            //window.Show();

            //MparWpf.Tests.Sorting.ListSortExample listSortExample = new ListSortExample();
            //listSortExample.DataContext = listSortExample;
            //listSortExample.Show();

            //MyGrid3Window myGridWindow = new MyGrid3Window();
            //myGridWindow.Show();

            //MparWpf.Tests.Sorting.DtaGrid4.Window1 myGridWindow = new MparWpf.Tests.Sorting.DtaGrid4.Window1();
            //myGridWindow.Show();

            MparWpf.Tests.Sorting.Screens.Screen1.Window1 window1 = new MparWpf.Tests.Sorting.Screens.Screen1.Window1();
            window1.Show();
        }
    }
}
