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
        [Required(ErrorMessage = "El titulo es obligatorio.")]
        public string titulo { get; set; }
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm:ss}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "HH:mm:ss", ApplyFormatInEditMode = true)]
        // [Required(ErrorMessage = "El tiempo es requerido.")]
        [RegularExpression(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "El formato debe ser HH:mm:ss.")]
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
        [Range(1960, 2024,
       ErrorMessage = "Año lanzamiento {0} debe estar entre {1} y {2}.")]
        public Nullable<short> anio_lanzamiento { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Letra")]
        public string letra { get; set; }
        [DisplayName("Calificacion")]
        [Range(1, 5,
       ErrorMessage = "Calificacion {0} debe estar entre {1} y {2}.")]
        public Nullable<double> calificacion { get; set; }
        [DisplayName("Ruta archivo")]
        public string ruta_archivo { get; set; }
        [DisplayName("Subtitulo")]
        [StringLength(100, ErrorMessage = "El subtitulo no puede exceder los 100 caracteres.")]
        public string subtitulo { get; set; }
        [DisplayName("Numero de pista")]
        [Range(1, 20,
        ErrorMessage = "Numero de pista {0} debe estar entre {1} y {2}.")]
        public Nullable<short> numero_pista { get; set; }
        [DisplayName("Fecha creacion")]
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        [DisplayName("Fecha modificacion")]
        public Nullable<System.DateTime> fecha_modificacion { get; set; }

        [DisplayName("Artista")]
        public virtual Artistas Artistas { get; set; }
        public virtual Generos Generos { get; set; }
    }
}