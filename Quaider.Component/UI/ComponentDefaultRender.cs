using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Quaider.Component.UI
{
    internal class ComponentDefaultRender<T> : IComponentRender<T>
    {

        public ComponentDefaultRender()
        {
            
        }

        protected IComponentModel<T> ComponentModel { get; set; }

        public virtual  void Render(IComponentModel<T> componentModel, TextWriter output, ViewContext viewContext)
        {

        }
    }
}