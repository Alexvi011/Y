using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Yumiyaz
{
    class Abreme
    {
        // Importar la función SetCurrentConsoleFontEx desde la biblioteca kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int SetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow, ref CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx);

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CONSOLE_FONT_INFO_EX
        {
            public uint cbSize;
            public uint nFont;
            public COORD dwFontSize;
            public int FontFamily;
            public int FontWeight;
            public char[] FaceName;
        }

        static void Main(string[] args)
        {

            int wordCount = 0;
            // Cambiar el tamaño de la fuente a 24 (puedes ajustar el tamaño como desees)
            IntPtr hConsole = IntPtr.Zero;
            hConsole = GetStdHandle(-11);
            CONSOLE_FONT_INFO_EX fontInfo = new CONSOLE_FONT_INFO_EX();
            fontInfo.cbSize = (uint)Marshal.SizeOf(fontInfo);
            fontInfo.dwFontSize.X = 0;
            fontInfo.dwFontSize.Y = 70; // Tamaño de fuente en píxeles (altura)

            SetCurrentConsoleFontEx(hConsole, false, ref fontInfo);

            // Resto del código para imprimir el texto
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
                Console.Write("                        ");

            }
            string frase = "Recordatorio de que eres una persona extraordinaria. A veces, nos pasan cosas malas en la vida y tambien cosas buenas, pero es en esos malos momentos donde descubrimos la verdadera fortaleza que llevamos dentro. Puede que te sientas vulnerable, pero recuerda que a través de la vulnerabilidad también se encuentra la oportunidad de sanar y crecer. La felicidad y el amor propio son tesoros que mereces en abundancia. Permítete sanar, perdonar y aprender de todo esto. No mereceses pasar por tanto dolor. Tu pasado no dicta tu futuro, y estoy seguro de que grandes cosas te esperan. Rodéate de personas que te apoyen y te valoren por lo que eres. Recuerda que mereces ser amada, respetada y cuidada de una manera sana y positiva. Tienes un mundo de posibilidades frente a ti, y estoy emocionado por verte florecer y brillar. La vida tiene muchas sorpresas maravillosas reservadas para ti, de eso no me cabe duda. Mantén la cabeza siempre en alto y nunca olvides que eres una persona increíble y capaz de muchisimas cosas.";            var array = frase.Split(" ");
            foreach (var item in array)
            {
                Console.Write("");
                char[] arr;
                arr = item.ToCharArray();
                foreach (var item2 in arr)
                {
                    Console.Write(item2);
                    Thread.Sleep(100);
                }
                wordCount++;
                if (wordCount % 7 == 0)
                {
                    Console.WriteLine();
                    Console.Write("                        ");
                }
                else
                {
                    Console.Write(" "); // Agregar un espacio entre palabras
                }
            }
            Console.Write("                ");
            Console.ReadLine(); // Espera a que el usuario presione "Enter" antes de terminar.
        }

        // Importar la función GetStdHandle desde la biblioteca kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);
    }
}
