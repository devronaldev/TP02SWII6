using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP02SWII6.Models;

namespace TP02SWII6.Controllers
{
    public class ContainerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContainerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Container
        public IActionResult Index()
        {
            try
            {
                var containers = _context.Containers.ToList(); // Buscando todos os containers
                return View(containers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}"); // Exibe a mensagem de erro no console
                return View(new List<Container>()); // Retorna uma lista vazia para a View
            }
        }

        // GET: Container/Create
        public IActionResult Create()
        {
            ViewBag.BLs = _context.BLs.ToList(); // Passando os BLs para a view
            return View(new Container());
        }

        // POST: Container/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Container container)
        {
            if (ModelState.IsValid)
            {
                // Certifique-se de que container.idBL corresponde a um ID válido na tabela BL
                _context.Containers.Add(container);
                _context.SaveChanges();
                Console.WriteLine("Validação de Model State Realizada com sucesso.");
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            ViewBag.BLs = _context.BLs.ToList();
            return View(container);
        }

        // GET: Container/Edit/5
        public IActionResult Edit(int id)
        {
            var container = _context.Containers.Find(id);
            if (container == null)
            {
                return NotFound();
            }

            ViewBag.BLs = _context.BLs.ToList(); // Povoar os BLs
            ViewBag.Tipos = GetTipos(); // Método para obter os tipos
            ViewBag.Tamanhos = GetTamanhos(); // Método para obter os tamanhos

            return View(container);
        }

        // Métodos fictícios para retornar tipos e tamanhos
        private List<SelectListItem> GetTipos()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Dry" },
                new SelectListItem { Value = "2", Text = "Reefer" },
                // Adicione outros tipos conforme necessário
            };
        }

        private List<SelectListItem> GetTamanhos()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "20", Text = "Pequeno - 20 pés" },
                new SelectListItem { Value = "40", Text = "Grande - 40 pés" },
                // Adicione outros tamanhos conforme necessário
            };
        }

        // POST: Container/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Container container)
        {
            if (id != container.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(container);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainerExists(container.Id))
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

            // Recarrega os dados necessários para os selects caso a validação falhe
            ViewBag.BLs = await _context.BLs.ToListAsync();
            ViewBag.Tipos = GetTipos();
            ViewBag.Tamanhos = GetTamanhos();

            return View(container);
        }

        private bool ContainerExists(int id)
        {
            return _context.Containers.Any(e => e.Id == id);
        }

        // POST: Container/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var container = await _context.Containers.FindAsync(id); // Uso do FindAsync para simplificar
            if (container == null)
            {
                return NotFound();
            }

            _context.Containers.Remove(container);
            await _context.SaveChangesAsync(); // Chamada assíncrona para SaveChangesAsync()
            return RedirectToAction(nameof(Index));
        }
    }
}
