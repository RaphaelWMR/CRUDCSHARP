using System;
using ML;
using BL;
using System.Collections.Generic;

namespace ConsoleDemoDB
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabajando con Base da datos en C#");
            CarreraBL contexto = new CarreraBL();
            contexto.SearchCarrera("Enfer");
            
        }
    }
}
