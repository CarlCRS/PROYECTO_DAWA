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

        // GET api/<CursosController>/5
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

        // PUT api/<CursosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Curso curso)
        {
            var cursoExistente = _cursosServices.GetCursos().FirstOrDefault(c => c.Id == id);
            if (cursoExistente == null)
            {
                return NotFound();
            }
            cursoExistente.Nombre = curso.Nombre;
            cursoExistente.Docente = curso.Docente;
            cursoExistente.Activo = curso.Activo;
            return Ok(cursoExistente);
        }

        // DELETE api/<CursosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cursoExistente = _cursosServices.GetCursos().FirstOrDefault(c => c.Id == id);
            if (cursoExistente == null)
            {
                return NotFound();
            }
            _cursosServices.GetCursos().Remove(cursoExistente);
            return Ok("Eliminado Exitosamente");
        }
    }
}
