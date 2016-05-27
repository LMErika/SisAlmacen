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

    }
}
