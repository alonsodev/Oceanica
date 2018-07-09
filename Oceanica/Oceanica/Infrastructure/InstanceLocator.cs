using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.Infrastructure
{
    using Oceanica.ViewModels;
    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
