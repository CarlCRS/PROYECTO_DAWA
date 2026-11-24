using Gestion_Cursos_Proyecto_DAWA.Entity;
using Gestion_Cursos_Proyecto_DAWA.Service;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Cursos_Proyecto_DAWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        //Inyeccion del service
        private readonly CursosServices _cursosServices;

        public CursosController(CursosServices servicecurso) {
            _cursosServices = servicecurso;
        }

        // GET: api/<CursosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cursosServices.GetCursos());
        }

        // GET apiPorId/<CursosController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var curso = _cursosServices.GetCursos().FirstOrDefault(c => c.Id == id);

            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }

        //Metodos vistos en clase
        // Post api/<CursosController> Para crear un nuevo curso
        // FromBody indica que el curso se enviará en el cuerpo de la solicitud HTTP
        [HttpPost]
        public IActionResult Post_Curso([FromBody] Curso curso)
        {
            curso.Id = _cursosServices.GetCursos().Count + 1; //Count cuenta desde 1
            _cursosServices.GetCursos().Add(curso);
            return Created("", curso);
        }

        // Put api/<CursosController>/5 Para actualizar un curso existente
        [HttpPut("{id}")]
        public IActionResult Put_Curso(int id, [FromBody] Curso curso_actualizado)
        {
            var curso = _cursosServices.GetCursos().FirstOrDefault(c => c.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            curso.Nombre = curso_actualizado.Nombre;
            curso.Docente = curso_actualizado.Docente;
            curso.Activo = curso_actualizado.Activo;
            return Ok(curso);
        }

        // Delete api/<CursosController>/5 Para eliminar un curso existente
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cursoExistente = _cursosServices.GetCursos().FirstOrDefault(c => c.Id == id);
            if (cursoExistente == null)
            {
                return NotFound();
            }
            _cursosServices.GetCursos().Remove(cursoExistente);
            return Ok("Curso eliminado exitosamente");
        }

        //Metodos Propios
        /*
        // POST api/<CursosController>
        [HttpPost]
        public IActionResult Post([FromBody] Curso curso)
        {
            curso.Id = _cursosServices.GetCursos().Count > 0
                ? _cursosServices.GetCursos().Max(c => c.Id) + 1
                : 1;
            _cursosServices.GetCursos().Add(curso);
            return Created("", curso);
        }
        */
    }
}
