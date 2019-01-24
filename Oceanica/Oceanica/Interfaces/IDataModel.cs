using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.Interfaces
{
    using SQLite;
    public  interface IDataModel
    {
        [PrimaryKey]
        int PerfilId { get; set; }
    }
}
