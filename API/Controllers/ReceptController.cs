using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ReceptController : ControllerBase
    {
        Models.ReceptContext context = new();

        [HttpGet]
        [Route("fogasok/all")]
        public IActionResult elso()
        {
            var fogasok = from x in context.Fogasok
                          select x;

            return Ok(fogasok.ToList());
        }

        [HttpGet]
        [Route("fogasok/{i}")]
        public IActionResult masodik(int i)
        {
            var fogas = (from x in context.Fogasok
                          where x.FogasId == i
                          select x).FirstOrDefault();

            if (fogas == null) return BadRequest("Nincs ilyen sorszám");
            else return Ok(fogas);
        }

        [HttpGet]
        [Route("nyersanyagok/{i}")]
        public IActionResult harmadik(int i)
        {
            var nyersanyag = (from x in context.Nyersanyagok
                         where x.NyersanyagId == i
                         select x).FirstOrDefault();

            if (nyersanyag == null) return BadRequest("Nincs ilyen sorszám");
            else return Ok(nyersanyag);
        }
    }
}
