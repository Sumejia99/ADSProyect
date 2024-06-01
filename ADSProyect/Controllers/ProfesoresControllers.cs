
using ADSProyect.Interfaces;
using ADSProyect.Models;
using ADSProyect.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ADSProyect.Controllers
{
    [Route("api/profesor/")]
    public class ProfesoresControllers : ControllerBase
    {
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;
        private readonly IProfesor profesor;

        public ProfesoresControllers(IProfesor profesor)
        {
            this.profesor = profesor;
        }

        [HttpGet("obtenerProfesor")]
        public ActionResult<List<Profesor>> ObtenerProfesor()
        {
            try
            {
                List<Profesor> listaProfesor = this.profesor.ObtenerProfesor();
                return Ok(listaProfesor);

            }
            catch (Exception)
            {
                throw;


            }

        }


        [HttpGet("obtenerProfesorPorID/{IdProfesor}")]
        public ActionResult<Profesor> ObtenerEstudiantePorId(int IdProfesor)
        {
            try
            {
                Profesor profesor = this.profesor.ObtenerProfesorPorID(IdProfesor);
                if (profesor != null)
                {
                    return Ok(profesor);
                }
                else
                {
                    pCodRespuesta = Constans.COD_ERROR;
                    pMensajeUsuario = "No se a encontrado ningun dato";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                    return NotFound(new { pCodRespuesta = "0000000", pMensajeUsuario, pMensajeTecnico });
                }

            }
            catch
            {

                throw;
            }
        }


        [HttpDelete("eliminarProfesor/{IdProfesor}")]
        public ActionResult<string> EliminarMateria(int IdProfesor)
        {
            try
            {
                bool eliminado = this.profesor.EliminarProfesor(IdProfesor);

                if (eliminado)
                {
                    pCodRespuesta = Constans.COD_EXITO;
                    pMensajeUsuario = "Eliminacion exitoso";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = Constans.COD_ERROR;
                    pMensajeUsuario = "Error inesperado al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }


                return Ok(new { pCodRespuesta = 000000, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {

                throw;
            }
        }

        [HttpPut("actualizarProfesor/{IdProfesor}")]
        public ActionResult<string> ActualizarProfesor(int IdProfesor, [FromBody] Profesor profesor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.ActualizarProfesor(IdProfesor, profesor);
                if (contador > 0)
                {
                    pCodRespuesta = Constans.COD_EXITO;
                    pMensajeUsuario = "actualizacion exitoso";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = Constans.COD_ERROR;
                    pMensajeUsuario = "Error inesperado al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }


                return Ok(new { pCodRespuesta = 000000, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {

                throw;
            }
        }

        [HttpPost("agregarProfesor")]
        public ActionResult<string> AgregarProfesor([FromBody] Profesor profesor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.AgregarProfesor(profesor);
                if (contador > 0)
                {
                    pCodRespuesta = Constans.COD_EXITO;
                    pMensajeUsuario = "Registro exitoso";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = Constans.COD_ERROR;
                    pMensajeUsuario = "Error inesperado al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }


                return Ok(new { pCodRespuesta = 000000, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {

                throw;
            }
        }



    }
}
