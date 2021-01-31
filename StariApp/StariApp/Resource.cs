using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StariApp
{
    class Resource
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double mass { get; set; }
        public string metric { get; set; }

        public string ToString()
        {
            return Id + " | " + name + " | " + price + " | " + mass + " | " + metric;
        }

    }
}
