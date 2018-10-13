using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Core.Domains
{
    public class Comments
    {
        public Guid Id { get; protected set; }

        public string UserName { get; } = "Anonymous";

        public string Title { get; private set; }

        public string Content { get; private set; }

        public Rating Rating { get; private set; }

        public Comments(string title, string content, Rating rating)
        {
            Title = title;
            Content = content;
        }
        public Comments(string title, string content, Rating rating, string userName)
        {
            Title = title;
            Content = content;
            UserName = userName;
        }
    }
}
