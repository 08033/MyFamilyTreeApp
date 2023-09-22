using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFamilyTreeApp.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : Controller //ControllerBase
    {
        private readonly FamilyTreeContext _dbContext;

        public ValuesController(FamilyTreeContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        //public IEnumerable<string> Get()
        public IActionResult Index()
        {
            var lst = _dbContext.AllPeople.ToList();
            //return new string[] { "value1", "value2" };
            return View(lst);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("Details/{id}")]
        //[ActionName("Details")]
        public IActionResult Details(int id)
        {
            //var obj = _dbContext.AllPeople.ToList();            
            var obj = _dbContext.AllPeople.Where(item => item.Id == id).FirstOrDefault();
            return View(obj);            
            //return Json(obj);
        }

        
        [HttpGet("Edit/{id}")]
        //[ActionName("Edit")]
        public IActionResult Edit(int id)
        {
            //var obj = _dbContext.AllPeople.ToList();            
            var obj = _dbContext.AllPeople.Where(item => item.Id == id).ToList();
            //return View(obj);
            return Json(obj);
        }

        //Create routes:
        [HttpGet("Create")]        
        public IActionResult create()
        {
            IEnumerable<Person> fathers = _dbContext.People.Where(p => p.Gender == "M").ToList();
            IEnumerable<Person> mothers = _dbContext.People.Where(p => p.Gender == "F").ToList();
            ViewData["fathers"] = fathers;
            ViewData["mothers"] = mothers;
            return View();
        }

        [HttpPost("Create")]
        //public IActionResult create([FromForm] Person person) //<form> tag
        public IActionResult create([FromBody] Person person) //JQuery AJAX POST request
        {
            _dbContext.People.Add(person);
            int rowsAffected = _dbContext.SaveChanges();
            //return RedirectToAction("Index"); //with <form>            
            return Json(rowsAffected); //JQuery request
        }

    }
}
