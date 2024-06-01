using ADSProyect.Interfaces;
using ADSProyect.Models;
using ADSProyect.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ADSProyect.Controllers
{
    [Route("api/grupo/")]
    public class GruposControllers : ControllerBase
    {
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;
        private readonly IGrupos grupos;

        public GruposControllers(IGrupos grupos)
        {
            this.grupos = grupos;
        }

        [HttpGet("obtenerGrupo")]
        public ActionResult<List<Grupos>> ObtenerGrupos()
        {
            try
            {
                List<Grupos> listGrupo= this.grupos.ObtenerTodosLosGrupos();
                return Ok(listGrupo);

            }
            catch (Exception)
            {
                throw;


            }

        }


        [HttpGet("obtenerGrupoPorID/{IdGrupo}")]
        public ActionResult<Grupos> ObtenerGrupoPorID(int IdGrupo)
        {
            try
            {

                Grupos grupo = this.grupos.ObtenerGrupoPorID(IdGrupo);
                if (grupo != null)
                {
                    return Ok(grupo);
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


        [HttpDelete("eliminarGrupo/{IdGrupo}")]
        public ActionResult<string> EliminarGrupo(int IdGrupo)
        {
            try
            {
                bool eliminado = this.grupos.EliminarGrupo(IdGrupo);

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

        [HttpPut("actualizarGrupo/{IdGrupo}")]
        public ActionResult<string> ActualizarGrupo(int IdGrupo, [FromBody] Grupos grupos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.grupos.ActualizarGrupo(IdGrupo, grupos);
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

        [HttpPost("agregarGrupo")]
        public ActionResult<string> AgregarGrupo([FromBody] Grupos grupos)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.grupos.AgregarGrupo(grupos);
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
