using System;
using SoportesProyecto.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace SoportesProyecto.Services
{
	public interface IRepositorioSoportes
    {
		Task RegistrarSoporte(RequerimientoSoporte requerimientoSoporte);
        Task <IEnumerable<RequerimientoSoporte>> GetSupport();

    }

	public class RepositorioSoportes : IRepositorioSoportes
	{
		private readonly string connectionString;

        

        public RepositorioSoportes(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public async Task RegistrarSoporte(RequerimientoSoporte requerimientoSoporte)
        {
			using (var conexion = new SqlConnection(connectionString))
            {
                try
                {
                   await conexion.ExecuteAsync($@"insert into RegistrarSoporte" +
                   "(nombre_usuario, tipo_requerimiento, solicitante, area_departamento, comentar)" +
                   "values" +
                   "(@nombre_usuario, @tipo_requerimiento, @solicitante, @area_departamento, @comentar )", requerimientoSoporte);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Test");
                }
               

            }
        }
        public async Task<IEnumerable<RequerimientoSoporte>> GetSupport()
        {
            using var conexion = new SqlConnection(connectionString);
            return await conexion.QueryAsync<RequerimientoSoporte>(@"Select * from RegistrarSoporte");
        }

     

	}
}

