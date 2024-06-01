using ADSProyect.Interfaces;
using ADSProyect.Models;
using ADSProyect.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ADSProyect.Controllers
{
    [Route("/apis/Materias/")]
    public class MateriaControllers : ControllerBase
    {
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;
        private readonly IMaterias materias;

        public MateriaControllers(IMaterias materias)
        {
            this.materias = materias; 
        }


        [HttpGet("obtenerMaterias")]
        public ActionResult<List<Materias>> ObtenerMaterias() 
        {
            try
            {
                List<Materias> listMaterias = this.materias.ObtenerMaterias();
                return Ok(listMaterias);

            }catch (Exception)
            {
                throw;
            

            }

        }


        [HttpGet("obtenerMateriaPorID/{idMateria}")]
        public ActionResult<Materias> ObtenerEstudiantePorId(int idMateria)
        {
            try
            {
                Materias materia = this.materias.ObtenerMateriaPorID(idMateria);
                if (materia != null)
                {
                    return Ok(materia);
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


        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> EliminarMateria(int idMateria)
        {
            try
            {
                bool eliminado = this.materias.EliminarMateria(idMateria);

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

        [HttpPut("actualizarMateria/{idMateria}")]
        public ActionResult<string> ActualizarEstudiante(int idMateria, [FromBody] Materias materia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.materias.Actualizarmateria(idMateria, materia);
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

        [HttpPost("agregarMateria")]
        public ActionResult<string> AgregarMateria([FromBody] Materias materia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.materias.AgregarMateria(materia);
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



    }//fin del codigo

}


