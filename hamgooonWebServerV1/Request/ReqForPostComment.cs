using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hamgooonWebServerV1.Models;

namespace hamgooonWebServerV1.Request
{
    public class ReqForPostComment
    {
        public Comment Comment { get; set; }
        public long PostPublisherId { get; set; }
        public long ParentCommentPublisherId { get; set; }
    }
}
