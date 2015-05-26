using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Quaider.Component.Extensions
{
    /// <summary>
    /// Json操作类
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// 将object序列化成Json字符串
        /// </summary>
        /// <param name="source">object</param>
        /// <param name="camel">属性是否启用骆驼写法</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(this object source, bool camel = true)
        {
            return new JsonOperation(camel).Serialize(source);
        }
    }

    /// <summary>
    /// Json操作类 外部只能用扩展来访问
    /// </summary>
    internal sealed class JsonOperation
    {
        private readonly JsonSerializerSettings _settings;

        public JsonOperation() : this(true) { }

        public JsonOperation(bool useCamelCasePropertyNames)
        {
            _settings = new JsonSerializerSettings
            {
                Converters = new JsonConverter[]
                    {
                        //new IsoDateTimeConverter {DateTimeFormat = "yyyy-MM-dd HH:mm:ss"}
                        new JavaScriptDateTimeConverter()
                    },
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,/*忽略循环引用*/
                Formatting = Formatting.Indented,/*缩进*/
                NullValueHandling = NullValueHandling.Ignore,/*忽略null值*/
                ContractResolver = !useCamelCasePropertyNames ? new DefaultContractResolver()
                                        : new CamelCasePropertyNamesContractResolver()/*骆驼写法*/
            };
        }

        /// <summary>
        /// 序列化object为Json字符
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Serialize(object data)
        {
            if (data == null) return null;

            var writer = new StringWriter();
            JsonSerializer serializer = JsonSerializer.Create(_settings);
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))
            {
                jsonWriter.Formatting = Formatting.Indented;//缩进
                serializer.Serialize(jsonWriter, data);
            }

            return writer.ToString();
        }
    }
}