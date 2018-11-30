using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.Models
{
    using SQLite;

    public class PerfilLocal : BaseDataModel
    {
        /*[PrimaryKey]
        public int PerfilId { get; set; }*/

        public string Titular { get; set; }

        public string Telefono { get; set; }

        public string NumPoliza { get; set; }

        public string TitularHogar { get; set; }

        public string TelefonoHogar { get; set; }

        public string NumPolizaHogar { get; set; }

        public string Placa { get; set; }

        public string Chasis { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string NoCasa { get; set; }
        public string Apartamento { get; set; }



        public override int GetHashCode()
        {
            return PerfilId;
        }
    }

}
