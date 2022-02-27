using ApiProjetoFluentValidation.Core.Interfaces.Infra.Repository;
using ApiProjetoFluentValidation.Core.Models;
using Dapper;
using Microsoft.Extensions.Options;
using ProjetoFluentValidation.Data.Config;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjetoFluentValidation.Data.Repository
{
    public class PlantaRepository : IPlantaRepository
    {
        protected readonly DatabaseConfig _dbConfig;
        public PlantaRepository(IOptions<DatabaseConfig> config)
        {
            _dbConfig = config.Value;
        }

        public async Task<IEnumerable<Planta>> ObterAsync()
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {

                return await dbConnection.QueryAsync<Planta>(@"SELECT ID,nome,luzdiaria,agua,peso
                                                              FROM dbo.planta");
            }

        }

        public async Task<Planta> ObterPorIdAsync(int id)
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {

                return await dbConnection.QueryFirstOrDefaultAsync<Planta>(@"SELECT ID,nome,luzdiaria,agua,peso
                                                              FROM dbo.planta
                                                              where ID = @id",
                    new { id });
            }
        }
        public async Task<Planta> ObterPorNomeAsync(string nome)
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {

                return await dbConnection.QueryFirstOrDefaultAsync<Planta>(@"SELECT ID,nome,luzdiaria,agua,peso
                                                              FROM dbo.planta
                                                              where nome = @nome",
                    new { nome });
            }
        }
        public async Task<int> CriarAsync(Planta planta)
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {
                return await dbConnection.ExecuteScalarAsync<int>(
                      @"INSERT INTO dbo.planta(nome,luzdiaria,agua,peso)
                        VALUES(@nome,@luzdiaria,@agua,@peso);
                      SELECT CAST(SCOPE_IDENTITY() as int)",
                      new { planta.nome, planta.luzdiaria, planta.agua, planta.peso });
            }
        }
        public async Task AlterarAguaAsync(int id, int agua)
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {
                await dbConnection.ExecuteAsync(
                    @"UPDATE dbo.planta 
                    SET 
                        agua = @agua
                    WHERE
                        ID = @id",
                    new { agua, id });
            }
        }

        public async Task AlterarLuzDiariaAsync(int id, int luzdiaria)
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {
                await dbConnection.ExecuteAsync(
                    @"UPDATE dbo.planta 
                    SET 
                        luzdiaria = @luzdiaria
                    WHERE
                        ID = @id",
                    new { luzdiaria, id });
            }
        }

        public async Task AlterarNomeAsync(int id, string nome)
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {
                await dbConnection.ExecuteAsync(
                    @"UPDATE dbo.planta 
                    SET 
                        nome = @nome
                    WHERE
                        ID = @id",
                    new { nome, id });
            }
        }

        public async Task AlterarPesoAsync(int id, int peso)
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {
                await dbConnection.ExecuteAsync(
                    @"UPDATE dbo.planta 
                    SET 
                        peso = @peso
                    WHERE
                        ID = @id",
                    new { peso, id });
            }
        }

        public async Task RemoverAsync(int id)
        {
            using (var dbConnection = new SqlConnection(_dbConfig.BancoDados))
            {
                await dbConnection.ExecuteAsync(
                    @"DELETE FROM dbo.planta 
                      WHERE ID = @id",
                    new { id });
            }
        }
    }
}
