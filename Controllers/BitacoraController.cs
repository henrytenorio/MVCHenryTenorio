using MVCHenryTenorio.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHenryTenorio.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        public ActionResult Index(BitacoraViewModel model)
        {
            BitacoraViewModel objFinal = new BitacoraViewModel();

            objFinal.detalleBitacora = new List<BitacoraViewModel>();

            //Obtengo la data del archivo
            string resultado = new StreamReader(@"C:\temp\Test\HenryTenorio\Bitacora.txt").ReadToEnd();

            //En este caso quiero separar por la coma, me devolvería 2 valores
            string[] datos = resultado.Split('>');
            List<BitacoraViewModel> lst;
            lst = new List<BitacoraViewModel>();

            bool banderaControl = true;
            string filtro = "";
            string filtrousuario = "";
            string filtrooperacion = "";
            foreach (var item in datos)
            {
                if (ModelState.IsValid)
                {
                    filtro = model.tabla;
                    filtrousuario = model.usuario ?? "";
                    filtrooperacion = model.operacion ?? "";

                    // ********* OJO SE ESTAN CARGANDO EN NULL
                }

                

                BitacoraViewModel obj = new BitacoraViewModel();
                string[] datos2 = item.Split((char)9);

                String unirTexto = "";

                int cont = 0;
                    foreach (string item2 in datos2)
                    {
                    banderaControl = true;
                        if (item2 != null)
                        {
                            if (cont == 0) // CONTROL CAMPO OPERACION
                            {
                                if(model.fechaInicio != null && model.fechaFin != null)
                                {
                                    if (item2.Length > 0)
                                    {
                                        
                                        // string fechaTemp = (item2 == null || item2 == "" ? item2 : DateTime.Now.ToShortDateString());
                                        if (model.fechaInicio <= DateTime.Parse(item2) && model.fechaFin >= DateTime.Parse(item2))
                                            {
                                                //NO AGREGAR FILA EN LISTA
                                                banderaControl = true;
                                                
                                            }
                                            else { 
                                                    banderaControl = false;
                                                    break;
                                                }
                                    }
                            }
                            }


                        if (cont == 1) // CONTROL CAMPO OPERACION
                            {
                                if (!item2.Contains(filtrooperacion) && filtrooperacion.Length > 0)
                                {
                                    //NO AGREGAR FILA EN LISTA
                                    banderaControl = false;
                                    break;
                                }
                            }

                            if (cont == 2) // CONTROL CAMPO USUARIO
                            {
                                if (!item2.Contains(filtrousuario) && filtrousuario.Length > 0)
                                {
                                    //NO AGREGAR FILA EN LISTA
                                    banderaControl = false;
                                    break;
                                }
                            }

                        if (cont == 3) // CONTROL CAMPO TABLA
                            {
                                if (!item2.Contains(filtro) && filtro.Length > 0)
                                {
                                    //NO AGREGAR FILA EN LISTA
                                    banderaControl = false;
                                break;
                                }
                            }
                            unirTexto = unirTexto + item2 + " - ";
                        }
                        cont++;
                    }

                if (banderaControl)
                {
                    obj.detalle = unirTexto;
                    objFinal.detalleBitacora.Add(obj);
                }

            }

            objFinal.fechaInicio = DateTime.Now;
            objFinal.fechaFin = DateTime.Now;
            return View(objFinal);
        }

    }
}