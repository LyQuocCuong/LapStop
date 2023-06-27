namespace Repositories.Parameters
{
    internal sealed class EntityRepositoryParams
    {
        public readonly LapStopContext Context;
        public readonly IDomainRepositories DomainRepositories;

        public EntityRepositoryParams(LapStopContext context, IDomainRepositories domainRepositories)
        {
            Context = context;
            DomainRepositories = domainRepositories;
        }

    }
}
