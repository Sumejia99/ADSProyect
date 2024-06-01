using ADSProyect.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProyect.Models
{
    [PrimaryKey(nameof(idMateria))]
    public class Materias
    {
        public int idMateria { get; set; }

        [Required (ErrorMessage = "El campo es requerido")]
        [MaxLength (length: 50, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres")]
        public string nombreMateria { get; set; }
    }
}
