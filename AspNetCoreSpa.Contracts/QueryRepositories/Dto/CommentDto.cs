﻿using System;

namespace AspNetCoreSpa.Contracts.QueryRepositories.Dto
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string CommentDescription { get; set; }
        public DateTime CommentCreateAt { get; set; }
        public DateTime CommentUpdateAt { get; set; }
    }
}