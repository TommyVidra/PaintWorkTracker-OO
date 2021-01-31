using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StariApp
{
    public class Worker
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string name { get; set;}
        public string lastName { get; set;}
        public int position { get; set;}
    }
}
