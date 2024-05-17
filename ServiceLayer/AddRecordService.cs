public class AddRecordService:IAddRecord
{
    private readonly ToDoDbContext context;
    public AddRecordService(ToDoDbContext context)
    {
        this.context = context;
    }

    public void AddRecord(string title, string content)
    {
        context.Records.Add(new Record(){Title = title, Content = content});
    }
}