using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD.API.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class SearchAttribute : Attribute
    {
        public Type ClassTarget { get; set; }
        public string PropertyTarget { get; set; }
    }
}
