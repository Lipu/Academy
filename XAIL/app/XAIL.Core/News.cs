using System;
using NHibernate.Validator.Constraints;
using SharpArch.Core;
using SharpArch.Core.DomainModel;

namespace XAIL.Core
{
    public class News : Entity
    {
        public News() { }

        public News(string title)
        {
            Check.Require(!string.IsNullOrEmpty(title) && title.Trim() != String.Empty, "title must be provided");
            Title = title;
            CreatedAt = DateTime.Now;
        }

        [DomainSignature]
        [NotNullNotEmpty(Message = "Title must be provided")]
        public virtual string Title { get; set; }

        [NotNullNotEmpty(Message = "Body must be provided")]
        public virtual string Body { get; set; }

        public virtual DateTime CreatedAt { get; protected set; }
    }
}
