
using ADSProyect.DB;
using ADSProyect.Interfaces;
using ADSProyect.Models;
namespace ADSProyect.Repositories
{
    public class CarreraRepository : ICarrera
    {

        private readonly ApplicationDbContext applicationDbContext;

        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarCarrera(int IdCarrera, Carrera carrera)
        {
            try
            {

                ///Implemente este metodo, ya que en el de la guia me daba error al actualizar carrera 
                var item = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == IdCarrera);
                if (item == null)
                {
                    throw new Exception("Carrera no encontrada");
                }

                var carreraActualizada = new Carrera
                {
                    IdCarrera = item.IdCarrera, 
                    Codigo = carrera.Codigo,
                    Nombre = carrera.Nombre
                };

                applicationDbContext.Entry(item).CurrentValues.SetValues(carreraActualizada);
                applicationDbContext.SaveChanges();

                return IdCarrera;
            }
            catch (Exception e)
            {
                throw new Exception("Error al actualizar la carrera", e);
            }
        }


        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                applicationDbContext.Carrera.Add(carrera);

                applicationDbContext.SaveChanges();

                return carrera.IdCarrera;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int IdCarrera)
        {
            try
            {
                var item = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == IdCarrera);
                applicationDbContext.Remove(item);
                applicationDbContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public Carrera ObtenerTodasLasCarrerasPorID(int IdCarrera)
        {
            try
            {
                
                var carrera = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == IdCarrera);

                return carrera;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Carrera> ObtenerCarreras()
        {
            try
            {
                return applicationDbContext.Carrera.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
