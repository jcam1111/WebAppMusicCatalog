using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMusicCatalog.Models
{
    public partial class Canciones
    {
        [Key]
        public int cancion_id { get; set; }
        [DisplayName("Titulo")]
        [StringLength(100, ErrorMessage = "El titulo no puede exceder los 100 caracteres.")]
        public string titulo { get; set; }
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm:ss}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "HH:mm:ss", ApplyFormatInEditMode = true)]    
        [DisplayName("Duracion")]           
        public Nullable<System.TimeSpan> duracion { get; set; }
        [DisplayName("Artista")]
        public Nullable<int> artista_id { get; set; }
        [DisplayName("Genero")]
        public Nullable<int> genero_id { get; set; }
        [DisplayName("Album")]
        [StringLength(100, ErrorMessage = "El album no puede exceder los 100 caracteres.")]
        public string album { get; set; }
        [DisplayName("Año lanzamiento")]
        public Nullable<short> anio_lanzamiento { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Letra")]
        public string letra { get; set; }
        [Range(1, 5,
       ErrorMessage = "Calificacion {0} debe estar entre {1} y {2}.")]
        public Nullable<double> calificacion { get; set; }
        [DisplayName("Ruta archivo")]
        public string ruta_archivo { get; set; }
        [DisplayName("Subtitulo")]
        [StringLength(100, ErrorMessage = "El subtitulo no puede exceder los 100 caracteres.")]
        public string subtitulo { get; set; }
        [Range(1, 20,
        ErrorMessage = "Numero de pista {0} debe estar entre {1} y {2}.")]
        public Nullable<short> numero_pista { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }

        public virtual Artistas Artistas { get; set; }
        public virtual Generos Generos { get; set; }
    }
}