﻿using Newtonsoft.Json;

namespace Pika.Domain.Notes.Data
{
    public class Note
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
        
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public void Update(Note n)
        {
            this.Name = n.Name;
            this.Content = n.Content;
            this.Timestamp = DateTime.UtcNow;
        }

        public void GenerateId()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}