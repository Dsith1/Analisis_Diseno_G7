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
    
    public partial class TAREA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAREA()
        {
            this.NOTA_TAREA = new HashSet<NOTA_TAREA>();
        }
    
        public int id_tarea { get; set; }
        public string Enunciado { get; set; }
        public System.DateTime Entrega { get; set; }
        public int curso { get; set; }
        public Nullable<decimal> ponderacion { get; set; }
    
        public virtual CURSO CURSO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTA_TAREA> NOTA_TAREA { get; set; }
    }
}
