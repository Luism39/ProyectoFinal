//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final.Views
{
    using System;
    using System.Collections.Generic;
    
    public partial class Permisos
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public System.DateTime Desde { get; set; }
        public System.DateTime Hasta { get; set; }
        public string Comentarios { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Empleados Empleados1 { get; set; }
    }
}
