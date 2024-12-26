using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public string Location { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime? DueDate { get; set; }

        public int? ReaderId { get; set; }

        [ForeignKey("ReaderId")]
        public Reader Reader { get; set; }
    }
}