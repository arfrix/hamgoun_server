using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hamgoon.API.Models;

namespace HamgoonAPI.Request
{
    public class ReqForPostComment
    {
        public Comment Comment { get; set; }
        public long PostPublisherId { get; set; }
        public long ParentCommentPublisherId { get; set; }
    }
}
