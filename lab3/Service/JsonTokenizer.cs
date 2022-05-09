using lab3.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab3.Service
{
    public static class JsonTokenizer
    {
        // State A - outside " "
        // State B - inside ""
        // State C - after /


        private static List<JsonToken> Tokenize(string json)
        {
            List<JsonToken> result = new List<JsonToken>();
            char state = 'A';
            int begPos = 0, endPos = 0;

            foreach(var symb in json)
            {
                switch (state)
                {
                    case 'A':
                        if (symb == ' ' || symb == '\t' || symb == '\n')
                        {
                            if (begPos != endPos)
                                result.Add(new JsonToken() { Content = json[begPos..endPos], Type = "S" });
                            begPos = -~endPos;
                        }
                        else if (",{}[]:".Contains(symb))
                        {
                            if (begPos != endPos)
                                result.Add(new JsonToken() { Content = json[begPos..endPos], Type = "S" });
                            result.AddOneSymbToken(symb);
                            begPos = -~endPos;
                        }
                        else if (symb == '"')
                        {
                            begPos = endPos;
                            state = 'B';
                        }
                        break;
                    case 'B':
                        if(symb == '"')
                        {
                            result.Add(new JsonToken() { Content = json[~-begPos..endPos], Type = "S" });
                            state = 'A';
                            begPos = -~endPos;
                        }else if(symb == '\\')
                        {
                            state = 'C';
                        }
                        break;
                    case 'C':
                        if (symb == '"' || symb == '\\')
                            state = 'B';
                        else
                            throw new Exception("syntax error");
                        break;
                }
                endPos++;
            }
            return result;
        }

        //Symantic tree reducer rules
        // S:[SDA] -> P(dict Pair)
        // {P(,P)*} -> D(Dict)
        // []

        private static JsonToken BuildTree(List<JsonToken> tokens)
        {
            while(tokens.Count > 1)
            {
                string code = string.Join("", tokens.Select(x => x.Type));
                if (Regex.IsMatch(code, @"S:[SDA]"))
                {
                    var match = Regex.Match(code, @"S:[SDA]");
                    var subList = tokens.Skip(match.Index).Take(match.Length).ToList();

                    var newToken = new JsonToken() { Type = "P", Childs = subList };
                    tokens.ReduceList(match.Index, match.Length, newToken);
                }
                else if (Regex.IsMatch(code, @"{P(?>,P)*}"))
                {
                    var match = Regex.Match(code, @"{P(?>,P)*}");
                    var subList = tokens.Skip(match.Index).Take(match.Length).ToList();

                    var newToken = new JsonToken() { Type = "D", ChildDict = new Dictionary<string, JsonToken>()};
                    for (int i=1; i<subList.Count; i += 2) //i+=2 skip ","
                        newToken.ChildDict[subList[i].Childs[0].Content] = subList[i].Childs[2];
                    tokens.ReduceList(match.Index, match.Length, newToken);
                }
                else if(Regex.IsMatch(code, @"\[[SDA](?>,[SDA])*\]"))
                {
                    var match = Regex.Match(code, @"\[[SDA](?>,[SDA])*\]");
                    var subList = tokens.Skip(match.Index).Take(match.Length).ToList();

                    var newToken = new JsonToken() { Type = "A", Childs = new List<JsonToken>()};
                    for (int i = 1; i < subList.Count; i += 2) //i+=2 skip ","
                        newToken.Childs.Add(subList[i]);
                    tokens.ReduceList(match.Index, match.Length, newToken);
                }
                else
                {
                    throw new Exception("Semantic error");
                }
            }
            return tokens[0];
        }

        private static void ReduceList(this List<JsonToken> tokens, int ind, int count, JsonToken newElem)
        {
            tokens.RemoveRange(ind, count);
            tokens.Insert(ind, newElem);
        }

        public static JsonToken ToJsonTree(string json)
        {
            var tokens = Tokenize(json);
            return BuildTree(tokens);
        }

        private static void AddOneSymbToken(this List<JsonToken> tokens, char symb) => tokens.Add(new JsonToken() { Content = symb.ToString(), Type = symb.ToString() });
    }
}
