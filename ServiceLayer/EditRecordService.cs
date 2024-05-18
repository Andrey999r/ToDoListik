public class EditRecordService:IEditRecord
{
    private readonly ToDoDbContext context;
    public EditRecordService(ToDoDbContext context)
    {
        this.context = context;
    }

    public int EditRecord(int id, string title, string content)
    {
       try
        {
             Record record=context.Records.Where(x=>x.RecordId==id).FirstOrDefault();
             record.Title = title;
             record.Content = content;
             context.SaveChanges();
             return 0; 
        }
        catch (Exception ex)
        {
            return 1;
        } 
    }
}