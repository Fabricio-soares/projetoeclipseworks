using Dapper;
using Microsoft.Extensions.Configuration;
using projetoeclipseworks.Dados.Entidades;
using Slapper;
using System.Data.SqlClient;

namespace projetoeclipseworks.Dados.Repositorios
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {
        private readonly IConfiguration _configuration;

        public ProjetoRepositorio(IConfiguration configure)
        {
            _configuration = configure;
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }

        public async Task<Projeto> CreateEntity(Projeto entity)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"INSERT INTO dbo.Projeto (Id,Nome,Nivel,Status) VALUES(@Id ,@Nome ,@Nivel ,@Status); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, entity);
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
                finally
                {
                    con.Close();
                }

            }
            return entity;
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
                    var query = $"DELETE FROM dbo.Projeto WHERE Id = '{id.ToString().ToUpper()}'";
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
        public async Task<Projeto> UpdateEntity(Projeto entity)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE dbo.Projeto SET Name = @Nome, Status = @Status, Nivel = @Nivel WHERE Id = " + entity.Id;
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
        public async Task<Projeto> GetEntityById(Guid id)
        {
            var connectionString = this.GetConnection();
            Projeto Projeto = new Projeto();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    var projetos = con.Query<Projeto, Tarefa, Projeto>(
                             @$"SELECT    PRO.Id
                                       ,PRO.Nome
                                       ,PRO.Nivel
                                       ,PRO.Status
                                       ,TAR.ProjetoId
                                       ,TAR.Id
                                       ,TAR.Nome
                                       ,TAR.Nivel
                                       ,TAR.Finalizada
                                       ,TAR.UsuarioResponsavelId
                                       ,TAR.DataConclusao 
                                FROM dbo.Projeto PRO LEFT JOIN dbo.Tarefa TAR  ON PRO.Id = TAR.ProjetoId
                                    WHERE  PRO.Id  = '{id}'",
                             map: (projeto, tarefa) =>
                             {
                                 projeto.Tarefas = new List<Tarefa>();

                                 if (projeto.Tarefas != null)
                                     projeto.Tarefas.Add(tarefa);
                                 return projeto;
                             },
                            splitOn: "ProjetoId");

                    return projetos.GroupBy(p => p.Id).Select(g =>
                    {
                        var projeto = g.First();
                        projeto.Tarefas = g.Select(p => p.Tarefas.Single()).ToList();
                        return projeto;
                    }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return Projeto;
            }
        }
        public async Task<IEnumerable<Projeto>> GetAllEntities()
        {
            var connectionString = this.GetConnection();
            List<Projeto> Projetos = new List<Projeto>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    var result = new List<Projeto>();
                    con.Open();

                    var projetos =  con.Query<Projeto, Tarefa, Projeto>(
                             @"SELECT   
                                        PRO.Id
                                       ,PRO.Nome
                                       ,PRO.Nivel
                                       ,PRO.Status
                                       ,TAR.ProjetoId
                                       ,TAR.Id
                                       ,TAR.Nome
                                       ,TAR.Nivel
                                       ,TAR.Finalizada
                                       ,TAR.UsuarioResponsavelId
                                       ,TAR.DataConclusao 
                                FROM Projeto PRO LEFT JOIN Tarefa TAR  
                                ON PRO.Id = TAR.ProjetoId",
                             map: (projeto, tarefa) =>
                             {
                                 projeto.Tarefas = new List<Tarefa>();

                                 if (projeto.Tarefas != null)
                                     projeto.Tarefas.Add(tarefa);
                                 return projeto;
                             },
                            splitOn: "ProjetoId").Distinct().ToList();

                    return projetos.GroupBy(p => p.Id).Select(g =>
                    {
                        var projeto = g.First();
                        projeto.Tarefas = g.Select(p => p.Tarefas.Single()).ToList() ?? new List<Tarefa>();
                        return projeto;
                    });

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}

