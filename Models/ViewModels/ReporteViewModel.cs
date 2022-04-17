using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHenryTenorio.Models.ViewModels
{
    public class ReporteViewModel
    {
        public int PacienteID { set; get; } 
        public string NombrePaciente { set; get; }
        public string Telefono { set; get; }
        public string Medicina { set; get; }
        public DateTime FechaIni { set; get; }
        public DateTime? FechaFin { set; get; }
    }
}