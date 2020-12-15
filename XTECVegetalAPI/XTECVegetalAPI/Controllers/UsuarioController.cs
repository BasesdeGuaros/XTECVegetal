using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XTECVegetalAPI.Models;
using XTECVegetalAPI.Models.Reply;
using XTECVegetalAPI.Models.Request;

namespace XTECVegetalAPI.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //IActionResult es una inteface
        [HttpGet] //protocolo get
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            Reply reply = new Reply();
            try
            {
                //el codigo se elimina una vez ejecutado lo que tenga dentro del using()
                using (XTECDigitalContext db = new XTECDigitalContext()) //coneccion a la base de datos
                {
                    var list = db.Usuarios
                        .ToList(); //variable con la lista de datos de la tabla
                    reply.conexionSuccess = 1;
                    reply.data = list;
                }
            }
            catch (Exception ex)
            {
                reply.conexionSuccess = 0;
                reply.message = ex.Message;
            }
            return Ok(reply); //convierte la lista a Json
        }

       /*
        [HttpGet] //protocolo get
        [Route("api/userproducer")]
        public IActionResult GetProd(string rol)
        {
            Reply reply = new Reply();
            try
            {
                //el codigo se elimina una vez ejecutado lo que tenga dentro del using()
                using (TareaCorta1Context db = new TareaCorta1Context()) //coneccion a la base de datos
                {
                    var list = db.User
                        .Where(a => a.Rol == "producer")
                        .Include(a => a.Producers)
                        .ToList(); //variable con la lista de datos de la tabla 
                    reply.conexionSuccess = 1;
                    reply.data = list;
                }
            }
            catch (Exception ex)
            {
                reply.conexionSuccess = 0;
                reply.message = ex.Message;
            }
            return Ok(reply); //convierte la lista a Json
        }
       */

        [HttpPost] //protocolo Post
        [Route("api/[controller]")]
        public IActionResult Post(UsuarioRequest request)
        {
            Reply reply = new Reply();

            try
            {
                using (XTECDigitalContext db = new XTECDigitalContext())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdRol = request.IdRol;
                    usuario.Id = request.Id;

                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    reply.conexionSuccess = 1;
                    reply.message = "Usuario agregado";

                }
            }
            catch (Exception ex)
            {
                reply.conexionSuccess = 0;
                reply.message = ex.Message;
            }

            return Ok(reply);
        }

        [HttpPut] //protocolo Put (editar)
        [Route("api/[controller]")]
        public IActionResult Put(UsuarioRequest request)
        {
            Reply reply = new Reply();

            try
            {
                using (XTECDigitalContext db = new XTECDigitalContext())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdRol = request.IdRol;
                    usuario.Id = request.Id;

                    db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //le dice a la base de datos que se ha modificado  
                    db.SaveChanges();
                    reply.conexionSuccess = 1;
                    reply.message = "Usuario editado";

                }
            }
            catch (Exception ex)
            {
                reply.conexionSuccess = 0;
                reply.message = ex.Message;
            }

            return Ok(reply);
        }


        //protocolo Delete
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            Reply reply = new Reply();

            try
            {
                using (XTECDigitalContext db = new XTECDigitalContext())
                {
                    Usuario user = db.Usuarios.Find(id);
                    db.Remove(user);
                    db.SaveChanges();
                    reply.conexionSuccess = 1;
                    reply.message = "Usuario eliminado";

                }
            }
            catch (Exception ex)
            {
                reply.conexionSuccess = 0;
                reply.message = ex.Message;
            }

            return Ok(reply);
        }
    }
}


