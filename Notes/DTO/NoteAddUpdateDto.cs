using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Pika.Domain.Note.DTO
{
    public class NoteAddUpdateDto
    {
        [JsonProperty(PropertyName = "name")]
        [NotNull]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "content")]
        [NotNull]
        public string Content { get; set; }

        public Notes.Data.Note NewNote()
        {
            var n = new Notes.Data.Note {Name = this.Name, Content = this.Content};
            n.GenerateId();
            return n;
        }

        public Notes.Data.Note ToNote(string id)
        {
            var n = new Notes.Data.Note {Id = id, Name = this.Name, Content = this.Content};
            return n;
        }
    }
}