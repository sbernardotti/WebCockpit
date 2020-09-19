namespace WebCockpit.Application.Interfaces
{
    public interface IWriteService
    {
        void Write(string eventName, uint data);
    }
}
