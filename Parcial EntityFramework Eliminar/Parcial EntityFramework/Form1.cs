using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        private ContactRepository con = new ContactRepository();
        private void Obtener_datos_Click(object sender, EventArgs e)
        {
            var cliente = con.ObtenerTodos();
            Contact_database.DataSource = cliente;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            // Obtener el ID del TextBox (suponiendo que se llama textBox1)
            int contactId;
            if (int.TryParse(textBox1.Text, out contactId))
            {
                // Llamar al método de eliminación del repositorio
                int result = con.borrarContac(contactId);

                if (result == 1)
                {
                    MessageBox.Show("Contacto eliminado con éxito.");
                    Obtener_datos_Click(sender, e); // Actualizar la lista de contactos después de eliminar
                }
                else
                {
                    MessageBox.Show("Contacto no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID válido.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
