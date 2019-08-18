using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hamgooonWebServerV1.Models
{
    public class Relation
    {
        public long Id { get; set; }
        public long FollowerId { get; set; }
        public long FollowedId { get; set; }
        public int EngagementRate { get; set; }
        public int MainCategory { get; set; }
        public int SubCategory { get; set; }
        public int LastSeenPostNumber { get; set; }
        public int TotalPostNumber { get; set; }
    }
}
