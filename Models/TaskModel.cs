using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TaskTracker.Models
{
    public class TaskModel
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required Status Status { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
