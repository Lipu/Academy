using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using XAIL.Core.Security;

namespace XAIL.Data.NHibernateMaps
{
    public class UsersMapping : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.Id(x => x.Id, "UserId")
                .UnsavedValue(0)
                .GeneratedBy.Identity();

            mapping.Map(x => x.Username)
                .Not.Nullable()
                .Length(255);

            mapping.Map(x => x.Email)
                .Not.Nullable()
                .Length(255);

            mapping.Map(x => x.Password)
                .Not.Nullable()
                .Length(255);

            mapping.Map(x => x.PasswordSalt)
                .Not.Nullable()
                .Length(255);
        }
    }
}
