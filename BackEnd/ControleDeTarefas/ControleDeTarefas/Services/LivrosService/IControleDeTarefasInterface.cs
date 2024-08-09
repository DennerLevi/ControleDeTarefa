using ControleDeTarefas.Models;

namespace ControleDeTarefas.Services.LivrosService
{
    public interface IControleDeTarefasInterface
    {
        Task<IEnumerable<Tarefa>> GetAlllivros();
        Task<Tarefa> GetLivroByName(string titulo); 
        Task<IEnumerable<Tarefa>> CreateLivro(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> UpdateLivro(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> DeletionLivro(string titulo);

    }
}
