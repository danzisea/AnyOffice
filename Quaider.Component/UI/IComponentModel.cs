using System.Collections.Generic;

namespace Quaider.Component.UI
{
    /// <summary>
    /// 组件渲染依赖模型接口
    /// </summary>
    public interface IComponentModel<T> : IOptions<T>
    {
        string Id { get; set; }

        IDictionary<string, object> Attributes { get; set; }

        IDictionary<string, object> DataOptions { get; }

        IComponentRender<T> Renderer { get; set; }
    }

    public class ComponentModel<T> : IComponentModel<T>
    {
        const string DataOptionsKey = "data-options";
        public ComponentModel()
        {
            Attributes = new Dictionary<string, object>();
        }

        public string Id
        {
            get { return Attributes["id"] == null ? null : Attributes["id"].ToString(); }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    Attributes.SetKeyValue("id", value.Trim());
            }
        }

        public IDictionary<string, object> Attributes { get; set; }

        public IDictionary<string, object> DataOptions
        {
            get
            {
                if (!Attributes.Keys.Contains(DataOptionsKey))
                    Attributes.SetKeyValue(DataOptionsKey, new Dictionary<string, object>());
                return Attributes[DataOptionsKey] as IDictionary<string, object>;
            }
        }

        public IComponentRender<T> Renderer { get; set; }

        public void AddAttribute(string name, string value)
        {
            Attributes.SetKeyValue(name, value);
        }

        public void AddDataOption(string name, object value)
        {
            DataOptions.SetKeyValue(name, value);
        }
    }
}