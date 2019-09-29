using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hamgooonWebServerV1.Models
{
    public class RatingEvent
    {
        public long Id { get; set; }
        public long JudgeId { get; set; }
        public long PostId { get; set; }
        public long CommentId { get; set; }
        public bool IsMizoun { get; set; }
        public bool IsNamizoun { get; set; }
        public bool IsPostRating { get; set; }
        public int PostRate { get; set; }

    }
}

