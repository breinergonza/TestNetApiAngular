using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaWebApi.Models.DTO
{
    public class EmpleadosDto
    {
        public int id { get; set; }
        public int tipoIdetificacionId { get; set; }
        public int numeroIdentificacion { get; set; }
        public string nombre { get; set; }
    }
}