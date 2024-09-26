using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validacion_de_datos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los TextBoxes
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string edadText = txtEdad.Text.Trim();
            string estaturaText = txtEstatura.Text.Trim();
            string genero = radioHombre.Checked ? "Hombre" : (radioMujer.Checked ? "Mujer" : "");

            // Validaciones
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(edadText) || string.IsNullOrEmpty(estaturaText) || string.IsNullOrEmpty(genero))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que nombre y apellidos solo contengan letras
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(apellidos, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre y apellidos solo pueden contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que teléfono sea un número
            if (!long.TryParse(telefono, out _))
            {
                MessageBox.Show("El teléfono debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que edad sea un número
            if (!int.TryParse(edadText, out int edad))
            {
                MessageBox.Show("La edad debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que estatura sea numérica (puede incluir decimales)
            if (!double.TryParse(estaturaText, out double estatura))
            {
                MessageBox.Show("La estatura debe ser un número (puede incluir decimales).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar un mensaje de éxito
            MessageBox.Show($"Datos guardados:\n\nNombre: {nombre}\nApellidos: {apellidos}\nTeléfono: {telefono}\nEdad: {edad}\nEstatura: {estatura}\nGénero: {genero}", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar campos después de guardar
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEdad.Clear();
            txtEstatura.Clear();
            radioHombre.Checked = false;
            radioMujer.Checked = false;
        }

       
    }
}
    