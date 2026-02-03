using Backend.App.Common.Interfaces;
using Backend.App.YsqForms.Dto;
using Backend.Domain.YsqFormAggregate;
using Backend.Infra.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.YsqForms.Persistence;

public class YsqFormRepo(
    BackendDbCtx db
) : IYsqFormRepo {
    public async Task<List<YsqFormSummaryDto>> ListAsync() {
        var ysqFormList = await db.YsqForms
            .AsNoTracking()
            .Select(x => new YsqFormSummaryDto {
                Id       = x.Id,
                FullName = x.FullName,
                Phone    = x.Phone
            })
            .ToListAsync();

        return ysqFormList;
    }

    public async Task AddAsync(YsqForm ysqForm) {
        await db.YsqForms.AddAsync(ysqForm);
    }

    public Task UpdateAsync(YsqForm ysqForm) {
        db.YsqForms.Update(ysqForm);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(YsqForm ysqForm) {
        db.YsqForms.Remove(ysqForm);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync() {
        await db.SaveChangesAsync();
    }

    public async Task<YsqForm?> GetOneByIdAsync(Guid ysqFormId, bool includeAnswers = false) {
        return await db.YsqForms.FirstOrDefaultAsync(u => u.Id == ysqFormId);
    }
}
