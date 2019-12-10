using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamgoonAPI.Request
{
    public class ReqForMyPostList
    {
        public long PublisherId { get; set; }

        public int MainCategory { get; set; }
        public int SubCategory { get; set; }
    }
}
