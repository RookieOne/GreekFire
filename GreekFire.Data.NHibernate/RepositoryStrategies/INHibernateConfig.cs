namespace GreekFire.Data.NHibernate.RepositoryStrategies
{
    public interface INHibernateConfig
    {
        string DatabaseName { get; }
        string Server { get; }
    }
}