using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Infrastructure.Repository;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Enums;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Repository.Dapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.Repositories
{
    public class DashboardRepository<TContext> : RepositoryBase<TContext, Gasto, int>, IDashboardRepository<TContext>
                                where TContext : IUnitOfWork<TContext>
    {
        private DbSession _dbSession;
        public DashboardRepository(IUnitOfWork<TContext> unitOfWork,
                                   DbSession dbSession) : base(unitOfWork)
        {
            _dbSession = dbSession;
        }

        public async Task<IEnumerable<DashboardDto>> GetDashboard(int usuarioId, DateTime dataInicial, DateTime dataFinal)
        {
            using (var conn = _dbSession.Connection)
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@UsuarioId", usuarioId, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@DataInicial", dataInicial, DbType.Date, ParameterDirection.Input);
                parameter.Add("@DataFinal", dataFinal, DbType.Date, ParameterDirection.Input);

                string query = "GetDashboard";

                return await (conn.QueryAsync<DashboardDto>(sql: query, param: parameter, commandType: CommandType.StoredProcedure));
            }
        }
    }
}
