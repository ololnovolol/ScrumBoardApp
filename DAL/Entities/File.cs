using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    internal class File : BaseEntitiy
    {
        public string Title { get; set; }
        public byte[] Data { get; set; }
    }
}
