using Microsoft.AspNetCore.Mvc;

namespace TP09_API.Controllers;

using TP09_API.Models;

[ApiController]

[Route("[controller]")]
public class EquiposController : ControllerBase
{   
    [HttpGet]
    public IActionResult Get(){
        List<Equipo> lista = BD.ListarEquipos();
        return Ok(lista);
    }

    [HttpGet("(IdEquipo)")]

    public IActionResult Get(int IdLiga){


        if(IdLiga<1){
            return BadRequest();
        }
        lista = BD.ListarEquipos(IdLiga);
        if(lista==null)
        {
            return NotFound();
        }
        return Ok();
    }
    [HttpDelete("(id)")]
    public IActionResult Delete(int id){
        if(id<1){
            return BadRequest();
        }
        Equipo c = BD.ObtenerCategorias(id);
        if(c==null)
        {
            return NotFound();
        }
        return Ok(c);
    }
    [HttpPost]
    public IActionResult Post(Equipo c){
        if(c.Nombre == null || c.Nombre == "")
        {
            return BadRequest();
        }

        BD.InsertarEquipo(c);
        return Ok();
    }
}
