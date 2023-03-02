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


        // Crea la ventana con los datos del problema que toma como parametros
        public Ingreso_de_datos(int variables, int restricciones, float[,] matrizInicial, string tipo)
        {
            InitializeComponent();

            numVariables = variables;
            numRestricciones = restricciones;

            crearElementos();
            comboBoxTipo.Text = tipo;

            int contadorFuncion = 1;
            int i = 1;
            int j = 1;
            int k = 1;

            foreach (Control c in Controls)
            {
                if (c is NumericUpDown && c.Name.Contains("Fx"))
                {
                    if (tipo == "Max")
                    {
                        ((NumericUpDown)c).Value = (decimal)matrizInicial[0, contadorFuncion];
                        contadorFuncion++;
                    }
                    else
                    {
                        ((NumericUpDown)c).Value = (decimal)matrizInicial[0, contadorFuncion] * -1;
                        contadorFuncion++;
                    }
                }
                else if (c is NumericUpDown && c.Name.Contains("Rx"))
                {
                    if (j == numVariables + 1)
                    {
                        j = 1;
                        i++;
                    }

                    ((NumericUpDown)c).Value = (decimal)matrizInicial[i, j];
                    j++;
                }
                else if (c is NumericUpDown && c.Name.Contains("Resultado"))
                {
                    ((NumericUpDown)c).Value = (decimal)matrizInicial[k, numVariables + numRestricciones + 1];
                    k++;
                }
            }
        }


        // Crea los elementos de la ventana para que el usuario ingrese los datos
        public Ingreso_de_datos(int variables, int restricciones)
        {
            InitializeComponent();
            numVariables = variables;
            numRestricciones = restricciones;
            crearElementos();
        }



        // Agrega los elementos a la ventana
        public void crearElementos()
        {
            // ***************** Creacion de elementos para ingreso de función objetivo *****************
            int posX = 120;
            int posY = 50;

            for (int i = 0; i < numVariables; i++)
            {
                // Creación de input numerico
                NumericUpDown inputNum = new NumericUpDown
                {
                    Name = "Fx" + (i + 1),
                    Minimum = -100000,
                    Maximum = 100000,
                    Size = new Size(50, 20),
                    DecimalPlaces = 2,
                };

                // Ajusta la posicion de los inputs dependiendo del tamaño de la etiqueta
                if (i < 10)
                {
                    inputNum.Location = new Point(posX + 45, posY);
                }
                else
                {
                    inputNum.Location = new Point(posX + 50, posY);
                }


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


                etiqueta.Font = fuente;
                etiqueta.AutoSize = true;

                // Ajusta el tamaño de la etiqueta si el subindice es mayor a 10
                if (i < 10)
                {
                    etiqueta.Location = new Point(posX + 95, posY);
                }
                else
                {
                    etiqueta.Location = new Point(posX + 100, posY);
                }


                // Se agregan los componentes
                Controls.Add(inputNum);
                Controls.Add(etiqueta);

                // Se actualizan posiciones en X y Y para nuevos componentes
                posX = etiqueta.Location.X;

            }



            // ***************** Creación de elementos para ingreso de restricciones *****************
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
                        DecimalPlaces = 2,
                    };

                    // Ajusta la posicion de los inputs dependiendo del tamaño de la etiqueta
                    if (j < 10)
                    {
                        inputNum.Location = new Point(posX + 45, posY);
                    }
                    else
                    {
                        inputNum.Location = new Point(posX + 50, posY);
                    }



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

                    // Ajusta el tamaño de la etiqueta si el subindice es mayor a 10
                    if (j < 10)
                    {
                        etiqueta.Location = new Point(posX + 95, posY);
                    }
                    else
                    {
                        etiqueta.Location = new Point(posX + 100, posY);
                    }

                    etiqueta.Font = fuente;
                    etiqueta.AutoSize = true;
                    // etiqueta.Size = new Size(40, 20);

                    // Se agregan los componentes
                    Controls.Add(inputNum);
                    Controls.Add(etiqueta);

                    // Se actualizan posiciones en X y Y para nuevos componentes
                    posX = etiqueta.Location.X;
                }

                // Creación de etiqueta para relaciones
                Label relacion = new Label();
                relacion.Name = "Relacion" + (i + 1);
                relacion.Text = "<=";
                relacion.Size = new Size(20, 20);

                if (numVariables < 10)
                {
                    relacion.Location = new Point(posX + 20, posY + 3);
                }
                else
                {
                    relacion.Location = new Point(posX + 25, posY + 3);
                }


                //Creacion de input numerico para resultado de la relacion
                NumericUpDown inputResultado = new NumericUpDown
                {
                    Name = "Resultado" + (i + 1),
                    Minimum = 0,
                    Maximum = 1000,
                    Size = new Size(50, 20),
                    DecimalPlaces = 2,
                };

                // Ajusta la posicion de los inputs dependiendo del tamaño de la etiqueta
                if (i < 10)
                {
                    inputResultado.Location = new Point(posX + 45, posY);
                }
                else
                {
                    inputResultado.Location = new Point(posX + 50, posY);
                }

                Controls.Add(relacion);
                Controls.Add(inputResultado);


                posX = 120;
                posY = posY + 30;
            }


            Label naturaleza = new Label();
            for (int i = 0; i < numVariables; i++)
            {
                if (i != numVariables - 1)
                {
                    naturaleza.Text += "x" + generarSubindice(i + 1) + ", ";
                }
                else
                {
                    naturaleza.Text += "x" + generarSubindice(i + 1);
                }
            }

            naturaleza.Text += " >= 0";
            naturaleza.Name = "Naturaleza";
            Font fuenteNaturaleza = new Font("Microsoft Sans Serif", 12);
            naturaleza.Font = fuenteNaturaleza;
            naturaleza.MinimumSize = new Size(0, 40);
            naturaleza.AutoSize = true;
            naturaleza.Location = new Point(posX + 42, posY);
            Controls.Add(naturaleza);

            posY = naturaleza.Location.Y + naturaleza.Height;
            Size = new Size(200, posY + 80);
        }


        // Retorna como subindice el numero dado
        private string generarSubindice(int numero)
        {
            if (numero < 10)
            {
                // Crea el caracter del subindice
                int valor = int.Parse("208" + numero, System.Globalization.NumberStyles.HexNumber);
                string subindice = char.ConvertFromUtf32(valor).ToString();
                return subindice;
            }
            else if (numero % 10 == 0)
            {
                // Almacenamos el numero correspondiente a las decenas
                string decena = numero.ToString()[0].ToString();
                decena = generarSubindice(int.Parse(decena));

                // Le agregamos el subindice 0
                string subindice = decena + "ₒ";
                return subindice;
            }
            else
            {
                // Almacenamos el numero correspondiente a las unidades
                int unidad = numero % 10;
                // Obtenemos el subindice correspondiente a la decena
                string decena = numero.ToString()[0].ToString();
                decena = generarSubindice(int.Parse(decena));

                // Creamos la string con el numero de la decena y le agregamos el subindice correspondiente a la unidad
                string subindice = decena;
                int valor = int.Parse("208" + unidad, System.Globalization.NumberStyles.HexNumber);
                subindice += char.ConvertFromUtf32(valor).ToString();
                return subindice;
            }
        }


        // Si da clic al boton regresar mostramos la ventana de inicio
        private void regresarBtn_Click(object sender, EventArgs e)
        {
            Inicio ventanaInicio = new Inicio(numVariables, numRestricciones);
            Hide();
            ventanaInicio.Show();
        }


        // Si se cierra la ventana se termina la aplicación
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


        // Crea un arreglo con los valores del lado derecho de las restricciones
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


        // Crea una matriz bidimensional combinando los valores de la funcion con los de las restricciones
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
                }
                else if (i > numVariables)
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
                    else if (j > numVariables && j != columnas - 1)
                    {
                        Matriz[i, j] = 0;
                    }
                    // Si estamos en la ultima columna ponemos el valor del resultado
                    else if (j > numVariables && j == columnas - 1)
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


        // Si se da clic en boton resolver mostramos ventana de resultados
        private void reiniciarBtn_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Deseas eliminar los datos ingresados?", "Reiniciar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                foreach(Control c in Controls)
                {
                    if(c is ComboBox)
                    {
                        ((ComboBox)c).SelectedItem = null;
                    }else if(c is NumericUpDown)
                    {
                        ((NumericUpDown)c).Value = 0;
                    }
                }
            }
        }

        private void resolverBtn_Click_1(object sender, EventArgs e)
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


            // Crea ventana de resultados y la muestra
            Resultados ventanaResultados = new Resultados(numVariables, numRestricciones, numVariables + numRestricciones + 2, numRestricciones + 1, generarMatriz(), comboBoxTipo.Text);
            Hide();
            ventanaResultados.Show();
        }
    }
}
