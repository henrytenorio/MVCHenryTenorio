using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHenryTenorio.Models.ViewModels
{
    public class BitacoraViewModel
    {
        
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime? fechaInicio { set; get; } 
        
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        public DateTime? fechaFin { set; get; }
        [Required]
        [Display(Name = "Nombre Tabla")]
        public string tabla { set; get; }
        [Display(Name = "Nombre Usuario")]
        public string usuario { set; get; }
        [Display(Name = "Operacion en BDD")]
        public string operacion { set; get; }
        public string detalle { set; get; }
        public List<BitacoraViewModel> detalleBitacora { set; get; }
    }
}