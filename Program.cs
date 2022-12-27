using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Newtonsoft.Json;

namespace PW_6
{
    public class Program
    {
        static void Main()
        {
            Choice_and_Read_File.GettingLink();
            Console.WriteLine("Нажмите F1 для сохранения файла\n" +
                "или ESC для выхода из программы");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.F1:
                    Console.WriteLine("Сохраниние");
                    Choice_and_Read_File.Read_File();
                    break;

                case ConsoleKey.Escape:
                    Console.WriteLine("Выход из программы");
                    break;
            }
        }
    }
}