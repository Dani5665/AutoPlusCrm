using AutoPlusCrm.Data.Models;
using AutoPlusCrm.ViewModels;

namespace AutoPlusCrm.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<FutureTaskViewModel>> ReturnViewForIndexPageAsync();

        Task<FutureTask> GetTaskByIdAsync(int taskId);
    }
}
