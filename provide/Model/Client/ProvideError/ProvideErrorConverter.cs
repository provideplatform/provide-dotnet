using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace provide.Model.Client.ProvideError
{
    // we need converter because sometimes errors are returned as array, and sometimes as single string
    // this will give us flexibility to use one error type all the time
    public class ProvideErrorConverter : JsonConverter
    {
        public ProvideErrorConverter()
        {
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsClass;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = Activator.CreateInstance(objectType);
            var props = objectType.GetTypeInfo().DeclaredProperties.ToList();
            var errorProp = JObject.Load(reader).Properties().ElementAt(0);
            // for now this is either errors array or one message 
            if (errorProp.Name == "message")
            {
                Error[] val = { new Error { Message = errorProp.Value.ToObject<string>(serializer) }};
                props[0].SetValue(instance, val);
            }
            else
            {
                props[0].SetValue(instance, errorProp.Value.ToObject<Error[]>(serializer));
            }

            return instance;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}