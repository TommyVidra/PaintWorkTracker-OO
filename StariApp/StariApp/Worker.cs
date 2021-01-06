using System.ComponentModel.DataAnnotations;

namespace StariApp
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set;}
        public string lastName { get; set;}
        public int position { get; set;}
    }
}
