using BD.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BD.Business.Interfaces
{
    public interface ITrackable
    {
        int CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }

        int UpdatedBy { get; set; }
        DateTime LastUpdatedAt { get; set; } 
    }
}
