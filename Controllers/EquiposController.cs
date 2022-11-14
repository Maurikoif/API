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

    [HttpGet("(id)")]

    public IActionResult Get(int id){
        if(id<1){
            return BadRequest();
        }
        Liga l = BD.ObtenerLigaPorId(id);
        if(l == null){
            return NotFound();
        }
        List<Equipo> lista = BD.ListarEquipos(id);
        if(lista==null)
        {
            return NotFound();
        }
        return Ok(lista);
    }
    [HttpDelete("(id)")]
    public IActionResult Delete(int id){
        if(id<1){
            return BadRequest();
        }
        List<Equipo> lista = BD.ListarEquipos(id);
        if(lista==null)
        {
            return NotFound();
        }
        BD.BorrarEquipo(id);
        return Ok(lista);
    }
    [HttpPost]
    public IActionResult Post(Equipo e){
        if(e.Nombre == null || e.Nombre == "")
        {
            return BadRequest();
        }

        BD.AgregarEquipo(e);
        return Ok();
    }
}
