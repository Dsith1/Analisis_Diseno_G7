//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App_Estudios_G7.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.CURSOes = new HashSet<CURSO>();
            this.NOTA_EXAMEN = new HashSet<NOTA_EXAMEN>();
            this.NOTA_TAREA = new HashSet<NOTA_TAREA>();
            this.CURSOes1 = new HashSet<CURSO>();
            this.COMENTARIOs = new HashSet<COMENTARIO>();
        }
    
        public int id_usuario { get; set; }
        public string nick { get; set; }
        public string contra { get; set; }
        public string nombre_1 { get; set; }
        public string nombre_2 { get; set; }
        public string apellido_1 { get; set; }
        public string apellido_2 { get; set; }
        public int edad { get; set; }
        public string correo { get; set; }
        public string rol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CURSO> CURSOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTA_EXAMEN> NOTA_EXAMEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTA_TAREA> NOTA_TAREA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CURSO> CURSOes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMENTARIO> COMENTARIOs { get; set; }
    }
}
