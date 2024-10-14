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
    using System.Web.Mvc;

    public partial class Artistas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artistas()
        {
            this.Canciones = new HashSet<Canciones>();
        }
    
        public int artista_id { get; set; }
        [StringLength(100, ErrorMessage = "Solo se permiten hasta 100 caracteres")]
        [Display(Name = "Nombre", Prompt = "Ingresar nombre", Description = "Nombre Artista")]
        public string nombre { get; set; }
        [Display(Name = "Nacionalidad", Prompt = "Ingresar nacionalidad", Description = "Nacionalidad artista")]
        public Nullable<int> nacionalidad_pais_id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha de nacimiento", Prompt = "Ingresar fecha de nacimiento", Description = "Fecha de nacimiento artista")]
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        [Display(Name = "Genero musical", Prompt = "Ingresar genero musical", Description = "Genero musical artista")]
        [StringLength(50, ErrorMessage = "Solo se permiten hasta 50 caracteres")]
        public string genero_musical { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Biografia", Prompt = "Ingresar biografia", Description = "Biografia artista")]
        public string biografia { get; set; }
        public byte[] imagen { get; set; }
        
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Ruta archivo")]
        public string ruta_archivo_imagen { get; set; }
        [Url()]
        [Display(Name = "Sitio Web")]
        public string url_sitio_web { get; set; }

        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Fecha creacion")]  
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        [Display(Name = "Fecha modificacion",AutoGenerateField = false)]        
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
    
        public virtual Paises Paises { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Canciones> Canciones { get; set; }

        public string SearchString { get; set; }
    }
}
