
public class ShowAllRecordsService:IShowAllRecords
{
    private readonly ToDoDbContext context;
    public ShowAllRecordsService(ToDoDbContext context)
    {
        this.context = context;
    }

    public IList<Record> ShowAllRecords()
    {
        return context.Records.ToList();
    }
}