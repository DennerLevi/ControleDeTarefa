using ControleDeTarefas.Models;
using Dapper;
using System.Data.SqlClient;

namespace ControleDeTarefas.Services.LivrosService
{
    public class ControleDeTarefasService : IControleDeTarefasInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;

        public ControleDeTarefasService(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Tarefa>> CreateLivro(Tarefa tarefa)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "insert into livros(titulo,autor) values (@titulo,@autor)";
                //executar dentro do banco
                await con.ExecuteAsync(sql, tarefa);

                return await con.QueryAsync<Tarefa>("select * from Livros");
            }
        }

        public async Task<IEnumerable<Tarefa>> DeletionLivro(string tarefaId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "delete from livros where id = @id";
                await con.ExecuteAsync(sql, new { Id = tarefaId });
                return await con.QueryAsync<Tarefa>("Select * from livros order by 1 desc");
            }
        }
        public async Task<IEnumerable<Tarefa>> GetAlllivros()
        {
            //abri a conexão com o banco
            using (var con = new SqlConnection(getConnection))
            {
                //pegando todos os registros 
                var sql = "select * from Tarefa order by 1 desc";
                return await con.QueryAsync<Tarefa>(sql);
            }
        }

        public async Task<Tarefa> GetLivroByName(string titulo)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Tarefa where Titulo =@Titulo";
                return await con.QueryFirstOrDefaultAsync<Tarefa>(sql, new { Titulo = titulo });
            }
        }

        public async Task<IEnumerable<Tarefa>> UpdateLivro(Tarefa tarefaId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "update livros set titulo = @titulo,autor = @autor where id = @id";
                await con.ExecuteAsync(sql, tarefaId);
                return await con.QueryAsync<Tarefa>("Select * from livros order by 1 desc");
            }
        }
    }
}