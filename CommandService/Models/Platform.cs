using System.ComponentModel.DataAnnotations;

namespace CommandService.Models
{
    public class Platform{
        [Key]
        [Required]
        public int Id { get; set; }
        
        //Unique ID given to us by Platform service
        [Required]
        public int ExternalID { get; set; }
        
        [Required]
        public int Name { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}