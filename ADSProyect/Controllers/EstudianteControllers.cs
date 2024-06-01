using Microsoft.AspNetCore.Mvc;
using ADSProyect.Interfaces;
using System.Collections.Generic;
using ADSProyect.Models;
using ADSProyect.Utilities;

namespace ADSProyect.Controllers
{
    [Route("/api/Estudiante")]
    public class EstudianteControllers : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public EstudianteControllers(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }


        [HttpPost("agregarEstudiante")]
        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            int contador = this.estudiante.AgregarEstudiante(estudiante);
                if(contador > 0) {
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


            return Ok(new {pCodRespuesta, pMensajeUsuario, pMensajeTecnico});
            }catch {

                throw;
            }
        }


        [HttpPut("actualizarEstudiante/{idEstudiante}")]
        public ActionResult<string> ActualizarEstudiante(int idEstudiante,[FromBody] Estudiante estudiante)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante, estudiante);
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


                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {

                throw;
            }
        }

        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                bool eliminado = this.estudiante.EliminarEstudiante(idEstudiante);

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


                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {

                throw;
            }
        }


        [HttpGet("obtenerEstudiantePorID/{idEstudiante}")]
        public ActionResult<string> ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = this.estudiante.ObtenerEstudiantePorID(idEstudiante);
                if (estudiante != null)
                {
                   return Ok(estudiante);
                }
                else
                {
                    pCodRespuesta = Constans.COD_ERROR;
                    pMensajeUsuario = "No se a encontrado ningun dato";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }

            }
            catch
            {

                throw;
            }
        }


        [HttpGet("obtenerEstudiante")]
        public ActionResult<List<Estudiante>> ObtenerEstudiante()
        {
            try
            {
                List <Estudiante> lstEstudiantes = this.estudiante.ObtenerTodosLosEstudiantes();
                    return Ok(lstEstudiantes);
            }
            catch
            {
                throw;
            }
        }


    }//fin del codigo
}
