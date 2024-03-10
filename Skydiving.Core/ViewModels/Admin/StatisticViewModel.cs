namespace Skydiving.Core.ViewModels.Admin
{
    public class StatisticViewModel
    {
        public int AllJumps { get; set; }
        public int ActiveJumps { get; set; }
        public int PendingJumps { get; set; }
        public int DeclinedJumps { get; set; }
        public int CompletedJumps { get; set; }
    }
}
