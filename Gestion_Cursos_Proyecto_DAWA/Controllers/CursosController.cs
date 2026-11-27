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
            var curso = _cursosServices.GetCursoById(id);

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
            var nuevoCurso = _cursosServices.AgregarCurso(curso);
            return Created("", nuevoCurso);
        }

        // Put api/<CursosController>/5 Para actualizar un curso existente
        [HttpPut("{id}")]
        public IActionResult Put_Curso(int id, [FromBody] Curso curso_actualizado)
        {
            var curso = _cursosServices.ActualizarCurso(id, curso_actualizado);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // Delete api/<CursosController>/5 Para eliminar un curso existente
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultado = _cursosServices.EliminarCurso(id);
            if (!resultado)
            {
                return NotFound();
            }
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
