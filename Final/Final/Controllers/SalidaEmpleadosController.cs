using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final.Views;

namespace Final.Controllers
{
    public class SalidaEmpleadosController : Controller
    {
        private final_prog3Entities4 db = new final_prog3Entities4();

        // GET: SalidaEmpleados
        public ActionResult Index()
        {
            return View(db.SalidaEmpleados.ToList());
        }

        // GET: Salida/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Salida/Edit/5
        public ActionResult Create()
        {
            ViewBag.PersonList = new SelectList(db.Empleados.Where(m => m.estatus == "Activo"), "Id", "Nombre");
            return View();
        }

        // POST: Salida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalidaEmpleados salida)
        {
            try
            {

                int CodigoEmpleado = Convert.ToInt32(Request.Form["IdEmpleado"]);
                var EmpleadoSalida = db.Empleados.Where(m => m.Id == CodigoEmpleado && m.estatus == "Activo").First();


                int IdSalida = EmpleadoSalida.Id;
                Empleados EmpleadoStatus = db.Empleados.Where(m => m.estatus == "Activo" && m.Id == salida.IdEmpleado).First();
                EmpleadoStatus.estatus = "Inactivo";
                salida.IdEmpleado = IdSalida;
                db.Entry(EmpleadoStatus).State = EntityState.Modified;
                db.SalidaEmpleados.Add(salida);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch { }
            ViewBag.NoResultados = "No hay ningún empleado con este código";
            return View();
        }


    }
}
