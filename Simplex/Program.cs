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


            /*
            // Solucion única con una sola iteración
            float[,] matriz = { {1, 5, 1, -2, 0, 0, 0},
                                {0, 7, 2,  3, 1, 0, 25},
                                {0, 9, 1,  5, 0, 1, 55}
            };
            Application.Run(new Resultados(3, 2, 7, 3, matriz, "Max"));
            */



            /*
            // Solución única con dos iteraciones
            // x* = (20, 5, 0) | z* =160

            float[,] matriz = { {1, 7, 4, 3, 0, 0, 0 },
                                {0, 1, 2, 2, 1, 0, 30},
                                {0, 2, 1, 2, 0, 1, 45}
            };
            Application.Run(new Resultados(3, 2, 7, 3, matriz, "Max"));
            */



            /*
            // Solución única con dos iteraciones
            // x* = (3, 12) | z* = 33
            float[,] matriz = { {1, 3, 2, 0, 0, 0, 0 },
                                {0, 2, 1, 1, 0, 0, 18},
                                {0, 2, 3, 0, 1, 0, 42},
                                {0, 3, 1, 0, 0, 1, 24}
            };
            Application.Run(new Resultados(2, 3, 7, 4, matriz, "Max"));
            */



            /*
            // Solución única 0
            // x* = (0, 0) | z* = 0
            float[,] matriz = { {1, 2, 3, 0, 0, 0 },
                                {0, 1, 1, 1, 0, 5 },
                                {0, 2, 1, 0, 1, 8}
            };
            Application.Run(new Resultados(2, 2, 6, 3, matriz, "min"));
            */



            /*
            // Soluciones infinitas
            // x* = (0, 3) | z* = 42
            float[,] matriz = { {1, 4, 14, 0, 0, 0},
                                {0, 2, 7, 1, 0, 21},
                                {0, 7, 2, 0, 1, 21}
            };
            Application.Run(new Resultados(2, 2, 6, 3, matriz, "Max"));
            */



            /*
            // Sin solución
            float[,] matriz = { {1, 4,  6, 0, 0, 0 },
                                {0, 2, -2, 1, 0, 6 },
                                {0, 4,  0, 0, 1, 16}
            };
            Application.Run(new Resultados(2, 2, 6, 3, matriz, "Max"));
            */


            // Inicia aplicacion desde ventana Inicio
            Application.Run(new Inicio());
        }
    }
}
