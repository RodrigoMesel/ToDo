using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.ViewModels;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.Presentation.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var usuarios = _repository.GetAll();
            
            
            return View(Map(usuarios));
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var usuario = _repository.GetById(id.Value);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(Map(usuario));
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDB = new Usuario(Guid.NewGuid(), usuario.Name);
                _repository.Add(usuarioDB);
                await _repository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var usuario = _repository.GetById(id.Value);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(Map(usuario));
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] UsuarioViewModel usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioDB = new Usuario(id, usuario.Name);

                    _repository.Update(usuarioDB);
                    await _repository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var usuario = _repository.GetById(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(Map(usuario));
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var usuario = _repository.GetById(id);

            if (usuario != null)
            {
                _repository.Delete(usuario);
            }
            
            await _repository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(Guid id)
        {
            return _repository.GetById(id) != null;
        }

        private UsuarioViewModel Map(Usuario usuario)
        {
            return new UsuarioViewModel
            {
                Name = usuario.Name,
                Id = usuario.Id
            };
        }

        private IQueryable<UsuarioViewModel> Map(IQueryable<Usuario> usuarios)
        {
            var response = new List<UsuarioViewModel>();
            foreach (var item in usuarios)
            {
                response.Add(Map(item));
            }

            return response.AsQueryable();
        }
    }
}
