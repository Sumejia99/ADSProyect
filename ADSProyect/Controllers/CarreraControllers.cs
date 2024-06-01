using ADSProyect.Models;
using Microsoft.AspNetCore.Mvc;
using ADSProyect.Interfaces;
using ADSProyect.Utilities;
using System.Collections.Generic;

namespace ADSProyect.Controllers
{
    [Route("/apis/Carrera")]
    public class CarreraControllers : ControllerBase
    {
        private readonly ICarrera carrera;
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public CarreraControllers(ICarrera carrera)
        {
            this.carrera = carrera;
        }

        [HttpPost("agregarCarrera")]
        public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int contador = this.carrera.AgregarCarrera(carrera);
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


                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {

                throw;
            }
        }

        [HttpPut("actualizarCarrera/{idCarrera}")]
        public ActionResult<string> ActualizarCarrera(int idCarrera,[FromBody] Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int contador = this.carrera.ActualizarCarrera(idCarrera, carrera);
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

        [HttpDelete("eliminarCarrera/{idCarrera}")]
        public ActionResult<string> EliminarCarrera(int idCarrera)
        {
            try
            {
                bool eliminado = this.carrera.EliminarCarrera(idCarrera);

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


        [HttpGet("obtenerTodasLasCarrerasPorID/{idCarrera}")]
        public ActionResult<string> ObtenerTodasLasCarrerasPorID(int idCarrera)
        {
            try
            {
                Carrera carreras = this.carrera.ObtenerTodasLasCarrerasPorID(idCarrera);
                if (carreras != null)
                {
                    return Ok(carreras);
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


        [HttpGet("obtenerCarrera")]
        public ActionResult<List<Carrera>> ObtenerCarrera()
        {
            try
            {
                List<Carrera> lstcarreras = this.carrera.ObtenerCarreras();
                return Ok(lstcarreras);
            }
            catch
            {
                throw;
            }
        }


    }// fin de codigo
}
