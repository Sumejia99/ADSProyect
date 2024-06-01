using ADSProyect.Models;
using ADSProyect.Interfaces;
using ADSProyect.DB;

namespace ADSProyect.Repositories
{
    public class EstudianteRepository : IEstudiante
    {

        private readonly ApplicationDbContext applicationDbContext;

        public EstudianteRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {

            try
            {
                var item = applicationDbContext.Estudiante.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                applicationDbContext.Entry(item).CurrentValues.SetValues(estudiante);

                applicationDbContext.SaveChanges();

                return idEstudiante;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public int AgregarEstudiante(Estudiante estudiante)
        {
            try { 
                
                applicationDbContext.Estudiante.Add(estudiante);

                applicationDbContext.SaveChanges();

                return estudiante.IdEstudiante;

            }catch(Exception )
            {
                throw; 
            }

        }

        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                var item = applicationDbContext.Estudiante.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                applicationDbContext.Estudiante.Remove(item);

                applicationDbContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                var estudiante = applicationDbContext.Estudiante.SingleOrDefault(x => x.IdEstudiante == idEstudiante);


                return estudiante;

            }
            catch (Exception e)
            {
                throw;
            }

        }
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                return applicationDbContext.Estudiante.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
