using System.ComponentModel.DataAnnotations;

namespace Vega.Domain
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        public int MakeId { get; set; }

        public Make Make { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}