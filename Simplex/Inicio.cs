using System;
using System.Windows.Forms;

namespace Simplex
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        public Inicio(int variables, int restricciones)
        {
            InitializeComponent();
            // Le restamos 2 ya que las opciones mostradas van desde el 2 al 10,
            // por lo que se omiten el 1 y el 10 al tratarse de un arreglo y comenzar a contar desde 0
            numVariables.SelectedIndex = variables - 2;     
            numRestricciones.SelectedIndex = restricciones - 2;
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void continuarBtn_Click(object sender, EventArgs e)
        {
            // Verifica que ambos campos estén llenos
            if(numVariables.SelectedItem == null || numRestricciones.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una opcion en ambos campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Ingreso_de_datos VentanaIngreso = new Ingreso_de_datos(Int32.Parse(numVariables.SelectedItem.ToString()),
                    Int32.Parse(numRestricciones.SelectedItem.ToString()));

                Hide();
                VentanaIngreso.Show();
            }
        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
