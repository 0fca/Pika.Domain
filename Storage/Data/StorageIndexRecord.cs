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
        public int Urlid { get; set; }

        [Required] 
        public string Urlhash { get; set; } = "";

        [Required] 
        public string AbsolutePath { get; set; } = "";

        [Required] 
        public string UserId { get; set; } = "";

        [Required]
        public bool Expires { get; set; }

        [Required] public DateTime ExpireDate { get; set; } = ComputeDateTime();

        public static DateTime ComputeDateTime()
        {
            return DateTime.Now.AddDays(10);
        }
    }
}
