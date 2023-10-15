namespace WebTasks.Data.DataLayer
{
    public static class Inizializer
    {
        public static void Inizialize(TaskDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
