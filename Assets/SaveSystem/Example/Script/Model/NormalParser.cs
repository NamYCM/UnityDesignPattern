using SaveSystem.Parser;

namespace TestSaveSystem
{
    public class NormalParser : IParser
    {
        public string Decode(string code)
        {
            return code;
        }

        public string Encode(string data)
        {
            return data;
        }
    }
}