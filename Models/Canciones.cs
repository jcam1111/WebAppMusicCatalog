//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppMusicCatalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Canciones
    {
        public int cancion_id { get; set; }
        [Display(Name = "Titulo", Prompt = "Ingresar titulo", Description = "Titulo Cancion")]
        public string titulo { get; set; } [Required(ErrorMessage = "Please type your name")]
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "23:59")]
        [Display(Name = "Duracion", Prompt = "Ingresar duracion", Description = "Duracion Cancion")]
        public Nullable<System.TimeSpan> duracion { get; set; }
        public Nullable<int> artista_id { get; set; }
        public Nullable<int> genero_id { get; set; }
        [Display(Name = "Album", Prompt = "Ingresar album", Description = "Album cancion")]
        [StringLength(100, ErrorMessage = "Solo se permiten hasta 100 caracteres")]
        public string album { get; set; }
        [Display(Name = "Anio lanzamiento", Prompt = "Ingresar anio lanzamiento", Description = "Anio lanzamiento cancion")]
        public Nullable<short> anio_lanzamiento { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Letra es requerido")]
        [Display(Name = "Letra", Prompt = "Ingresar letra", Description = "Letra cancion")]
        public string letra { get; set; }
        [Range(1, 5,ErrorMessage ="Solo se permiten valores entre 1 y 5")]
        [Required(ErrorMessage = "Calificacion es requerido")]
        [Display(Name = "Calificacion", Prompt = "Ingresar calificacion", Description = "Calificacion cancion")]
        public Nullable<double> calificacion { get; set; }
        public string ruta_archivo { get; set; }
        [Display(Name = "Subtitulo", Prompt = "Ingresar subtitulo", Description = "Subtitulo cancion")]
        public string subtitulo { get; set; }
        
        [Display(Name = "Numero pista", Prompt = "Ingresar numero pista", Description = "Numero pista cancion")]
        //[Integer(ErrorMessage = "This is needs to be integer")]
        [Range(1, 20, ErrorMessage = "Solo se permite el ingreso entre 1 y 20")]
        [Required(ErrorMessage = "Numero pista es requerido")]
        public Nullable<short> numero_pista { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
    
        public virtual Artistas Artistas { get; set; }
        public virtual Generos Generos { get; set; }
    }
}
