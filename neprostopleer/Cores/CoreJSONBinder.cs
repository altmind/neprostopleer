using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using neprostopleer.Entities.WS;
using System.Runtime.Serialization.Json;
using System.IO;

namespace neprostopleer.Cores
{
    class CoreJSONBinder
    {
        private DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(LoginResponse));
        private IDictionary<Type, DataContractJsonSerializer> serializers = new Dictionary<Type,DataContractJsonSerializer>();
        private void AddTypeToDictionaryIfNotPresent(Type t)
        {
            if (!serializers.ContainsKey(t))
            {
                serializers.Add(t, new DataContractJsonSerializer(t));
            }
        }
        public T Unmarshal<T>(string s)
        {
            AddTypeToDictionaryIfNotPresent(typeof(T));
            byte[] byteArray = Encoding.UTF8.GetBytes(s);
            Stream stream = new MemoryStream(byteArray);
            return (T)serializers[typeof(T)].ReadObject(stream);
        }
        public T Unmarshal<T>(Stream s)
        {
            AddTypeToDictionaryIfNotPresent(typeof(T));

            return (T)serializers[typeof(T)].ReadObject(s);
        }
        public string MarshalAsString<T>(T obj)
        {
            AddTypeToDictionaryIfNotPresent(typeof(T));
            Stream stream = new MemoryStream();
            StreamReader streamReader = new StreamReader(stream);
            serializers[typeof(T)].WriteObject(stream, obj);
            return streamReader.ReadToEnd();
        }
        public Stream MarshalAsStream<T>(T obj)
        {
            AddTypeToDictionaryIfNotPresent(typeof(T));
            Stream stream = new MemoryStream();
            serializers[typeof(T)].WriteObject(stream, obj);
            return stream;
        }
    }
}
