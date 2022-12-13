using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDHoteles.Models;
using MySqlConnector;

namespace CRUDHoteles.Controllers
{
    public class HotelesController : Controller
    {
        private readonly cheil2Context _context;

        public HotelesController(cheil2Context context)
        {
            _context = context;
        }

        // GET: Hoteles
        public async Task<IActionResult> Index()
        {
              return View(await _context.Hoteles.ToListAsync());
        }

        // GET: Hoteles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hoteles == null)
            {
                return NotFound();
            }

            var hotele = await _context.Hoteles
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotele == null)
            {
                return NotFound();
            }

            return View(hotele);
        }

        // GET: Hoteles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hoteles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,HotelName,Categoria,Precio,Foto1,Foto2,Foto3")] Hotele hotele)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotele);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotele);
        }

        // GET: Hoteles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hoteles == null)
            {
                return NotFound();
            }

            var hotele = await _context.Hoteles.FindAsync(id);
            if (hotele == null)
            {
                return NotFound();
            }
            return View(hotele);
        }

        // POST: Hoteles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelId,HotelName,Categoria,Precio,Foto1,Foto2,Foto3")] Hotele hotele)
        {
            if (id != hotele.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotele);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoteleExists(hotele.HotelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotele);
        }

        // GET: Hoteles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hoteles == null)
            {
                return NotFound();
            }

            var hotele = await _context.Hoteles
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotele == null)
            {
                return NotFound();
            }

            return View(hotele);
        }

        // POST: Hoteles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hoteles == null)
            {
                return Problem("Entity set 'cheil2Context.Hoteles'  is null.");
            }
            var hotele = await _context.Hoteles.FindAsync(id);
            if (hotele != null)
            {
                _context.Hoteles.Remove(hotele);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoteleExists(int id)
        {
          return _context.Hoteles.Any(e => e.HotelId == id);
        }

        public async Task<IActionResult> AgregarComentario(int? id)
        {
            Calificacione _Calificaciones = new Calificacione()
            {
                HotelId = 1,
                Calificacion = 5,
                Comentario = "Probando"
            };
            _context.Calificaciones.Add(_Calificaciones);
            _context.SaveChanges();
            ViewBag.Calificacione = _context.Calificaciones.ToList();
            return View();
        }


        public async Task<IActionResult> GetComentario(string? Categoria, int? Calificacion, int? Precio)
        {
            //var Hotel = _context.Hoteles.Where(x => x.Categoria == Categoria).ToArray();
            //ViewBag.Hotel = Hotel;
            //return View("VerComentarios");

            if (Categoria == null && Calificacion == null)
            {
                if (Precio == null)
                {
                    var Sql = _context.Hoteles.ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Hotel = Sql;
                    ViewBag.Contador1 = contador1;
                    ViewBag.Condicional = 1;
                }

                if (Precio == 1)
                {
                    var Sql = _context.Hoteles.OrderBy(x => x.Precio).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Hotel = Sql;
                    ViewBag.Contador1 = contador1;
                    ViewBag.Condicional = 1;
                }

                if (Precio == 2)
                {
                    var Sql = _context.Hoteles.OrderByDescending(x => x.Precio).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Hotel = Sql;
                    ViewBag.Contador1 = contador1;
                    ViewBag.Condicional = 1;
                }
            }

            if (Calificacion == 1)
            {

                if (Precio == null)
                {
                    var Sql = _context.Hoteles.Join(_context.Calificaciones, calificaciones => calificaciones.HotelId, hoteles => hoteles.HotelId, (hoteles, calificaciones) => new
                    {
                        hoteles,
                        calificaciones
                    }).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Contador1 = contador1;
                    ViewBag.Hotel = Sql;
                    ViewBag.Condicional = 2;
                }

                if (Precio == 1)
                {
                    var Sql = _context.Hoteles.Join(_context.Calificaciones, calificaciones => calificaciones.HotelId, hoteles => hoteles.HotelId, (hoteles, calificaciones) => new {
                        hoteles,
                        calificaciones
                    }).OrderBy(x => x.hoteles.Precio).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Contador1 = contador1;
                    ViewBag.Hotel = Sql;
                    ViewBag.Condicional = 2;
                }

                if (Precio == 2)
                {
                    var Sql = _context.Hoteles.Join(_context.Calificaciones, calificaciones => calificaciones.HotelId, hoteles => hoteles.HotelId, (hoteles, calificaciones) => new {
                        hoteles,
                        calificaciones
                    }).OrderByDescending(x => x.hoteles.Precio).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Contador1 = contador1;
                    ViewBag.Hotel = Sql;
                    ViewBag.Condicional = 2;
                }
            }

            if (Categoria != null)
            {
                //var Hotel = _context.Hoteles.Where(x => x.Categoria == id).ToArray();
                //var Sql = _context.Hoteles.Where(x => x.Categoria == Categoria).SingleOrDefault();

                if (Precio == null)
                {
                    var Sql = _context.Hoteles.Where(x => x.Categoria == Categoria).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Hotel = Sql;
                    ViewBag.Contador1 = contador1;
                    ViewBag.Condicional = 1;
                }

                if (Precio == 1)
                {
                    var Sql = _context.Hoteles.Where(x => x.Categoria == Categoria).OrderBy(x => x.Precio).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Contador1 = contador1;
                    ViewBag.Hotel = Sql;
                    ViewBag.Condicional = 1;
                }

                if (Precio == 2)
                {
                    var Sql = _context.Hoteles.Where(x => x.Categoria == Categoria).OrderByDescending(x => x.Precio).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Contador1 = contador1;
                    ViewBag.Hotel = Sql;
                    ViewBag.Condicional = 1;
                }
            }


            if (Calificacion == 1 && Categoria != null)
            {
                if (Precio == null)
                {
                    var Sql = _context.Hoteles.Join(_context.Calificaciones, calificaciones => calificaciones.HotelId, hoteles => hoteles.HotelId, (hoteles, calificaciones) => new {
                        hoteles,
                        calificaciones
                    }).Where(x => x.hoteles.Categoria == Categoria).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Contador1 = contador1;
                    ViewBag.Hotel = Sql;
                    ViewBag.Condicional = 2;
                }

                if (Precio == 1)
                {
                    var Sql = _context.Hoteles.Join(_context.Calificaciones, calificaciones => calificaciones.HotelId, hoteles => hoteles.HotelId, (hoteles, calificaciones) => new {
                        hoteles,
                        calificaciones
                    }).Where(x => x.hoteles.Categoria == Categoria).OrderBy(x => x.hoteles.Precio).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Contador1 = contador1;
                    ViewBag.Hotel = Sql;
                    ViewBag.Condicional = 2;
                }

                if (Precio == 2)
                {
                    var Sql = _context.Hoteles.Join(_context.Calificaciones, calificaciones => calificaciones.HotelId, hoteles => hoteles.HotelId, (hoteles, calificaciones) => new {
                        hoteles,
                        calificaciones
                    }).Where(x => x.hoteles.Categoria == Categoria).OrderByDescending(x => x.hoteles.Precio).ToList();
                    var contador1 = Sql.Count();
                    ViewBag.Contador1 = contador1;
                    ViewBag.Hotel = Sql;
                    ViewBag.Condicional = 2;
                }

            }

            return View("VerComentarios");
        }


        public async Task<IActionResult> FindComentario(int id)
        {
            var Sql = _context.Hoteles.Join(_context.Calificaciones, calificaciones => calificaciones.HotelId, hoteles => hoteles.HotelId, (hoteles, calificaciones) => new {
                hoteles,
                calificaciones
            }).Where(x => x.hoteles.HotelId == id).ToList();
            var contador1 = Sql.Count();
            ViewBag.Contador1 = contador1;
            ViewBag.Hotel = Sql;
            ViewBag.Condicional = 2;

            return View("FindComentario");
        }

    }
}
