public class DeleteRecordService:IDeleteRecord
{
    private readonly ToDoDbContext context;
    public DeleteRecordService(ToDoDbContext context)
    {
        this.context = context;
    }

    public void DeleteRecord(int id)
    {
        var record=context.Records.Where(x=>x.RecordId==id).FirstOrDefault();
        context.Records.Remove(record);
    }
}