using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.Models
{
    using Oceanica.Interfaces;
    using SQLite;
    public class BaseDataModel : IDataModel
    {
        [PrimaryKey]
        public virtual int PerfilId { get; set; }
    }
}
