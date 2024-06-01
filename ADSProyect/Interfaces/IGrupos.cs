using ADSProyect.Models;

namespace ADSProyect.Interfaces
{
    public interface IGrupos
    {
        public int AgregarGrupo(Grupos grupos);
        public int ActualizarGrupo(int IdGrupo, Grupos grupos);
        public bool EliminarGrupo(int IdGrupo);
        public List<Grupos> ObtenerTodosLosGrupos();
        public Grupos ObtenerGrupoPorID(int IdGrupo);

    }
}
