namespace Hamgoon.API.Models
{
    public class Event
    {
        public long Id { get; set; }
        public long ActorId { get; set; }
        public string ActorUsername { get; set; }
        public string ActorImgUrl { get; set; }
        public long ReactorId { get; set; }
        public long PostId { get; set; }
        public long CommentId { get; set; }
        public bool IsComment { get; set; }
        public bool IsCommentReply { get; set; }
        public bool IsMizoun { get; set; }
        public bool IsNamizoun { get; set; }
        public bool IsPostRating { get; set; }
        public int PostRate { get; set; }

    }
}

