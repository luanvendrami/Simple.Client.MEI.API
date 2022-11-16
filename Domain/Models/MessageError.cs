using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class MessageError
    {
        public List<string>? Message { get; set; }
    }
}
