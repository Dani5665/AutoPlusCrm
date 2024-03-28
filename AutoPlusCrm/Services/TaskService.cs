using AutoPlusCrm.Contracts;
using AutoPlusCrm.Data.Models;
using AutoPlusCrm.Data;
using Microsoft.AspNetCore.Identity;
using AutoPlusCrm.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AutoPlusCrm.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> userManager;
        public TaskService(ApplicationDbContext _data, UserManager<ApplicationUser> _userManager)
        {
            data = _data;
            userManager = _userManager;
        }

        public async Task<FutureTask> GetTaskByIdAsync(int taskId)
        {
             var task = await data.Tasks
            .FirstOrDefaultAsync(t => t.Id == taskId);

            return task;
        }

        public async Task<IEnumerable<FutureTaskViewModel>> ReturnViewForIndexPageAsync()
        {
            var tasks = await data.Tasks
                     .AsNoTracking()
                     .Include(t => t.ApplicationUser)
                     .Include(t => t.Client)
                     .Include(t => t.RetailerStore)
                     .Select(t => new FutureTaskViewModel(
                         t.Id,
                         t.TaskDescription,
                         t.DateAndTime,
                         t.City,
                         t.Region,
                         t.Iscompleted,
                         t.ApplicationUserId,
                         t.ApplicationUser,
                         t.ClientId,
                         t.Client,
                         t.RetailerStoreId,
                         t.RetailerStore))
                     .ToListAsync();

            return tasks;
        }
    }
}
