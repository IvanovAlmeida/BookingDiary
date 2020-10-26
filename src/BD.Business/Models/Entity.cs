using BD.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Business.Models
{
    public class Entity : ITrackable, IIsDeleted
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
        
        public DateTime? DisabledAt { get; set; }

        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int DisabledBy { get; set; }
    }
}
