using Dapper;
using Microsoft.Extensions.Configuration;
using projetoeclipseworks.Dados.Entidades;
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
                return count >=1;
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
                    var query = $"SELECT * FROM dbo.Projeto WHERE Id ='{id}'";
                    Projeto = con.Query<Projeto>(query).FirstOrDefault();
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
                    con.Open();
                    var query = "SELECT * FROM dbo.Projeto";
                    Projetos = con.Query<Projeto>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return Projetos;
            }
        }
    }
}

