using System.ComponentModel.DataAnnotations.Schema;

namespace TheBesShopping.Models.Data
{
    public class test_table
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("name")]
        public string name { get; set; }
    }
}
