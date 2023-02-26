using System;
using System.Linq;
using System.Text;
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
            imprimirMatriz(matrizEstandar);
        }


        // Retorna la matriz con los datos del problema estandarizado
        private float[,] estandarizar(float[,] Matriz, string tipo)
        {
            // Genera etiqueta con el problema estandarizado
            for (int i = 1; i < columnas; i++)
            {
                if (i <= numVariables)
                {
                    if (i == numVariables || Matriz[0, i + 1] < 0)
                    {
                        funcionLabel.Text = funcionLabel.Text + Matriz[0, i] + "x" + generarSubindice(i);
                    }
                    else
                    {
                        funcionLabel.Text = funcionLabel.Text + Matriz[0, i] + "x" + generarSubindice(i) + " + ";
                    }
                }
            }


            // Genera las etiquetas de las restricciones 
            for (int i = 1; i < filas; i++)
            {
                for (int j = 1; j < columnas - 1; j++)
                {
                    if (j != columnas - 2)
                    {
                        labelRestricciones.Text += Matriz[i, j] + "x" + generarSubindice(j) + " + ";
                        
                    }
                    else
                    {
                        labelRestricciones.Text += Matriz[i, j] + "x" + generarSubindice(j) + " = " + Matriz[i, j + 1];
                    }
                }

                labelRestricciones.Text += "\n";
            }


            // Genera la etiqueta de la naturaleza de las variables
            for(int i = 1; i <= columnas - 2; i++)
            {

                if(i != columnas - 2)
                {
                    labelRestricciones.Text += "x" + generarSubindice(i) + ", ";
                }
                else
                {
                    labelRestricciones.Text += "x" + generarSubindice(i);
                }
            }

            labelRestricciones.Text += " >= 0";



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

            return Matriz;
        }


        //Crea caracter del numero dado como un subindice
        private string generarSubindice(int numero)
        {
            int valor = int.Parse("208" + numero, System.Globalization.NumberStyles.HexNumber);
            string subindice = char.ConvertFromUtf32(valor).ToString();
            return subindice;
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
