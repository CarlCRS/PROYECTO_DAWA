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
    }
}