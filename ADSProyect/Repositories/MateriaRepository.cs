using ADSProyect.DB;
using ADSProyect.Interfaces;
using ADSProyect.Migrations;
using ADSProyect.Models;
using Materias = ADSProyect.Models.Materias;

namespace ADSProyect.Repositories
{
    public class MateriaRepository : IMaterias
    {
        private readonly ApplicationDbContext applicationDbContext;

        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int Actualizarmateria(int idMateria, Materias materia)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                applicationDbContext.Entry(item).CurrentValues.SetValues(materia);

                applicationDbContext.SaveChanges();
                return idMateria;

            }catch (Exception)
            {
                throw;
            }
        }


        public int AgregarMateria(Materias materia)
        {
            try
            {
                applicationDbContext.Materias.Add(materia);

                applicationDbContext.SaveChanges();

                return materia.idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool EliminarMateria(int idMateria)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                applicationDbContext.Remove(item);

                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Materias ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                var materia = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                return materia;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Materias> ObtenerMaterias()
        {
            try
            {
                return applicationDbContext.Materias.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
