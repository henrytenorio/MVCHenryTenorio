using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHenryTenorio.Models;
using MVCHenryTenorio.Models.ViewModels;

namespace MVCHenryTenorio.Controllers
{
    public class ReporteMedicinasController : Controller
    {
        // GET: ReporteMedicinas
        public ActionResult Index()
        {
            List<ReporteViewModel> lst;
            SqlParameter[] Parameters = new SqlParameter[] { };
        

            using (pacientesmvcEntities db = new pacientesmvcEntities() )
            {
                lst = (from d in db.Database.SqlQuery<ReporteViewModel>("execute F_Reporte_Medicinas", Parameters)
                       select new ReporteViewModel
                       {
                           PacienteID = d.PacienteID,
                           NombrePaciente = d.NombrePaciente,
                           Telefono = d.Telefono,
                           Medicina = d.Medicina,
                           FechaIni = d.FechaIni,
                           FechaFin = d.FechaFin
                       }).ToList();

            }
            return View(lst);
        }
    }
}