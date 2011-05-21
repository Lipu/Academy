using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using XAIL.Core;

namespace XAIL.Data.NHibernateMaps
{
    public class NewsMapping : IAutoMappingOverride<News>
    {
        public void Override(AutoMapping<News> mapping)
        {
            mapping.Id(x => x.Id, "NewsId")
                .UnsavedValue(0)
                .GeneratedBy.Identity();

            mapping.Map(x => x.Title)
                .Not.Nullable()
                .Length(255);

            mapping.Map(x => x.Body)
                .Length(10000);

            mapping.Map(x => x.CreatedAt)
                .Not.Nullable();
        }
    }
}
