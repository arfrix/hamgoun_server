using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hamgooonWebServerV1.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public long PublisherId { get; set; }
        public long PostId { get; set; }
        public bool IsReply { get; set; }
        //  Parentcomment is id of the comment that we reply to
        public long ParentCommentId { get; set; }
        public string CommentText { get; set; }
        public int Number { get; set; }
        public int Mizoun { get; set; }
        public int Namizoun { get; set; }
        public string PublisherImg { get; set; }
        public string PublisherUsername { get; set; }
        public int Score { get; set; }
    }
}
