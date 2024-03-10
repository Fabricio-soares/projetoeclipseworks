using Dapper;
using Microsoft.Extensions.Configuration;
using projetoeclipseworks.Dados.Entidades;
using projetoeclipseworks.Dados.Repositorios;
using System.Data.SqlClient;

namespace Tarefaeclipseworks.Dados.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly IConfiguration _configuration;

        public TarefaRepositorio(IConfiguration configure)
        {
            _configuration = configure;
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("TarefaConnection").Value;
            return connection;
        }

        public async Task<Tarefa> CreateEntity(Tarefa entity)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO dbo.Tarefa( Id
                                                      ,Nome
                                                      ,Nivel
                                                      ,Finalizada
                                                      ,ProjetoId
                                                      ,UsuarioResponsavelId
                                                      ,DataConclusao) 
                                               VALUES( @Id
                                                      ,@Nome
                                                      ,@Nivel
                                                      ,@Finalizada
                                                      ,@ProjetoId
                                                      ,@UsuarioResponsavelId
                                                      ,@DataConclusao); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return entity;
            }
        }
        public async Task<bool> DeleteEntity(Guid id)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM dbo.Tarefa WHERE Id =" + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count >= 1;
            }
        }
        public async Task<Tarefa> UpdateEntity(Tarefa entity)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"UPDATE Tarefa SET Name = @Nome, 
                                                    Nivel = @Nivel,
                                                    Finalizada = @Finalizada 
                                                    ProjetoId = @ProjetoId 
                                                    UsuarioResponsavelId = @UsuarioResponsavelId 
                                                    DataConclusao = @DataConclusao 
                                                    WHERE TarefaId = " + entity.Id;
                    count = con.Execute(query, entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return entity;
            }
        }
        public async Task<Tarefa> GetEntityById(Guid id)
        {
            var connectionString = this.GetConnection();
            Tarefa Tarefa = new Tarefa();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Tarefa WHERE Id =" + id;
                    Tarefa = con.Query<Tarefa>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return Tarefa;
            }
        }
        public async Task<IEnumerable<Tarefa>> GetAllEntities()
        {
            var connectionString = this.GetConnection();
            List<Tarefa> Tarefas = new List<Tarefa>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Tarefa";
                    Tarefas = con.Query<Tarefa>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return Tarefas;
            }
        }
    }

}
