using Backend.App.YsqForms.Dto;
using Backend.Domain.YsqFormAggregate;

namespace Backend.App.Common.Interfaces;

public interface IYsqFormRepo {
    Task<List<YsqFormSummaryDto>> ListAsync();
    Task<YsqForm?>                GetOneByIdAsync(Guid ysqFormId, bool includeAnswers = false);
    Task                          AddAsync(YsqForm     ysqForm);
    Task                          UpdateAsync(YsqForm  ysqForm);
    Task                          RemoveAsync(YsqForm  ysqForm);
    Task                          SaveChangesAsync();
}
