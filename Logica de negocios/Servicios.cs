using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.DataContracts;
using DAL;
using DAL.Models;

namespace Logica_de_negocios
{
    public class Servicios
    {
        public Response CreateUser(Entidades.User user) {
            UserManager userManager = new UserManager();
            return userManager.InsertarUsuario(user);
        }

        public Response EditUser(Entidades.User user)
        {
            UserManager userManager = new UserManager();
            return userManager.EditarUsuario(user);

        }

        public List<Entidades.User> ListUsers()
        {
//            using(var usuarioDAL = new UserManager(_context))
            UserManager userManager =new UserManager();
            return userManager.ListarUsuarios();   
        }

     
        public LoginResponse LoginUser(LoginRequest user)
        {
            UserManager userManager = new UserManager();
            return userManager.IniciarSesion(user);
        }
    }
}
