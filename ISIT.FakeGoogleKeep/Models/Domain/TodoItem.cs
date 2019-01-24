using System;
using System.ComponentModel.DataAnnotations;

namespace ISIT.FakeGoogleKeep.Models.Domain
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string OwnerId { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTimeOffset? DueAt { get; set; }
    }
}
