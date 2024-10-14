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
    
    public partial class Canciones
    {
        public int cancion_id { get; set; }
        public string titulo { get; set; }
        public Nullable<System.TimeSpan> duracion { get; set; }
        public Nullable<int> artista_id { get; set; }
        public Nullable<int> genero_id { get; set; }
        public string album { get; set; }
        public Nullable<short> anio_lanzamiento { get; set; }
        public string letra { get; set; }
        public Nullable<double> calificacion { get; set; }
        public string ruta_archivo { get; set; }
        public string subtitulo { get; set; }
        public Nullable<short> numero_pista { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
    
        public virtual Artistas Artistas { get; set; }
        public virtual Generos Generos { get; set; }
    }
}
