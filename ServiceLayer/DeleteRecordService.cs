public class DeleteRecordService:IDeleteRecord
{
    private readonly ToDoDbContext context;
    public DeleteRecordService(ToDoDbContext context)
    {
        this.context = context;
    }

    public int DeleteRecord(int id)
    {
        try
        {
             Record record=context.Records.Where(x=>x.RecordId==id).FirstOrDefault();
             context.Records.Remove(record);
             context.SaveChanges();
             return 0; 
        }
        catch (Exception ex)
        {
            return 1;
        }     

    }
}