﻿using System;
using System.Windows.Forms;

namespace Simplex
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            float[,] matriz = { {1, 5, 1, -2, 0, 0, 0},
                                {0, 7, 2, 3, 1, 0, 25},
                                {0, 9, 1, 5, 0, 1, 55}
            };
            Application.Run(new Resultados(3, 2, 7, 3, matriz, "Max"));
            

            /*
            float[,] matriz = { {1, 1, 1, 0, 0, 0},
                                {0, 1, 1, 1, 0, 4},
                                {0, -1, 1, 0, 1, 1}
            };
            Application.Run(new Resultados(2, 2, 6, 3, matriz, "Max"));
            */


             //Application.Run(new Inicio());
        }
    }
}
