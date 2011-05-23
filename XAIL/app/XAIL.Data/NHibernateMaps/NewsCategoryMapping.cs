using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using XAIL.Core;

namespace XAIL.Data.NHibernateMaps
{
    public class NewsCategoryMapping : IAutoMappingOverride<NewsCategory>
    {
        public void Override(AutoMapping<NewsCategory> mapping)
        {
            mapping.Id(x => x.Id, "NewsCategoryId")
                .UnsavedValue(0)
                .GeneratedBy.Identity();

            mapping.Map(x => x.Name)
                .Not.Nullable()
                .Length(255);            
        }
    }
}
