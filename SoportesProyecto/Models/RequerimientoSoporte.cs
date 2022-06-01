using System;
namespace SoportesProyecto.Models
{
	public class RequerimientoSoporte
	{
		
		public string? nombre_usuario { get; set; }
		public string? tipo_requerimiento { get; set; }
		public string? solicitante { get; set; }
		public string? area_departamento { get; set; }
		public string? comentar { get; set; }
		public bool opcion1 { get; set; }
		public bool opcion2 { get; set; }
		public bool opcion3 { get; set; }
	}
}

