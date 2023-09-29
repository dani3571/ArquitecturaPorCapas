using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Entidades.DataContracts;
using Tools;
namespace DAL
{
    public class UserManager
    {
        private ArquitecturaCapasDBContext _context = new ArquitecturaCapasDBContext();
        public Response InsertarUsuario(Entidades.User user)
        {
            Encryption encrypter = new Encryption();
            user.Password = encrypter.HashPassword(user.Password);
            try
            {
                _context.Add(new Models.User(user.Id, user.Username, user.Password));
                _context.SaveChanges();
                user.ErrorCode = 200;
                user.Description = "";
                user.Message = "Usuario guardado correctamente en la base de datos";
                return user;
            }
            catch (Exception e)
            {
                user.ErrorCode = 200;
                user.Description = e.Message;
                user.Message = "Error al insertar el usuario en la base de datos";
                return user;
            }
            
        }
        public List<Entidades.User> ListarUsuarios() {

            try
            {
                List<Models.User> usuarioss = _context.Users.ToList();
                //Mapeo de usuarios del modelo a la entidad Users
                List<Entidades.User> usuariosEntidad = usuarioss.Select(u => new Entidades.User(u.Id, u.Username, u.Password)).ToList();
          
                return usuariosEntidad;
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar usuarios en la base de datos");
            }
        }
         public Response EditarUsuario(Entidades.User user)
        {
             var usuarioExistente = _context.Set<DAL.Models.User>().FirstOrDefault(u => u.Id == user.Id);

            if(usuarioExistente != null)
            {
                try
                {

                    usuarioExistente.Username = user.Username;
                    Encryption encrypter = new Encryption();
                    user.Password = encrypter.HashPassword(user.Password);
                    usuarioExistente.Password = user.Password;
                    _context.SaveChanges();
                    user.ErrorCode = 200;
                    user.Description = "";
                    user.Message = "Usuario actualizado correctamente en la base de datos";
                    return user;
                }
                catch (Exception e)
                {
                    user.ErrorCode = 200;
                    user.Description = e.Message;
                    user.Message = "Error al actualizar el usuario en la base de datos";
                    return user;

                }

            }
            else 
            {
                user.ErrorCode = 100;
                user.Message = "No se encuentra un usuario con ese id";
                user.Description = "a";

                return user;
            }

        }
        public LoginResponse IniciarSesion(LoginRequest user)
        {
            var usuarioExistente = _context.Set<DAL.Models.User>().FirstOrDefault(u => u.Username == user.username);
           
            if (usuarioExistente!= null)
            {
                Encryption encrypter = new Encryption();
                string hashedPassword = encrypter.HashPassword(user.password);

                if(usuarioExistente.Password == hashedPassword)
                {
                     LoginResponse resp = new LoginResponse();

                      resp.ErrorCode = 200;
                      resp.Message = "Login correcto";
                      resp.Description = "Ok";
                      
                      return resp;
                }
                else
                {
                    throw new Exception("ErrorContraseña");
                }

            }
            else
            {
                throw new Exception("ErrorUsuario");
            }
        }
    }
}
