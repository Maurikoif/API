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
        if(l.Nombre == null || l.Nombre == "" || l.Logo == null || l.Logo == ""){
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
        Liga l = BD.ObtenerLigaPorId(e.IdLiga);
        if(l.Nombre == null || l.Nombre == "" || l.Logo == null || l.Logo == ""){
            return NotFound();
        }

        if(e.Nombre == null || e.Nombre == "" || e.Escudo == null || e.Escudo == "")
        {
            return BadRequest();
        }

        BD.AgregarEquipo(e);
        return Ok();
    }
    [HttpPut("(id)")]
    public IActionResult Put(int id, Equipo e){
        if(id<1){
            return BadRequest();
        }

        Liga l = BD.ObtenerLigaPorId(e.IdLiga);
        if(l.Nombre == null || l.Nombre == "" || l.Logo == null || l.Logo == ""){
            return NotFound();
        }

        if(e.Nombre == null || e.Nombre == "" || e.Escudo == null || e.Escudo == "")
        {
            return BadRequest();
        }
        e.IdEquipo = id;
        BD.UpdateEquipo(e);
        return Ok();

    }
    [HttpPatch("(id)")]
    public IActionResult Patch(int id, Equipo eNuevo){
        if(id<1){
            return BadRequest();
        }
        Liga l = BD.ObtenerLigaPorId(eNuevo.IdLiga);
        if(l.Nombre == null || l.Nombre == "" || l.Logo == null || l.Logo == ""){
            return NotFound();
        }
        Equipo eViejo = BD.VerInfoEquipo(id);
        if(eNuevo.Nombre != null || eNuevo.Nombre != eViejo.Nombre)
        {
            eViejo.Nombre = eNuevo.Nombre;
        }
        if(eNuevo.Escudo != null || eNuevo.Escudo != eViejo.Nombre)
        {
            eViejo.Escudo = eNuevo.Escudo;
        }
        BD.UpdateEquipo(eViejo);
        return Ok();
    }
}
