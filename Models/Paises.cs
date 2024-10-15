using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppMusicCatalog.Models
{
    public partial class Paises
    {
        
        public Paises()
        {
            this.Artistas = new HashSet<Artistas>();
            this.Generos = new HashSet<Generos>();
        }

        public int pais_id { get; set; }
        [DisplayName("Nombre pais")]
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }

        
        public virtual ICollection<Artistas> Artistas { get; set; }
        
        public virtual ICollection<Generos> Generos { get; set; }
    }
}