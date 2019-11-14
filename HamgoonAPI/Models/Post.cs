using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamgoonAPI.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string UniqueUrl { get; set; }
        public long PublisherId { get; set; }
        public string PublisherProfileImg { get; set; }
        public string PublisherUsername { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string PostSummary { get; set; }
        public string PostType { get; set; }
        public string FirstTag { get; set; }
        public string SecondTag { get; set; }
        public string ThirdTag { get; set; }
        public string FourthTag { get; set; }
        public int Number { get; set; }
        public int MainCategory { get; set; }
        public int SubCategory { get; set; }
        public int Kind { get; set; }
        public bool IsDrafted { get; set; }
        public string coverImgUrl { get; set; }
        public int CommentCount { get; set; }
        public int JudgesCount { get; set; }
        public double PostRate { get; set; }
    }
}
