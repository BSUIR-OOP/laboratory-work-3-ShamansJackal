using System.Collections.Generic;

namespace lab3.Struct
{
    public class JsonToken
    {
        // K - Key
        // A - Array
        // D - Dict
        // S - String
        // P - Pair

        public string Type;
        public List<JsonToken> Childs;
        public Dictionary<string, JsonToken> ChildDict;
        public string Content;

        public override string ToString() => $"Type({Type}) : Content({Content})";
    }
}
