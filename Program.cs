using System.Numerics;
using System;
using System.Net.NetworkInformation;
using WorldOfWarships2;

internal class Program
{
    private static void Main(string[] args)
    {
        void Gamemode()
        {    
            Console.ForegroundColor = ConsoleColor.Yellow;    
            Console.WriteLine("                       [ World Of  Warships 2 ]       \n");    //𓊝      ⚓︎     
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                           Select  gamemode:         ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("A ~ PvP (Against another player) || B ~ PvAAIA (Against Advanced AI Admiral)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            string A = Console.ReadLine().ToUpper();
            if (A.Length == 1)
            {
                if (A[0] == 'A')
                {
                    Console.Clear();
                    PvP.Play();
                }
                else if (A[0] == 'B')
                {
                    Console.Clear();
                    AAIA.Play();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nIncorrect Letter Put In! Type Anything Or Press Enter Key To Restart.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    Gamemode();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nIncorrect Letter Put In! The Letter Must NOT Be Preceeded With Spaces. Type Anything Or Press Enter Key To Restart.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Gamemode();
            }
        }  
        Gamemode();    
    }
}