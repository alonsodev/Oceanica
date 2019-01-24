using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(Oceanica.iOS.Implementations.Config))]
namespace Oceanica.iOS.Implementations
{
    using System;
    using Interfaces;
    using SQLite;

    public class Config : IConfig
    {
        private string directoryDB;
        //private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directoryDB = System.IO.Path.Combine(directory, "..", "Library");
                }

                return directoryDB;
            }
        }

     /*   public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }

                return platform;
            }
        }*/
    }

}