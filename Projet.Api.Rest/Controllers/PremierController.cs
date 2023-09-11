using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet.Api.Rest.Models;

namespace Projet.Api.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremierController : ControllerBase
    {
        //On crée la variable qui accede èa la database context
        private readonly DatabaseContext _databaseContext;

        //Injection de dépendance de dataBaseContext
        public PremierController(DatabaseContext databaseContext)
        {
            //Injection de dépendance
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemModel>>> Get()
        {
            var result = await _databaseContext.ItemModels.ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<ItemModel>>> Post(ItemModel item)
        {
            _databaseContext.ItemModels.Add(item);
            await _databaseContext.SaveChangesAsync();
            return CreatedAtAction("Post", item);
        }
        //private readonly DatabaseContext _context;

        //public PremierController(DatabaseContext context)
        //{
        //    //injection de dépendances
        //    _context = context;
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<ItemModel>>> Get()
        //{
        //    var result = await _context.ItemModels.ToListAsync();
        //    return Ok(result);
        //    //return Ok(items);
        //}

        //[HttpGet("{name}")]
        //public async Task<ActionResult<ItemModel>> Get(string name)
        //{
        //    var item = await _context.ItemModels.FindAsync(name);
        //    if (item == null) 
        //        return BadRequest("pas d'item trouvé !");

        //    return Ok(item);
        //}

        //[HttpPost]
        //public async Task<ActionResult<ItemModel>> Post(ItemModel model)
        //{
        //    _context.ItemModels.Add(model);
        //    await _context.SaveChangesAsync();

        //    //items.Add(model);
        //    return CreatedAtAction("POST", model);
        //}

        //[HttpPut]
        //public async Task<ActionResult<ItemModel>> Put(string name,ItemModel model)
        //{
        //    if (model.Name != name)
        //        return BadRequest("L'élément n'existe pas");


        //    _context.Entry(model).State = EntityState.Modified;

        //    await _context.SaveChangesAsync();

        //    return Ok(model);    
        //}

        //[HttpDelete]
        //public async Task<ActionResult<ItemModel>> Delete(string name)
        //{
        //    var item = await _context.ItemModels.FindAsync(name);
        //    if (item == null)
        //        return BadRequest("pas d'item trouvé !");

        //    _context.ItemModels.Remove(item);
        //    await _context.SaveChangesAsync();

        //    return Ok(item);
        //}
    }
}
