using ADSProyect.Models;

namespace ADSProyect.Interfaces
{
    public interface IMaterias
    {
        public int AgregarMateria(Materias materia);
        public int Actualizarmateria(int idMateria, Materias materia);

        public List<Materias> ObtenerMaterias();

        public Materias ObtenerMateriaPorID(int idMateria);
        public bool EliminarMateria(int idMateria);
    }
}
