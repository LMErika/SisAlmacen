using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaLogica;

namespace CapaWeb.Controllers
{
    public class IntranetController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection fmr)
        {
            try
            {
                entUsuario u = LogUsuario.Instancia.VerificarAcceso(fmr["txtUsuario"].ToString(),
                                                                   fmr["txtContasena"].ToString());
                if (u != null)
                {
                    Session["usuarito"] = u;
                    return RedirectToAction("Principal", "Intranet");
                }
                else
                {
                    ViewBag.mensaje = "Usuario o Contraseña no Valido";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult Principal()
        {
            return View();

        }
    }
}
