using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Simplex
{
    public partial class Ingreso_de_datos : Form
    {
        int numVariables;
        int numRestricciones;

        public Ingreso_de_datos()
        {
            InitializeComponent();
        }

        public Ingreso_de_datos(int variables, int restricciones)
        {
            InitializeComponent();
            numVariables = variables;
            numRestricciones = restricciones;



            // Creacion de elementos para ingreso de función objetivo
            int posX = 120;
            int posY = 50;

            for (int i = 0; i < numVariables; i++)
            {
                // Creación de input numerico
                NumericUpDown inputNum = new NumericUpDown
                {
                    Name = "Fx" + (i + 1),
                    Minimum = -1000,
                    Maximum = 1000,
                    Size = new Size(50, 20),
                    Location = new Point(posX + 45, posY),
                    DecimalPlaces = 2,
                };


                // Define la fuente que tendrá la etiqueta
                Font fuente = new Font("Microsoft Sans Serif", 12);

                // Creacion de etiqueta
                Label etiqueta = new Label();
                if (i == numVariables - 1)
                {
                    etiqueta.Text = "x" + generarSubindice(i + 1);
                }
                else
                {
                    etiqueta.Text = "x" + generarSubindice(i + 1) + "  + ";
                }

                etiqueta.Location = new Point(posX + 95, posY);
                etiqueta.Font = fuente;
                etiqueta.Size = new Size(42, 20);


                // Se agregan los componentes
                Controls.Add(inputNum);
                Controls.Add(etiqueta);

                // Se actualizan posiciones en X y Y para nuevos componentes
                posX = etiqueta.Location.X;

            }



            // Creación de elementos para ingreso de restricciones
            posX = 120;
            posY = 90;

            for (int i = 0; i < numRestricciones; i++)
            {
                for (int j = 0; j < numVariables; j++)
                {
                    // Creación de input numerico
                    NumericUpDown inputNum = new NumericUpDown
                    {
                        Name = "Rx" + (j + 1),
                        Minimum = -1000,
                        Maximum = 1000,
                        Size = new Size(50, 20),
                        Location = new Point(posX + 45, posY),
                        DecimalPlaces = 2,
                    };


                    // Define la fuente que tendrá la etiqueta
                    Font fuente = new Font("Microsoft Sans Serif", 12);

                    // Creacion de etiqueta
                    Label etiqueta = new Label();
                    if (j == numVariables - 1)
                    {
                        etiqueta.Text = "x" + generarSubindice(j + 1);
                    }
                    else
                    {
                        etiqueta.Text = "x" + generarSubindice(j + 1) + "  + ";
                    }

                    etiqueta.Location = new Point(posX + 95, posY);
                    etiqueta.Font = fuente;
                    etiqueta.Size = new Size(42, 20);

                    // Se agregan los componentes
                    Controls.Add(inputNum);
                    Controls.Add(etiqueta);

                    // Se actualizan posiciones en X y Y para nuevos componentes
                    posX = etiqueta.Location.X;
                }

                // Creación de ComboBox para relaciones
                ComboBox relacion = new ComboBox();
                relacion.Name = "Relacion" + (i + 1);
                relacion.DropDownStyle = ComboBoxStyle.DropDownList;
                relacion.Items.Insert(0, "<=");
                relacion.Items.Insert(1, ">=");
                relacion.Size = new Size(40, 20);
                relacion.Location = new Point(posX + 42, posY);


                //Creacion de input numerico para resultado de la relacion
                NumericUpDown inputResultado = new NumericUpDown
                {
                    Name = "Resultado" + (i + 1),
                    Minimum = -1000,
                    Maximum = 1000,
                    Size = new Size(50, 20),
                    Location = new Point(posX + 98, posY),
                    DecimalPlaces = 2,
                };

                Controls.Add(relacion);
                Controls.Add(inputResultado);


                posX = 120;
                posY = posY + 30;
            }

            Size = new Size(200, posY + 80);
        }


        private string generarSubindice(int numero)
        {
            int valor = int.Parse("208" + numero, System.Globalization.NumberStyles.HexNumber);
            string subindice = char.ConvertFromUtf32(valor).ToString();
            return subindice;
        }



        private void regresarBtn_Click(object sender, EventArgs e)
        {
            Inicio ventanaInicio = new Inicio(numVariables, numRestricciones);
            Hide();
            ventanaInicio.Show();
        }

        private void Ingreso_de_datos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        // Crea un arreglo con las constantes de la función objetivo
        private float[] getValoresFuncion()
        {
            List<float> list = new List<float>();

            foreach (Control c in Controls)
            {
                if (c is NumericUpDown && c.Name.Contains("Fx"))
                {
                    list.Add((float)((NumericUpDown)c).Value);
                }

            }

            return list.ToArray();
        }


        // Crea un arreglo con las constantes de las restricciones
        private float[] getValoresRestricciones()
        {
            List<float> list = new List<float>();

            foreach (Control c in Controls)
            {
                if (c is NumericUpDown && c.Name.Contains("Rx"))
                {
                    list.Add((float)((NumericUpDown)c).Value);
                }
            }

            return list.ToArray();
        }

        private float[] getResultadosRestricciones()
        {
            float[] resultados = new float[numRestricciones];
            int contador = 0;

            foreach (Control c in Controls)
            {
                if (c is NumericUpDown && ((NumericUpDown)c).Name.Contains("Resultado"))
                {
                    resultados[contador] = (float)((NumericUpDown)c).Value;
                    contador++;
                }
            }

            return resultados;
        }

        // Crea una matriz bidimensional combinando las constantes de la funcion con las de las restricciones
        private float[,] generarMatriz()
        {
            float[] valoresFuncion = getValoresFuncion();
            float[] valoresRestricciones = getValoresRestricciones();
            float[] resultadosRes = getResultadosRestricciones();

            // Agregamos uno para la fila de la función
            int filas = numRestricciones + 1;   
            // Se suman porque por cada restriccion se agrega una variable de holgura y sumamos 2 para la columna de z y la de resultados
            int columnas = numVariables + numRestricciones + 2;
            float[,] Matriz = new float[filas, columnas];


            // Llena la columna de coeficientes de la funcion objetivo
            for (int i = 0; i < columnas; i++)
            {
                if (i == 0)
                {
                    Matriz[0, 0] = 1;
                }else if ( i > numVariables)
                {
                    Matriz[0, i] = 0;
                }
                else
                {
                    Matriz[0, i] = valoresFuncion[i - 1];
                }
            }


            // Contador para arreglo de coeficientes de restricciones
            int contador = 0;
            // Llena los coeficientes de las restricciones
            for (int i = 1; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // Si estamos en la primer columna ponemos 0 por ser la columna de coeficientes de z
                    if (j == 0)
                    {
                        Matriz[i, 0] = 0;
                    }
                    // Agrega los coeficientes de las variables de holgura
                    else if (j > numVariables && j == i + numVariables)
                    {
                        Matriz[i, j] = 1;
                    }
                    // Si no estamos en la ultima columna llenamos con 0
                    else if(j > numVariables && j != columnas - 1)
                    {
                        Matriz[i, j] = 0;
                    }
                    // Si estamos en la ultima columna ponemos el valor del resultado
                    else if(j > numVariables && j == columnas - 1)
                    {
                        Matriz[i, j] = resultadosRes[i - 1];
                    }
                    // Agrega los coeficientes de las restricciones
                    else
                    {
                        Matriz[i, j] = valoresRestricciones[contador];
                        contador++;
                    }
                }
            }


            return Matriz;
        }


        private void resolverBtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                // Verifica que ningun ComboBox esté vacío
                if (control is ComboBox && ((ComboBox)control).SelectedItem == null)
                {
                    MessageBox.Show("Llene todos los campos para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Resultados ventanaResultados = new Resultados(numVariables, numRestricciones, numVariables + numRestricciones + 2, numRestricciones + 1, generarMatriz(), comboBoxTipo.Text);
            Hide();
            ventanaResultados.Show();
        }
    }
}
