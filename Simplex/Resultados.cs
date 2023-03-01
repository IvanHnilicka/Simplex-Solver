using System;
using System.Drawing;
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
        float[,] Matriz;

        public Resultados(int cantidadVariables, int cantidadRestricciones, int numColumnas, int numFilas, float[,] Matriz, string tipo)
        {
            InitializeComponent();
            numVariables = cantidadVariables;
            numRestricciones = cantidadRestricciones;
            columnas = numColumnas;
            filas = numFilas;

            this.Matriz = estandarizar(Matriz, tipo);
            imprimirMatriz(this.Matriz);
            crearTabla(this.Matriz);
        }


        // Retorna la matriz con los datos del problema estandarizado
        private float[,] estandarizar(float[,] Matriz, string tipo)
        {
            // Genera etiqueta con el problema estandarizado
            if (tipo == "Max")
            {
                funcionLabel.Text += "min -z = ";
            }
            else
            {
                funcionLabel.Text += "min z = ";
            }


            for (int i = 1; i < numVariables + 1; i++)
            {
                if (tipo == "Max")
                {
                    if (Matriz[0, i + 1] > 0)
                    {
                        funcionLabel.Text += Matriz[0, i] * -1 + "x" + generarSubindice(i) + " ";
                    }
                    else
                    {
                        if (i == numVariables)
                        {
                            funcionLabel.Text += Matriz[0, i] * -1 + "x" + generarSubindice(i);
                        }
                        else
                        {
                            funcionLabel.Text += Matriz[0, i] * -1 + "x" + generarSubindice(i) + " + ";
                        }
                    }

                }
                else if (tipo == "min")
                {
                    if (Matriz[0, i + 1] > 0)
                    {
                        if (i == numVariables)
                        {
                            funcionLabel.Text += Matriz[0, i] + "x" + generarSubindice(i);
                        }
                        else
                        {
                            funcionLabel.Text += Matriz[0, i] + "x" + generarSubindice(i) + " + ";
                        }
                    }
                    else
                    {
                        funcionLabel.Text += Matriz[0, i] + "x" + generarSubindice(i) + " ";
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
                        if (Matriz[i, j + 1] < 0)
                        {
                            labelRestricciones.Text += Matriz[i, j] + "x" + generarSubindice(j) + " ";
                        }
                        else
                        {
                            labelRestricciones.Text += Matriz[i, j] + "x" + generarSubindice(j) + " + ";
                        }

                    }
                    else
                    {
                        labelRestricciones.Text += Matriz[i, j] + "x" + generarSubindice(j) + " = " + Matriz[i, j + 1];
                    }
                }

                labelRestricciones.Text += "\n";
            }


            // Genera la etiqueta de la naturaleza de las variables
            for (int i = 1; i <= columnas - 2; i++)
            {

                if (i != columnas - 2)
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
                    for (int i = 1; i <= numVariables; i++)
                    {
                        Matriz[0, i] *= -1;
                    }
                    break;
            }

            return Matriz;
        }


        private void crearTabla(float[,] Matriz)
        {
            // Creación y configuración de propiedades de la tabla
            DataGridView tabla = new DataGridView();
            tabla.Location = new System.Drawing.Point(12, labelRestricciones.Location.Y + labelRestricciones.Height + 25);
            tabla.Name = "tablaSimplex";
            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
            tabla.AllowUserToOrderColumns = false;
            tabla.AllowUserToResizeColumns = false;
            tabla.AllowUserToResizeRows = false;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tabla.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tabla.RowsDefaultCellStyle.SelectionBackColor = tabla.DefaultCellStyle.BackColor;
            tabla.DefaultCellStyle.SelectionForeColor = tabla.DefaultCellStyle.ForeColor;
            tabla.Enabled = false;
            tabla.Margin = new Padding(0, 0, 10, 50);
            tabla.ReadOnly = true;
            tabla.RowHeadersVisible = false;
            tabla.Width = Width;


            // Creación de columnas de la tabla
            tabla.Columns.Add(crearColumna("Ecuacion", "Ec."));
            tabla.Columns.Add(crearColumna("variablesBasicas", "VB"));
            tabla.Columns.Add(crearColumna("z", "z"));

            for (int i = 1; i < columnas - 1; i++)
            {
                tabla.Columns.Add(crearColumna("x" + i, "x" + generarSubindice(i)));
            }

            tabla.Columns.Add(crearColumna("b", "b"));


            // Llenado de tabla
            for (int i = 0; i < filas; i++)
            {
                tabla.Rows.Add();

                for (int j = 0; j < columnas; j++)
                {
                    tabla.Rows[i].Cells[j + 2].Value = Matriz[i, j];
                }
            }


            for (int i = 0; i < filas; i++)
            {
                tabla.Rows[i].Cells[0].Value = i;
                tabla.Rows[i].Cells[1].Value = "x" + generarSubindice(numVariables + i);
            }

            tabla.Rows[0].Cells[1].Value = "z";
            Controls.Add(tabla);

        }


        // Crea las columnas de la tabla y les asigna el encabezado
        private DataGridViewColumn crearColumna(string nombre, string header)
        {
            DataGridViewColumn columna = new DataGridViewColumn();
            DataGridViewCell celda = new DataGridViewTextBoxCell();
            columna.CellTemplate = celda;
            columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            columna.Resizable = DataGridViewTriState.False;
            columna.Name = nombre;
            columna.HeaderText = header;

            return columna;
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


        // Termina la aplicación si se cierra la ventana
        private void Resultados_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        // Regresa a la ventana de inicio si se da clic al botón salir
        private void salirBtn_Click(object sender, EventArgs e)
        {
            Inicio ventanaInicio = new Inicio();
            Hide();
            ventanaInicio.Show();
        }


        // Actualiza los datos que se están mostrando en la tabla
        private void actualizarTabla()
        {
            // Obtenemos la referencia de la tabla
            DataGridView tabla = new DataGridView();

            foreach (Control c in Controls)
            {
                if (c is DataGridView && ((DataGridView)c).Name == "tablaSimplex")
                {
                    tabla = ((DataGridView)c);
                }
            }


            // Asigna los datos nuevos
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    tabla.Rows[i].Cells[j + 2].Value = (float)Math.Round(Matriz[i, j], 2);
                }
            }
        }


        // Retorna true si el problema tiene soluciones infinitas, false en caso contrario
        private bool solucionesInfinitas(DataGridView tabla)
        {
            bool solucionesInfinitas = false;
            string[] variablesBasicas = new string[filas - 1];

            // Llena el arreglo con el nombre de las variables básicas
            for (int i = 0; i < filas - 1; i++)
            {
                variablesBasicas[i] = tabla.Rows[i + 1].Cells[1].Value.ToString();
            }


            for (int i = 1; i < columnas - 1; i++)
            {
                // Almacena el nombre de la variable que se va a verificar si es básica
                string variable = tabla.Columns[i + 2].HeaderText;

                if (Matriz[0, i] == 0)
                {
                    for (int j = 0; j < variablesBasicas.Length; j++)
                    {
                        // Si la variable que se esta comparando está en las básicas dejamos de comparar ya que, por ser básica, debe ser 0
                        if (variablesBasicas[j] == variable)
                        {
                            solucionesInfinitas = false;
                            break;
                        }
                        else
                        {
                            solucionesInfinitas = true;
                        }
                    }

                    // Si no se encontraba dentro de las variables basicas y tiene valor de 0 salimos del ciclo y retornamos true
                    if (solucionesInfinitas)
                    {
                        break;
                    }
                }
            }

            return solucionesInfinitas;
        }



        private void continuarBtn_Click(object sender, EventArgs e)
        {
            // Obtenemos la referencia de la tabla
            DataGridView tabla = new DataGridView();

            foreach (Control c in Controls)
            {
                if (c is DataGridView && c.Name.Equals("tablaSimplex"))
                {
                    tabla = ((DataGridView)c);
                }
            }


            // Verifica que si el problema tiene soluciones infinitas
            if (solucionesInfinitas(tabla))
            {
                // Actualiza etiqueta mostrando una solucion y el valor optimo
                labelMovimientos.Text = "El problema tiene soluciones infinitas, siendo una de ellas x = (";
                salirBtn.Enabled = true;
                salirBtn.Text = "Regresar";
                salirBtn.Visible = true;
                continuarBtn.Enabled = false;
                continuarBtn.Visible = false;
                labelMovimientos.Visible = true;
            }


            // Valida si ya se llegó a la solución
            bool solucionEncontrada = true;

            for (int i = 1; i < columnas - 1; i++)
            {
                // Si algun elemento de la primera fila es mayor a 0 no se ha llegado a la solución
                if (Matriz[0, i] > 0)
                {
                    solucionEncontrada = false;
                }
            }

            int altura = tabla.Location.Y + tabla.Height + 15;
            labelMovimientos.Location = new Point(10, altura);


            if (solucionEncontrada)
            {
                // Guarda los coeficientes de las variables de la solucion en el arreglo
                float[] solucion = new float[numVariables];
                for (int i = 0; i < numVariables; i++)
                {
                    for (int j = 0; j < filas; j++)
                    {
                        if (tabla.Rows[j].Cells[1].Value.ToString() == "x" + generarSubindice(i + 1))
                        {
                            solucion[i] = (float)tabla.Rows[j].Cells[columnas + 1].Value;
                        }
                    }
                }

                // Actualiza etiqueta si el problema tiene solución única
                if (!solucionesInfinitas(tabla))
                {
                    labelMovimientos.Text = "El problema tiene solución óptima única   x* = (";
                }


                // Escribe los coeficientes de la solución en la etiqueta
                for (int i = 0; i < solucion.Length; i++)
                {
                    if (i == solucion.Length - 1)
                    {
                        labelMovimientos.Text += "x" + generarSubindice(i + 1) + ") = ";
                    }
                    else
                    {
                        labelMovimientos.Text += "x" + generarSubindice(i + 1) + ", ";
                    }
                }

                labelMovimientos.Text += "(";

                for (int i = 0; i < solucion.Length; i++)
                {
                    if (i == solucion.Length - 1)
                    {
                        labelMovimientos.Text += solucion[i] + ") ";
                    }
                    else
                    {
                        labelMovimientos.Text += solucion[i] + ", ";
                    }
                }


                labelMovimientos.Text += "\ny valor optimo z* = " + Matriz[0, columnas - 1] * Matriz[0, 0];

                salirBtn.Enabled = true;
                salirBtn.Text = "Regresar";
                salirBtn.Visible = true;
                continuarBtn.Enabled = false;
                continuarBtn.Visible = false;

                return;
            }

            int posX = salirBtn.Location.X;
            int posY = salirBtn.Location.Y;
            salirBtn.Visible = false;
            continuarBtn.Location = new Point(posX, posY);

            labelMovimientos.Visible = true;


            // Si no se ha llegado a una solución realizamos la siguiente iteración

            // Buscamos la columna con el número mayor
            int columnaNumMayor = 0;
            for (int i = 1; i < columnas - 1; i++)
            {
                if (Matriz[0, i] > 0 && Matriz[0, i] >= Matriz[0, columnaNumMayor])
                {
                    columnaNumMayor = i;
                }
            }


            // Buscamos la fila con el menor cociente
            float menorCociente = 999999;
            int filaMenorCociente = 0;
            for (int i = 1; i < filas; i++)
            {
                if (Matriz[i, columnaNumMayor] > 0)
                {
                    float cociente = Matriz[i, columnas - 1] / Matriz[i, columnaNumMayor];
                    if (cociente <= menorCociente)
                    {
                        menorCociente = cociente;
                        filaMenorCociente = i;
                    }
                }
            }

            if(filaMenorCociente == 0)
            {
                labelMovimientos.Text = "El problema no tiene solución";
                salirBtn.Enabled = true;
                salirBtn.Text = "Regresar";
                salirBtn.Visible = true;
                continuarBtn.Enabled = false;
                continuarBtn.Visible = false;
                labelMovimientos.Visible = true;

                return;

            }


            // Escribe el movimiento realizado en la tabla
            labelMovimientos.Text = "Entró " + tabla.Columns[columnaNumMayor + 2].HeaderText +
                ", salió " + tabla.Rows[filaMenorCociente].Cells[1].Value;

            tabla.Rows[filaMenorCociente].Cells[1].Value = tabla.Columns[columnaNumMayor + 2].HeaderText;



            // Si el valor no es 1 pivoteamos
            if (Matriz[filaMenorCociente, columnaNumMayor] != 1)
            {
                // Almacenamos el número entre el que se va a realizar la división
                float dividendo = Matriz[filaMenorCociente, columnaNumMayor];
                for (int i = 1; i < columnas; i++)
                {
                    Matriz[filaMenorCociente, i] = Matriz[filaMenorCociente, i] / dividendo;
                }
            }

            // Hacemos 0 los valores arriba y abajo del 1
            for (int i = 0; i < filas; i++)
            {
                if (i != filaMenorCociente)
                {
                    // Si el valor no es 0 hacemos que lo sea
                    if (Matriz[i, columnaNumMayor] > 0 || Matriz[i, columnaNumMayor] < 0)
                    {
                        // Almacenamos el número por el que se va a multiplicar la fila para despues sumarlo a la fila correspondiente
                        float multiplicador = Matriz[i, columnaNumMayor] * -1;
                        for (int j = 1; j < columnas; j++)
                        {
                            Matriz[i, j] += (float)Math.Round(multiplicador * Matriz[filaMenorCociente, j], 6);
                        }
                    }
                }
            }


            actualizarTabla();
        }
    }
}
