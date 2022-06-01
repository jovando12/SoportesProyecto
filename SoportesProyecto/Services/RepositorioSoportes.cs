using System;
using SoportesProyecto.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SoportesProyecto.Services
{
	public interface IRepositorioSoportes
    {
		void RegistrarSoporte(RequerimientoSoporte requerimientoSoporte);


    }

	public class RepositorioSoportes : IRepositorioSoportes
	{
		private readonly string connectionString;

        

        public RepositorioSoportes(IConfiguration configuration)
		{
			connectionString = configuration.GetConnectionString("DefaultConnection");
		}

		public void RegistrarSoporte(RequerimientoSoporte requerimientoSoporte)
        {
			using (var conexion = new SqlConnection(connectionString))
            {
				conexion.Query($@"insert into RegistrarSoporte" +
					"(nombre_usuario, tipo_requerimiento, solicitante, area_departamento, comentar)"+
					"values" +
					"(nombre_usuario, tipo_requerimiento, solicitante, area_departamento, comentar )", requerimientoSoporte);
            }
        }

	}
}

