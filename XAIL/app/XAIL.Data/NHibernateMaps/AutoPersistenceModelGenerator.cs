using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using XAIL.Core;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;

namespace XAIL.Data.NHibernateMaps
{

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {

        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            return AutoMap.AssemblyOf<News>(new AutomappingConfiguration())
                .Conventions.Setup(GetConventions())
                .IgnoreBase<Entity>()
                .IgnoreBase(typeof(EntityWithTypedId<>))
                .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
        }

        #endregion

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<XAIL.Data.NHibernateMaps.Conventions.ForeignKeyConvention>();
                c.Add<XAIL.Data.NHibernateMaps.Conventions.HasManyConvention>();
                c.Add<XAIL.Data.NHibernateMaps.Conventions.HasManyToManyConvention>();
                c.Add<XAIL.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention>();
                c.Add<XAIL.Data.NHibernateMaps.Conventions.PrimaryKeyConvention>();
                c.Add<XAIL.Data.NHibernateMaps.Conventions.ReferenceConvention>();
                c.Add<XAIL.Data.NHibernateMaps.Conventions.TableNameConvention>();
            };
        }
    }
}
