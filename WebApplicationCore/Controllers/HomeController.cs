using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCore.Models;
using ML;
using BL;

namespace WebApplicationCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Estudiante> lista = new EstudianteBL().GetEstudiantes();
            ViewData["ListaEstudiantes"] = lista;
            List<Sexo> listaSexo = new SexoBL().GetSexo();
            ViewData["ListaSexo"] = listaSexo;
            List<Tipodoc> listaTipodoc = new TipodocBL().GetTipodoc();
            ViewData["ListaTipodoc"] = listaTipodoc;
            List<Carrera> listaCarrera = new CarreraBL().GetCarrera();
            ViewData["ListaCarrera"] = listaCarrera;
            List<Moding> lisatModing = new ModingBL().GetModing();
            ViewData["ListaModing"] = lisatModing;
            List<Estado> listaEstado = new EstadoBL().GetEstado();
            ViewData["ListaEstado"] = listaEstado;
            List<Discapacidad> listaDiscapacidad = new DiscapacidadBL().GetDiscapacidad();
            ViewData["ListaDiscapacidad"] = listaDiscapacidad;
            int cantidadEstudiantes = new EstudianteBL().ContarEstudiantes();
            ViewData["CantidadEstudiantes"] = cantidadEstudiantes;
            return View();
        }


        public IActionResult InsertEstudiante()
        {
            string pa=Request.Form["pa"].ToString();
            string sa= Request.Form["sa"].ToString();
            string n= Request.Form["n"].ToString();
            int s = int.Parse(Request.Form["s"].ToString());
            int td=int.Parse(Request.Form["td"].ToString());
            string nd = Request.Form["nd"].ToString(); ;
            int car = int.Parse(Request.Form["car"].ToString()); ;
            int mi = int.Parse(Request.Form["mi"].ToString()); ;
            int es = int.Parse(Request.Form["es"].ToString()); ;
            int disc = int.Parse(Request.Form["disc"].ToString()); ;
            EstudianteBL insertarEstudiante = new EstudianteBL();
            insertarEstudiante.InsertEstudiante(pa, sa, n, s, td, nd, car, mi, es, disc);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult viewUpdateEstudiante()
        {
            List<Estudiante> lista = new EstudianteBL().GetEstudiantes();
            ViewData["ListaEstudiantes"] = lista;
            List<Sexo> listaSexo = new SexoBL().GetSexo();
            ViewData["ListaSexo"] = listaSexo;
            List<Tipodoc> listaTipodoc = new TipodocBL().GetTipodoc();
            ViewData["ListaTipodoc"] = listaTipodoc;
            List<Carrera> listaCarrera = new CarreraBL().GetCarrera();
            ViewData["ListaCarrera"] = listaCarrera;
            List<Moding> lisatModing = new ModingBL().GetModing();
            ViewData["ListaModing"] = lisatModing;
            List<Estado> listaEstado = new EstadoBL().GetEstado();
            ViewData["ListaEstado"] = listaEstado;
            List<Discapacidad> listaDiscapacidad = new DiscapacidadBL().GetDiscapacidad();
            ViewData["ListaDiscapacidad"] = listaDiscapacidad;
            /*Recibe datos del form*/
            int id = int.Parse(Request.Form["id_update"].ToString());
            EstudianteDB estudiantedb = new EstudianteBL().GetEstudianteDB(id);
            ViewData["EstudianteDB"] = estudiantedb;
            return View();
        }

        public IActionResult VerEstudiante()
        {
            int id = int.Parse(Request.Form["id_ver"].ToString());
            List<Estudiante> lista = new EstudianteBL().GetEstudiantes();
            ViewData["ListaEstudiantes"] = lista;
            List<Sexo> listaSexo = new SexoBL().GetSexo();
            ViewData["ListaSexo"] = listaSexo;
            List<Tipodoc> listaTipodoc = new TipodocBL().GetTipodoc();
            ViewData["ListaTipodoc"] = listaTipodoc;
            List<Carrera> listaCarrera = new CarreraBL().GetCarrera();
            ViewData["ListaCarrera"] = listaCarrera;
            List<Moding> lisatModing = new ModingBL().GetModing();
            ViewData["ListaModing"] = lisatModing;
            List<Estado> listaEstado = new EstadoBL().GetEstado();
            ViewData["ListaEstado"] = listaEstado;
            List<Discapacidad> listaDiscapacidad = new DiscapacidadBL().GetDiscapacidad();
            ViewData["ListaDiscapacidad"] = listaDiscapacidad;
            EstudianteDB estudianteDB= new EstudianteBL().GetEstudianteDB(id);
            ViewData["EstudianteDB"] = estudianteDB;
            return View();
        }
        public IActionResult UpdateEstudiante()
        {
            int id = int.Parse(Request.Form["id"].ToString());
            string pa = Request.Form["pa"].ToString();
            string sa = Request.Form["sa"].ToString();
            string n = Request.Form["n"].ToString();
            int s = int.Parse(Request.Form["s"].ToString());
            int td = int.Parse(Request.Form["td"].ToString());
            string nd = Request.Form["nd"].ToString(); ;
            int car = int.Parse(Request.Form["car"].ToString()); ;
            int mi = int.Parse(Request.Form["mi"].ToString()); ;
            int es = int.Parse(Request.Form["es"].ToString()); ;
            int disc = int.Parse(Request.Form["disc"].ToString());
            EstudianteBL updateEstudiante = new EstudianteBL();
            updateEstudiante.UpdateEstudiante(id, pa, sa, n, s, td, nd, car, mi, es, disc);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteEstudiante()
        {
            int id = int.Parse(Request.Form["id_delete"].ToString());
            EstudianteBL deleleEstudiante = new EstudianteBL();
            deleleEstudiante.DeleteEstudiante(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SearchEstudiante()
        {
            string busqueda = "";
            try
            {
                busqueda = Request.Form["busqueda"].ToString();
            }
            catch (Exception ex)
            {
                busqueda = "";
            }
            if (busqueda == null || busqueda == "")
            {
                List<Estudiante> lista = new EstudianteBL().GetEstudiantes();
                ViewData["ListaEstudiantes"] = lista;
            }
            else
            {/*Cuando se busca algo*/
                List<Estudiante> lista = new EstudianteBL().SearchEstudiantes(busqueda);
                ViewData["ListaEstudiantes"] = lista;
                ViewData["Buscar"] = "true";
            }
            List<Sexo> listaSexo = new SexoBL().GetSexo();
            ViewData["ListaSexo"] = listaSexo;
            List<Tipodoc> listaTipodoc = new TipodocBL().GetTipodoc();
            ViewData["ListaTipodoc"] = listaTipodoc;
            List<Carrera> listaCarrera = new CarreraBL().GetCarrera();
            ViewData["ListaCarrera"] = listaCarrera;
            List<Moding> lisatModing = new ModingBL().GetModing();
            ViewData["ListaModing"] = lisatModing;
            List<Estado> listaEstado = new EstadoBL().GetEstado();
            ViewData["ListaEstado"] = listaEstado;
            List<Discapacidad> listaDiscapacidad = new DiscapacidadBL().GetDiscapacidad();
            ViewData["ListaDiscapacidad"] = listaDiscapacidad;
            return View();
        }

        public IActionResult Carreras()
        {
            List<Carrera> listaCarrera = new CarreraBL().GetCarrera();
            ViewData["ListaCarrera"] = listaCarrera;
            List<Facultad> listaFacultad = new FacultadBL().GetFacultad();
            ViewData["ListaFacultad"] = listaFacultad;
            int cantidadCarreras = new CarreraBL().ContarCarreras();
            ViewData["CantidadCarreras"] = cantidadCarreras;
            List<Area> listaAreas = new AreaBL().GetAreas();
            ViewData["ListaAreas"] = listaAreas;
            return View();
        }

        public IActionResult InsertCarrera()
        {
            string nombre=Request.Form["cn"].ToString();
            int facultad= int.Parse(Request.Form["f"].ToString());
            int area = int.Parse(Request.Form["ar"].ToString());
            CarreraBL insertarCarrera = new CarreraBL();
            insertarCarrera.InsertarCarrera(nombre, facultad, area);
            return RedirectToAction("Carreras", "");
        }

       public IActionResult UpdateCarrera()
        {
            int id = int.Parse(Request.Form["id"].ToString());
            string nombre = Request.Form["cn"].ToString();
            int facultad = int.Parse(Request.Form["f"].ToString());
            int area = int.Parse(Request.Form["ar"].ToString());
            CarreraBL updateCarrera = new CarreraBL();
            updateCarrera.UpdateCarrera(id, nombre, facultad, area);
            return RedirectToAction("Carreras", "");
        }

        public IActionResult viewUpdateCarrera()
        {
            List<Carrera> listaCarrera = new CarreraBL().GetCarrera();
            ViewData["ListaCarrera"] = listaCarrera;
            List<Facultad> listaFacultad = new FacultadBL().GetFacultad();
            ViewData["ListaFacultad"] = listaFacultad;
            int cantidadCarreras = new CarreraBL().ContarCarreras();
            ViewData["CantidadCarreras"] = cantidadCarreras;
            List<Area> listaAreas = new AreaBL().GetAreas();
            ViewData["ListaAreas"] = listaAreas;
            /*Recibe datos del form*/
            int id = int.Parse(Request.Form["id_update"].ToString());
            CarreraDB carreradb = new CarreraBL().GetCarreraDB(id);
            ViewData["CarreraDB"] = carreradb;
            return View();
        }

        public IActionResult SearchCarrera()
        {
            string busqueda = "";
            try
            {
                busqueda = Request.Form["busqueda"].ToString();
            }
            catch (Exception ex)
            {
                busqueda = "";
            }
            if (busqueda == null || busqueda == "")
            {
                List<Carrera> lista = new CarreraBL().GetCarrera();
                ViewData["ListaCarrera"] = lista;
            }
            else
            {/*Cuando se busca algo*/
                List<Carrera> lista = new CarreraBL().SearchCarrera(busqueda);
                ViewData["ListaCarrera"] = lista;
                ViewData["Buscar"] = "true";
            }
            List<Facultad> listaFacultad = new FacultadBL().GetFacultad();
            ViewData["ListaFacultad"] = listaFacultad;
            int cantidadCarreras = new CarreraBL().ContarCarreras();
            ViewData["CantidadCarreras"] = cantidadCarreras;
            List<Area> listaAreas = new AreaBL().GetAreas();
            ViewData["ListaAreas"] = listaAreas;
            return View();
        }

        public IActionResult DeleteCarrera()
        {
            int id = int.Parse(Request.Form["id_delete"].ToString());
            CarreraBL deleteCarrera = new CarreraBL();
            deleteCarrera.DeleteCarrera(id);
            return RedirectToAction("Carreras", "");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
