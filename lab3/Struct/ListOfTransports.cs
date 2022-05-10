using lab3.Interfaces;
using lab3.Service;
using lab3.Transports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Struct
{

    delegate object Deserialize(string json);
    public class ListOfTransports : IJsonSerializeble, IEnumerable
    {
        private List<Transport> _container = new List<Transport>();

        private Dictionary<string, IJsonSerializeble> _builder = new Dictionary<string, IJsonSerializeble> {
            {new Jet().ClassName(), new Jet() },
            {new CargoShip().ClassName(), new CargoShip() },
            {new Plane().ClassName(), new Plane() },
            {new Tanker().ClassName(), new Tanker() }
        };
        public Transport this[int index] { get => _container[index]; set => _container[index]=value; }

        public int Count => _container.Count;


        public void Add(Transport item) => _container.Add(item);
        public void RemoveAt(int index) => _container.RemoveAt(index);

        public IEnumerator<Transport> GetEnumerator() => _container.GetEnumerator();
        public object FromJson(JsonToken json)
        {
            ListOfTransports transports = new();
            foreach(var key in json.Childs)
            {
                var newTrn = _builder[key.ChildDict.Keys.First()].FromJson(key.ChildDict.Values.First());
                transports.Add((Transport)newTrn);
            }
            return transports;
        }


        public string ToJson() => $@"[{string.Join(",", _container.Select(x => $@"{{""{x.ClassName()}"":{x.ToJson()}}}"))}]";

        public string ClassName() => "listOfTransport";

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_container).GetEnumerator();
    }
}
