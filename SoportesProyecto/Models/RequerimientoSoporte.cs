using System.ComponentModel.DataAnnotations;
namespace SoportesProyecto.Models
{
    public class RequerimientoSoporte
	{
		
		public string? nombre_usuario { get; set; }
		[Required(ErrorMessage = "El Tipo de Requerimiento debe ser seleccionado")]
		public string? tipo_requerimiento { get; set; }
		[Required(ErrorMessage ="El campo de solicitante es requerido")]
		public string? solicitante { get; set; }
		[Required(ErrorMessage ="Por favor diga el area ubicacion de soporte")]
		public string? area_departamento { get; set; }
		public string? comentar { get; set; }
        //public bool opcion1 { get; set; }
        //public bool opcion2 { get; set; }
        //public bool opcion3 { get; set; }
    }
}

