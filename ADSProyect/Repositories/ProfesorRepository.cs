using ADSProyect.DB;
using ADSProyect.Interfaces;
using ADSProyect.Migrations;
using ADSProyect.Models;
using Profesor = ADSProyect.Models.Profesor;

namespace ADSProyect.Repositories
{
    public class ProfesorRepository : IProfesor
    {

        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarProfesor(int IdProfesor, Profesor nuevoProfesor)
        {
            try
            {
                // Buscar el profesor a actualizar
                var profesor = applicationDbContext.Profesor.SingleOrDefault(x => x.IdProfesor == IdProfesor);
                if (profesor == null)
                {
                    throw new Exception("Profesor no encontrado");
                }

                // Actualizar las propiedades del profesor encontrado con los valores del nuevoProfesor
                profesor.NombreProfesor = nuevoProfesor.NombreProfesor;
                profesor.ApellidoProfesor = nuevoProfesor.ApellidoProfesor;
                profesor.Email = nuevoProfesor.Email;

                // Guardar los cambios en la base de datos
                applicationDbContext.SaveChanges();

                return IdProfesor;
            }
            catch (Exception e)
            {
                throw new Exception("Error al actualizar el profesor", e);
            }
        }


        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                applicationDbContext.Profesor.Add(profesor);

                applicationDbContext.SaveChanges();

                return profesor.IdProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public bool EliminarProfesor(int IdProfesor)
        {
            try
            {
                var item = applicationDbContext.Profesor.SingleOrDefault(x => x.IdProfesor == IdProfesor);

                applicationDbContext.Profesor.Remove(item);

                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Profesor> ObtenerProfesor()
        {
            try
            {
                return applicationDbContext.Profesor.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Profesor ObtenerProfesorPorID(int IdProfesor)
        {
            try
            {
                var profe = applicationDbContext.Profesor.SingleOrDefault(x => x.IdProfesor == IdProfesor);


                return profe;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
