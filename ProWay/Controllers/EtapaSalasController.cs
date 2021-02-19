using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProWay.Models;

namespace ProWay.Controllers
{
    public class EtapaSalasController : Controller
    {
        private readonly testeprowayContext _context;

        public EtapaSalasController(testeprowayContext context)
        {
            _context = context;
        }

        // GET: EtapaSalas
        public async Task<IActionResult> Index()
        {
            var testeprowayContext = _context.EtapaSalas.Include(e => e.IdAlunoNavigation).Include(e => e.IdSalaNavigation);
            return View(await testeprowayContext.ToListAsync());
        }

        // GET: EtapaSalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapaSala = await _context.EtapaSalas
                .Include(e => e.IdAlunoNavigation)
                .Include(e => e.IdSalaNavigation)
                .FirstOrDefaultAsync(m => m.IdEtapa == id);
            if (etapaSala == null)
            {
                return NotFound();
            }

            return View(etapaSala);
        }

        // GET: EtapaSalas/Create
        public IActionResult Create()
        {
            ViewData["IdAluno"] = new SelectList(_context.Alunos, "IdAluno", "IdAluno");
            ViewData["IdSala"] = new SelectList(_context.Salas, "IdSala", "IdSala");
            return View();
        }

        // POST: EtapaSalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEtapa,Etapa,IdAluno,IdSala")] EtapaSala etapaSala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etapaSala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAluno"] = new SelectList(_context.Alunos, "IdAluno", "IdAluno", etapaSala.IdAluno);
            ViewData["IdSala"] = new SelectList(_context.Salas, "IdSala", "IdSala", etapaSala.IdSala);
            return View(etapaSala);
        }

        // GET: EtapaSalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapaSala = await _context.EtapaSalas.FindAsync(id);
            if (etapaSala == null)
            {
                return NotFound();
            }
            ViewData["IdAluno"] = new SelectList(_context.Alunos, "IdAluno", "IdAluno", etapaSala.IdAluno);
            ViewData["IdSala"] = new SelectList(_context.Salas, "IdSala", "IdSala", etapaSala.IdSala);
            return View(etapaSala);
        }

        // POST: EtapaSalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEtapa,Etapa,IdAluno,IdSala")] EtapaSala etapaSala)
        {
            if (id != etapaSala.IdEtapa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etapaSala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtapaSalaExists(etapaSala.IdEtapa))
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
            ViewData["IdAluno"] = new SelectList(_context.Alunos, "IdAluno", "IdAluno", etapaSala.IdAluno);
            ViewData["IdSala"] = new SelectList(_context.Salas, "IdSala", "IdSala", etapaSala.IdSala);
            return View(etapaSala);
        }

        // GET: EtapaSalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapaSala = await _context.EtapaSalas
                .Include(e => e.IdAlunoNavigation)
                .Include(e => e.IdSalaNavigation)
                .FirstOrDefaultAsync(m => m.IdEtapa == id);
            if (etapaSala == null)
            {
                return NotFound();
            }

            return View(etapaSala);
        }

        // POST: EtapaSalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etapaSala = await _context.EtapaSalas.FindAsync(id);
            _context.EtapaSalas.Remove(etapaSala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtapaSalaExists(int id)
        {
            return _context.EtapaSalas.Any(e => e.IdEtapa == id);
        }
    }
}
