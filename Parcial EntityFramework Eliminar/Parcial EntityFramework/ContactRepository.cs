using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_EntityFramework
{
    public class ContactRepository
    {
        public Entities contexto = new Entities();
        public List<Contact> ObtenerTodos()
        {
            var contact = from custM in contexto.Contact select custM;

            return contact.ToList();
        }

        public int borrarContac(int id)
        {
            // Buscar el contacto por su ID
            var contact = contexto.Contact.SingleOrDefault(c => c.ContactID == id);

            if (contact != null)
            {
                contexto.Contact.Remove(contact); // Eliminar el contacto
                contexto.SaveChanges(); // Guardar los cambios en la base de datos
                return 1; // Retornar verdadero si se eliminó
            }
            return 0; // Retornar falso si no se encontró
        }
    }
}
