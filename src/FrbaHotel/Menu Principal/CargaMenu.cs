using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaHotel.Sistema;

namespace FrbaHotel.Menu_Principal
{
    class CargaMenu
    {
        public CargaMenu(string rolElegido, UsuarioLogueado usuario)
        {
            switch (rolElegido)
            {
                case "Administrador":
                    MenuAdmin levantarAdmin = new MenuAdmin(usuario);
                    levantarAdmin.ShowDialog();
                    break;
                case "Recepcionista":
                    MenuRecepcionista levantarRecepcion = new MenuRecepcionista(usuario);
                    levantarRecepcion.ShowDialog();
                    break;
                case "Guest":
                    MenuGuest levantarGuest = new MenuGuest(usuario.getConexion());
                    levantarGuest.ShowDialog();
                    break;
            }
        }
    }
}