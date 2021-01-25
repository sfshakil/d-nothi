using dNothi.JsonParser.Entity.Nothi;

namespace dNothi.JsonParser
{
    public interface INoteListParser
    {
        NoteAllListResponse ParseMessage(string messageString);
    }
}