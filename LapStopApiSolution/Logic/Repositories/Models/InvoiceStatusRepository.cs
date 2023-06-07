namespace Repositories.Models
{
    internal sealed class InvoiceStatusRepository : RepositoryBase<InvoiceStatus>, IInvoiceStatusRepository
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
