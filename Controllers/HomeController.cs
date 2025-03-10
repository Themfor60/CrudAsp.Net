using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Udemy.Data;
using Udemy.Models;

namespace Udemy.Controllers
{
    public class HomeController : Controller
    {
       private readonly AplicacionDbContext _context;

        public HomeController(AplicacionDbContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task< IActionResult> Index()
        {
            return View(await _context.Contacto.ToListAsync());
        }


        [HttpGet]
        public IActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task< IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid) 
            {
                //Agregar la fecha
                contacto.FechaDeCreacion = DateTime.Now;
                //abrimos cle context y entramo a contactos y agregado en la varible contaco de nuestro boton crear
                _context.Contacto.Add(contacto);
                await _context.SaveChangesAsync();  
                return RedirectToAction("Index"); 
            }
            return View(); 
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _context.Contacto.Find(id);
            if (contacto == null) 
            {
                return NotFound();
            }
            return View(contacto);
        }

        //Metodo para editar 

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid) 
            {
               
                _context.Contacto.Update(contacto);
                await _context.SaveChangesAsync(); 
                return RedirectToAction("Index"); 
            }
            return View(); 
        }
        //Metodo para ver detalle 

        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }


        //Crear vista para borrar
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }


        //Metodo de borrar

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
          var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null) 
            {
                return View();
            }
            //Borrar
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            
        }




        /// <summary>
        /// ////////////
        /// </summary>
        /// <returns></returns>
        /// 


        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
