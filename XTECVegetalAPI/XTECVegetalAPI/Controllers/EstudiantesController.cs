using Microsoft.AspNetCore.Http;
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
    public class EstudiantesController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var mongoDBService = new MongoDBService("Usuarios", "estudiantes", "mongodb://localhost:27017");
            var allEstudiantes = await mongoDBService.GetAllEstudiantes();

            return Json(allEstudiantes);
        }

        [HttpPost]
        public async Task Post([FromBody]EstudianteModel estudiante)
        {
            var mongoDBService = new MongoDBService("Usuarios", "estudiantes", "mongodb://localhost:27017");

            await mongoDBService.InsertEstudiante(estudiante);
        }
    }
}
