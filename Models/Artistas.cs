using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMusicCatalog.Models
{
    public  class Artistas
    {
        
        public Artistas()
        {
            this.Canciones = new HashSet<Canciones>();
        }

        [Key]
        public int artista_id { get; set; }
        [DisplayName("Nombre artista")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string nombre { get; set; }
        [DisplayName("Nacionalidad")]        
        public Nullable<int> nacionalidad_pais_id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha nacimiento")]
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        [DisplayName("Genero musical")]
        [StringLength(50, ErrorMessage = "El genero musical no puede exceder los 50 caracteres.")]
        public string genero_musical { get; set; }
        [DisplayName("Biografia")]
        [DataType(DataType.MultilineText)]
        public string biografia { get; set; }
        public byte[] imagen { get; set; }
        [DisplayName("Imagen")]
        public string ruta_archivo_imagen { get; set; }

        [DisplayName("URL sitio web")]
        [DataType(DataType.Url)]
        public string url_sitio_web { get; set; }
        [DisplayName("Fecha creacion")]
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        [DisplayName("Fecha modificacion")]
        public Nullable<System.DateTime> fecha_modificacion { get; set; }

        public virtual Paises Paises { get; set; }
        
        public virtual ICollection<Canciones> Canciones { get; set; }
    }
}