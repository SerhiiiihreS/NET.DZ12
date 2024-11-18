using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NET.DZ12
{
    internal class Backpack
    {
        public string Color {  get; set; }
        public string Manufacturer { get; set; }
        public string Fabric { get; set; }
        public int Weight { get; set; }
        public int Volume { get; private set; }
        public Backpack() { }   

        public Backpack(string color, string manufacturer, string fabric,int weight, int volume)
        {
            Color = color;
            Manufacturer = manufacturer;
            Fabric = fabric;
            Weight = weight;
            Volume = volume;
                
        }
        public void Input()
        {
            Console.WriteLine("Color ->");
            Color=Console.ReadLine();
            Console.WriteLine("Manufacturer ->");
            Manufacturer =Console.ReadLine();
            Console.WriteLine("Fabric ->");
            Fabric =Console.ReadLine();
            Console.WriteLine("Weight ->");
            Weight =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Volume ->");
            Volume =Convert.ToInt32(Console.ReadLine());
        }
        public delegate void BackpackHandler(Backpack sender, BackpackEventArgs e);
        public event BackpackHandler Notify;

        


        public void Put(string thing, int vol)
        {
            if (Volume >= vol)
            {
                Volume -= vol;
                Notify?.Invoke(this, new BackpackEventArgs($"They put something in the backpack with the volume {vol}", vol, thing));
            }
            else
            {
                Notify?.Invoke(this, new BackpackEventArgs("There is not enough free space.",  vol, thing));
            }

        }
        
    }

    class BackpackEventArgs
    {
        public string Thing { get;  }
        public string Message { get; }
        public int Volume { get; }
        public BackpackEventArgs(string message, int vol, string thing)
        {
            Message = message;
            Volume = vol;
            Thing = thing;
        }
    }
}
