using ADSProyect.Models;

namespace ADSProyect.Interfaces
{
    public interface IProfesor
    {
        public int AgregarProfesor(Profesor profesor);
        public int ActualizarProfesor(int IdProfesor, Profesor profesor);
        public List<Profesor> ObtenerProfesor();
        public Profesor ObtenerProfesorPorID(int IdProfesor);
        public bool EliminarProfesor(int IdProfesor);

    }
}
