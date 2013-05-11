﻿namespace Disqus.Comments.Models
{
    using System;

    public class DisqusPost
    {
        public string Id { get; set; }        

        public DisqusAuthor Author { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public DisqusThread Thread { get; set; }
    }
}