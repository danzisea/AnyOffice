using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Quaider.Component.Extensions;

namespace Quaider.Component.UI
{
    /// <summary>
    /// 组件基础接口
    /// </summary>
    public abstract class ComponentBase<T> : IHtmlString
    {
        protected ComponentBase(IComponentModel<T> componentModel)
        {
            ComponentModel = componentModel;
        }

        protected IComponentModel<T> ComponentModel { get; set; }

        public override string ToString()
        {
            return ToHtmlString();
        }

        public abstract string ToHtmlString();

        protected void AddClass(params string[] classes)
        {
            var clsStr = string.Join(" ", classes);
            AddClass(clsStr);
        }

        protected void AddClass(string classes)
        {
            var cls = !ComponentModel.Attributes.Keys.Contains("class") || ComponentModel.Attributes["class"] == null
                ? ""
                : ComponentModel.Attributes["class"].ToString();

            if (!string.IsNullOrWhiteSpace(classes))
                cls += string.Format(" {0}", string.Join(" ", classes));

            ComponentModel.Attributes.SetKeyValue("class", cls.Trim());
        }
    }
}