using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Models
{
    public class Specification
    {
        //PODnMOD
        public int Id { get; set; }
        public string AccumCapacity { get; set; }

        public string Screen { get; set; }
        public string BuiltInAccum { get; set; }

        public string MaxVoltage { get; set; }

        public string VoltageChange { get; set; }

        public string BakValue { get; set; }
        //Expandable
        public string PuffCol { get; set; }
        //Liquids
        public string Flavour { get; set; }
        public string Vgpg { get; set; }

        public string Nic { get; set; }

        public string  NicProp { get; set; }

        public string LiqValue { get; set; }

        //Atomizer
        public string MTL { get; set; }
        public string Spiral { get; set; }

        public string Obduv { get; set; }

        public string Type { get; set; }

        //Battery

        public string Amper { get; set; }

        //Other
        public string Length { get; set; }
        public string Size { get; set; }
        public string Width { get; set; }
        public string Weigth { get; set; }
        public string CharghingTime { get; set; }


        public int ProductId { get; set; }

        public Product Products { get; set; }
    }
}
