public class AddRecordService:IAddRecord
{
    private readonly ToDoDbContext context;
    public AddRecordService(ToDoDbContext context)
    {
        this.context = context;
    }

    public int AddRecord(string title, string content)
    {
        try
        {
             Record record= new Record(){Title=title,Content=content};
             context.Records.Add(record);
             context.SaveChanges();        
             return 0; 
        }
        catch (Exception ex)
        {
            return 1;
        } 
    }
}