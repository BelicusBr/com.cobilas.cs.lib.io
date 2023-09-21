using System;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace Cobilas.IO.Serialization.Json {
    public class JsonContractResolver : DefaultContractResolver {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
            if (type.GetCustomAttribute<SerializableAttribute>() is null)
                throw new JsonSerializationException($"The {type} class does not have the Serializable attribute");
            List<JsonProperty> props = new List<JsonProperty>();
            foreach (var item in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                if (item.GetCustomAttribute<NonSerializedAttribute>() == null)
                    props.Add(base.CreateProperty(item, memberSerialization));
            }

            props.ForEach(p => { p.Writable = true; p.Readable = true; });
            return props;
        }
    }
}
