using System;
using System.Windows.Forms;

namespace Simplex
{
    public partial class Resultados : Form
    {
        public Resultados()
        {
            InitializeComponent();
        }

        int numVariables;
        int numRestricciones;
        int columnas;
        int filas;

        public Resultados(int cantidadVariables, int cantidadRestricciones, int numColumnas, int numFilas,  float[,] Matriz, string tipo)
        {
            InitializeComponent();
            numVariables = cantidadVariables;
            numRestricciones = cantidadRestricciones;
            columnas = numColumnas;
            filas = numFilas;

            //imprimirMatriz(Matriz);

            if (tipo == "Max")
            {
                funcionLabel.Text += "min -z = ";

            }
            else if (tipo == "min")
            {
                funcionLabel.Text += "min z = ";
            }

            float[,] matrizEstandar = estandarizar(Matriz, tipo);
        }


        // Retorna la matriz con los datos del problema estandarizado
        private float[,] estandarizar(float[,] Matriz, string tipo)
        {
            // Actualiza etiqueta con el problema estandarizado
            for (int i = 1; i < columnas; i++)
            {
                if (i <= numVariables)
                {
                    if (i == numVariables || Matriz[0, i + 1] < 0)
                    {
                        funcionLabel.Text = funcionLabel.Text + Matriz[0, i] + "x" + i;
                    }
                    else
                    {
                        funcionLabel.Text = funcionLabel.Text + Matriz[0, i] + "x" + i + " + ";
                    }
                }
            }

            for (int i = 1; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    restriccionesLbl.Text += Matriz[i, j];
                }

                restriccionesLbl.Text += "\n";
            }


            // Estandariza el problema
            switch (tipo)
            {
                case "Max":
                    Matriz[0, 0] *= -1;
                    break;

                case "min":
                    for (int i = 1; i <= numVariables; i++){
                        Matriz[0, i] *= -1;
                    }

                    break;
            }


            imprimirMatriz(Matriz);
            return Matriz;
        }



        // Imprime la matriz en consola
        private void imprimirMatriz(float[,] Matriz)
        {

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (j == columnas - 1)
                    {
                        Console.Write(Matriz[i, j]);
                    }
                    else
                    {
                        Console.Write(Matriz[i, j] + "\t|\t");
                    }
                }

                Console.Write("\n");
            }
        }



        private void Resultados_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
