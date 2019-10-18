using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hamgooonWebServerV1.Request
{
    public class ReqForFollowedNewPosts
    {
        public long FollowerId { get; set; }
        public int MainCategory { get; set; }
        public int SubCategory { get; set; }
        // layer one means last post of all following , layer two means second post of the last of all following
        // layer begins from one
        public int Layer { get; set; }
    }
}
