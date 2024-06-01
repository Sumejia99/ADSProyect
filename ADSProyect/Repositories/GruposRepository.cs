using ADSProyect.DB;
using ADSProyect.Interfaces;
using ADSProyect.Migrations;
using ADSProyect.Models;

namespace ADSProyect.Repositories
{
    public class GruposRepository : IGrupos
    {

        private readonly ApplicationDbContext applicationDbContext;

        public GruposRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarGrupo(int IdGrupo, Grupos grupos)
        {
            try
            {
                var item = applicationDbContext.Grupo.SingleOrDefault(x => x.IdGrupo == IdGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(grupos);

                applicationDbContext.SaveChanges();


                return IdGrupo;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int AgregarGrupo(Grupos grupos)
        {
            try
            {
                applicationDbContext.Grupo.Add(grupos);

                applicationDbContext.SaveChanges();

                return grupos.IdGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarGrupo(int IdGrupo)
        {
            try
            {
                var item = applicationDbContext.Grupo.SingleOrDefault(x => x.IdGrupo == IdGrupo);

                applicationDbContext.Grupo.Remove(item);

                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Grupos ObtenerGrupoPorID(int IdGrupo)
        {
            try
            {
                var grupo = applicationDbContext.Grupo.SingleOrDefault(x => x.IdGrupo == IdGrupo);

                return grupo;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Grupos> ObtenerTodosLosGrupos()
        {
            try
            {
                return applicationDbContext.Grupo.ToList();
            }
            catch
            {
                throw;
            }
        }

     
    }
}
