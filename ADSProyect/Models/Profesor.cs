using ADSProyect.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProyect.Models
{
    [PrimaryKey(nameof(IdProfesor))]
    public class Profesor
    {
        public int IdProfesor { get; set; }

        [Required (ErrorMessage = "Este campo es requerido")]
        [MaxLength (length:50 , ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres")]
        public string NombreProfesor { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(length: 50, ErrorMessage = "La longitud del campo no puede ser mayor a 50 caracteres")]
        public string ApellidoProfesor { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(length: 254, ErrorMessage = "La longitud del campo no puede ser mayor a 254 caracteres")]
        [EmailAddress (ErrorMessage = "El formato del correo electronico no es el correcto")]
        public string Email { get; set; }
        

    }
}
