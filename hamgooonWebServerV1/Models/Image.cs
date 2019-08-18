using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hamgooonWebServerV1.Models
{
    public class Image
    {
        public long Id { get; set; }
        public long PublisherId { get; set; }
        public string url { get; set; }

    }
}
