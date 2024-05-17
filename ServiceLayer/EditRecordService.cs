public class EditRecordService:IEditRecord
{
    private readonly ToDoDbContext context;
    public EditRecordService(ToDoDbContext context)
    {
        this.context = context;
    }

    public void EditRecord(int id, string title, string content)
    {
        throw new NotImplementedException();
    }
}