using System;
using NHibernate.Validator.Constraints;
using SharpArch.Core;
using SharpArch.Core.DomainModel;

namespace XAIL.Core
{
    public class NewsCategory : Entity
    {
        public NewsCategory() { }

        public NewsCategory(string name)
        {
            Check.Require(!string.IsNullOrEmpty(name) && name.Trim() != String.Empty, "name must be provided");
            Name = name;
        }

        [DomainSignature]
        [NotNullNotEmpty(Message = "Name must be provided")]
        public virtual string Name { get; set; }
    }
}
