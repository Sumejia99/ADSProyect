using System.ComponentModel.DataAnnotations;
using ADSProyect.Validations;
using Microsoft.EntityFrameworkCore;
namespace ADSProyect.Models
{
    [PrimaryKey(nameof(IdGrupo))]
    public class Grupos
    {
        [CustomRequired(ErrorMessage = "Este campo es requerido y debe ser mayor que 0")]
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int IdCarrera { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Ciclo { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Anio { get; set; }

    }
}
