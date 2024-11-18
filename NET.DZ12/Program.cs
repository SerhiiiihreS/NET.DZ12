using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NET.DZ12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Backpack Medium = new Backpack("Rewt","China","Trgwebsjd dihhh",40,70);

            Medium.Notify += DisplayMessage;
            Medium.Put("Pen",20);
            Medium.Put("Shoes", 25);
            Medium.Put("Pen", 30);


            void DisplayMessage(Backpack sender, BackpackEventArgs e)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"In the backpack with the volume: {e.Thing+" - "+e.Volume+"l"}");
                Console.WriteLine(e.Message);
                Console.WriteLine($"Free space: {sender.Volume + "l"}");
                Console.WriteLine();
            }
        }
    }
}
