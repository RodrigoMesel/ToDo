using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Interfaces;
using ToDo.Application.ViewModels;
using ToDo.Domain.Enums;

namespace ToDo.Presentation.Web.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }


        // GET: Tarefa
        public async Task<IActionResult> Index()
        {
            return View(await _tarefaService.GetAllAsync());
        }

        // GET: Tarefa/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var tarefa = await _tarefaService.GetByIdAsync(id.Value);

            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        public async Task<IActionResult> GetByStatus(StatusTarefa status)
        {
            var lista = await _tarefaService.GetByStatusAsync(status);
            return View(lista);
        }

        // GET: Tarefa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarefa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,ResponsableID,EstimatedDate,TaskStatus,TaskID")] TarefaViewModel tarefaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _tarefaService.AddAsync(tarefaViewModel);
                return RedirectToAction(nameof(Index));

            }
            return View(tarefaViewModel);
        }

        // GET: Tarefa/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var tarefa = await _tarefaService.GetByIdAsync(id.Value);

            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Description,ResponsableID,EstimatedDate,TaskStatus,TaskID")] TarefaViewModel tarefa)
        {
            if (id != tarefa.TaskID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _tarefaService.UpdateAsync(tarefa);
                return RedirectToAction(nameof(Index));

            }
            return View(tarefa);
        }

        // GET: Tarefa/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var tarefa = await _tarefaService.GetByIdAsync(id.Value);

            return View(tarefa);
        }

        // POST: Tarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           var response = await _tarefaService.DeleteAsync(id);
            
            if (response)
            {
                return RedirectToAction(nameof(Index));
            }

            var tarefa = await _tarefaService.GetByIdAsync(id);

            return RedirectToAction(nameof(Delete), tarefa);
        }


    }
}
