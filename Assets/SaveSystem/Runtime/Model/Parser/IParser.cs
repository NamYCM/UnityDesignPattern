namespace SaveSystem.Parser
{
    public interface IParser
    {
        string Encode(string data);
        string Decode(string code);
    }
}