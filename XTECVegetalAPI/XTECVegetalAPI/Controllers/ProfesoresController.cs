using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XTECVegetalAPI.Models;
using XTECVegetalAPI.Services;

namespace XTECVegetalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var mongoDBService = new MongoDBService("Usuarios", "profesores", "mongodb://localhost:27017","p");
            var allProfes = await mongoDBService.GetAllProfes();

            return Json(allProfes);
        }

        [HttpPost]
        public async Task Post([FromBody] ProfesorModel profe)
        {
            var mongoDBService = new MongoDBService("Usuarios", "profesores", "mongodb://localhost:27017","p");

            await mongoDBService.InsertProfe(profe);
        }
    }
}
