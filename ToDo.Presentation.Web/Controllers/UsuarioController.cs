using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Interfaces;
using ToDo.Application.ViewModels;

namespace ToDo.Presentation.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _usuarioService.GetAllAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var usuario = await _usuarioService.GetByIdAsync(id.Value);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
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
                await _usuarioService.AddAsync(usuario);

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

            var usuario = await _usuarioService.GetByIdAsync(id.Value);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,UserId")] UsuarioViewModel usuario)
        {
            if (id != usuario.UserId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _usuarioService.UpdateAsync(usuario);
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

            var user = await _usuarioService.GetByIdAsync(id.Value);

            return View(user);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, [Bind("Name,UserId")] UsuarioViewModel usuario)
        {
            if (id != usuario.UserId)
            {
                return BadRequest();
            }

            var response = await _usuarioService.DeleteAsync(id);
            if (response)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Delete), usuario);
        }

    }
}
