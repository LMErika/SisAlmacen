using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;
using CapaEntidades;
using CapaLogica;


namespace CapaWeb.Controllers
{
    public class CrudParametroController : Controller
    {
        //
        // GET: /CrudParametro/

        public ActionResult ListarParametro()
        {
            List<entParametro> lista = LogParametro.Instancia.ListarParametro();
            return View(lista);
        }

        [HttpPost]
        public ActionResult Nuevo(FormCollection frm)
        {
            try {
                if (frm["btnGuardar"] != null)
                {
                    entParametro p = new entParametro();
                    p.Codigo = frm["txtCodigo"];
                    p.Descripcion = frm["txtDescripcion"];

                    Boolean inserta = LogParametro.Instancia.InsertarParametro(p);
                    if (inserta != false) {
                        return RedirectToAction("ListarParametro");
                    }
                    else {
                        return View();
                    }
                }
                else {
                    return RedirectToAction("ListarParametro");
                }
            }
            catch (Exception e) { throw e; }
        }

    }
}
