using dNothi.JsonParser.Entity;

namespace dNothi.JsonParser
{
    public interface IUserMessageParser
    {
        UserMessage ParseMessage(string messageString);
    }
}