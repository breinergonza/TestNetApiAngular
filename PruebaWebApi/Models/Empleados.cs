//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleados
    {
        public Empleados()
        {
            this.EmpleadosEntidad = new HashSet<EmpleadosEntidad>();
        }
    
        public int id { get; set; }
        public int tipoIdetificacionId { get; set; }
        public int numeroIdentificacion { get; set; }
        public string nombre { get; set; }
    
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual ICollection<EmpleadosEntidad> EmpleadosEntidad { get; set; }
    }
}
