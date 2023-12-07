using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace Pika.Domain.Storage.Data
{
    public class StorageIndexRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Required] 
        public string Hash { get; set; } = "";

        [Required] 
        public string ObjectName { get; set; } = "";

        [Required] 
        public string BucketId { get; set; } = "";

        [Required]
        public bool Expires { get; set; }

        [Required] public DateTime ExpireDate { get; set; } = ComputeDateTime();

        public static DateTime ComputeDateTime()
        {
            return DateTime.UtcNow.AddDays(10);
        }
    }
}
