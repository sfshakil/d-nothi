using System.Data.Entity.ModelConfiguration;

namespace dNothi.Infrastructure.Mapping
{
    public abstract class NothiEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected NothiEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
    }
}