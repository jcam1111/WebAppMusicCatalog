using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppMusicCatalog.Models
{
    public partial class Generos
    {
        
        public Generos()
        {
            this.Canciones = new HashSet<Canciones>();
        }

        public int genero_id { get; set; }
        [DisplayName("Nombre genero")]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> origen_pais_id { get; set; }
        public Nullable<double> popularidad { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }

        
        public virtual ICollection<Canciones> Canciones { get; set; }
        public virtual Paises Paises { get; set; }
    }
}