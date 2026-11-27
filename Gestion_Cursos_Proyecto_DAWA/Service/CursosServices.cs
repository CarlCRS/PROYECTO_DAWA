using Gestion_Cursos_Proyecto_DAWA.Entity;

namespace Gestion_Cursos_Proyecto_DAWA.Service
{
    public class CursosServices
    {

        private static readonly List<Curso> _cursos = new List<Curso>
        {
            new Curso { Id = 1, 
                        Nombre = "CALIDAD DE SOFTWARE", 
                        Docente = "Tania Peralta - calidad/precio chayomi ", 
                        Activo = true 
                        },
            new Curso { Id = 2, 
                        Nombre = "INTELIGENCIA DE NEGOCIOS", 
                        Docente = " Silvia Tejada - La viejita de Inteligencia", 
                        Activo = true 
                        },
            new Curso { Id = 3, 
                        Nombre = "MARCO LEGAL DE LA PROFESIÓN", 
                        Docente = "Luis Merchan - El loco de Elibro", 
                        Activo = false 
                        },
        };

        public List<Curso> GetCursos()
        {
            return _cursos;
        }

        public Curso GetCursoById(int id)
        {  
            return _cursos.FirstOrDefault(c => c.Id == id);
        }

        public Curso AgregarCurso(Curso nuevoCurso)
        {
            nuevoCurso.Id = _cursos.Count > 0 ? _cursos.Max(c => c.Id) + 1 : 1 ;
            _cursos.Add(nuevoCurso);
            return nuevoCurso;
        }


        public Curso? ActualizarCurso(int id, Curso cursoActualizado)
        {
            var curso = GetCursoById(id);
            if (curso == null) 
            {
                return null;
            }
            curso.Nombre = cursoActualizado.Nombre;
            curso.Docente = cursoActualizado.Docente;
            curso.Activo = cursoActualizado.Activo;

            return curso;
        }

        public bool EliminarCurso(int id)
        {
            var curso = GetCursoById(id);
            if (curso == null)
            {
                return false;
            }
            _cursos.Remove(curso);
            return true;
        }


    }
}