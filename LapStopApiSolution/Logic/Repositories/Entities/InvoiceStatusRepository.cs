﻿using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class InvoiceStatusRepository : AbstractRepository<InvoiceStatus>, IInvoiceStatusRepository
    {
        public InvoiceStatusRepository(LapStopContext context) : base(context)
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