using Skydiving.Infrastructure.Data.Common;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels.Admin;

namespace Skydiving.Core.Services
{
    public class StatisticAdministrationService
    {
        private readonly IRepository repo;
        public StatisticAdministrationService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<StatisticViewModel> StatisticAsync()
        {

            /*Pending
            Approved
            Declined
            Deleted
            Completed*/

            int allJumps = repo.AllReadonly<Jump>().Count();
            int activeJumps = repo.AllReadonly<Jump>().Where(x => x.Status == "Active").Count();
            int completedJumps = repo.AllReadonly<Jump>().Where(x => x.Status == "Completed").Count();
            int pendingJumps = repo.AllReadonly<Jump>().Where(x => x.Status == "Pending").Count();
            int declinedJumps = repo.AllReadonly<Jump>().Where(x => x.Status == "Declined").Count();

            return new StatisticViewModel()
            {
                ActiveJumps = activeJumps,
                AllJumps = allJumps,
                PendingJumps = pendingJumps,
                DeclinedJumps = declinedJumps,
                CompletedJumps = completedJumps
            };
        }
    }
}
