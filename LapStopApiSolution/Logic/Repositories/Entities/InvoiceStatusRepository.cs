﻿namespace Repositories.Entities
{
    internal sealed class InvoiceStatusRepository : AbstractEntityRepository<InvoiceStatus>, IInvoiceStatusRepository
    {
        public InvoiceStatusRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }

        public async Task<IEnumerable<InvoiceStatus>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<InvoiceStatus?> GetOneByIdAsync(bool isTrackChanges, Guid invoiceStatusId)
        {
            return await FindByCondition(isTrackChanges, i => i.Id == invoiceStatusId).FirstOrDefaultAsync();
        }
    }
}
