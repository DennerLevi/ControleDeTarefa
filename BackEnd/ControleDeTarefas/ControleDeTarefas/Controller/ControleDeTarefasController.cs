using ControleDeTarefas.Models;
using ControleDeTarefas.Services.LivrosService;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeTarefas.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControleDeTarefasController : ControllerBase
    {
        private readonly IControleDeTarefasInterface _controleDeTarefasInterface;
        public ControleDeTarefasController(IControleDeTarefasInterface livroInterface)
        {
            _controleDeTarefasInterface = livroInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetAlllivros()
        {
            IEnumerable<Tarefa> tarefa = await _controleDeTarefasInterface.GetAlllivros();

            if (!tarefa.Any())
            {
                return NotFound("Nenhum registro localizado");
            }

            return Ok(tarefa);
        }
        [HttpGet("Titulo")]
        public async Task<ActionResult<Tarefa>> GetLivroByName(string titulo)
        {
            Tarefa tarefa = await _controleDeTarefasInterface.GetLivroByName(titulo);

            if (tarefa == null)
            {
                return NotFound("Tarefa nao encontrado");
            }
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Tarefa>>> CreateLivro(Tarefa tarefaId)
        {
            IEnumerable<Tarefa> tarefa = await _controleDeTarefasInterface.CreateLivro(tarefaId);

            return Ok(tarefa);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Tarefa>>> UpdateLivro(Tarefa tarefa)
        {
            Tarefa Titulo = await _controleDeTarefasInterface.GetLivroByName(tarefa.Titulo);

            if (Titulo.Titulo == null)
                return NotFound("Titulo não encontrado");

            IEnumerable<Tarefa> tarefas = await _controleDeTarefasInterface.UpdateLivro(tarefa);

            return Ok(tarefas);
        }
        [HttpDelete("{livroId}")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> DeletionLivro(string titulo)
        {
            Tarefa registro = await _controleDeTarefasInterface.GetLivroByName(titulo);

            if (registro.Titulo == null)
                return NotFound("Livro não encontrado");

            IEnumerable<Tarefa> tarefas = await _controleDeTarefasInterface.DeletionLivro(titulo);

            return Ok(tarefas);
        }
    }

}
