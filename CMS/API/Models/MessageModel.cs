using System;
using System.Collections.Generic;

namespace API.Models
{
    public class MessageModel<T>
    {
        public int Status { get; set; }
        public List<T> Msg { get; set; }
    }
}
