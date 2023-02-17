using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Pika.Domain.Status.Models;
using IssueEntity = Pika.Domain.Status.Data.IssueEntity;
using MessageEntity = Pika.Domain.Status.Data.MessageEntity;

namespace Pika.Domain.Status.DTO
{
    public class MessageDto
    {
        [Required]
        [NotNull]
        public int Id { get; set; }
        
        [Required]
        [NotNull]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [AllowNull]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required] 
        [NotNull] 
        [StringLength(1000, ErrorMessage = "Message should not be longer than {1} and has at least {2}", MinimumLength = 10)]
        public string Message { get; set; } = "";
        
        [Required]
        public MessageType MessageType { get; set; } = MessageType.None;
        
        [Required]
        public IList<IssueEntity> RelatedIssues { get; set; } = new List<IssueEntity>();

        [NotNull]
        public string SystemName { get; set; } = "";

        public static MessageDto FromMessageEntity(MessageEntity e)
        {
            return new MessageDto()
            {
                Id = e.Id,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt,
                RelatedIssues = e.RelatedIssues,
                Message = e.Message,
                MessageType = e.MessageType,
                SystemName = e.SystemDescriptor.SystemName
            };
        }
    }
}