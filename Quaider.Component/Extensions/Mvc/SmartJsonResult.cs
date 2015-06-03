using System;
using System.Web;
using System.Web.Mvc;

namespace Quaider.Component.Extensions.Mvc
{
    public class SmartJsonResult : JsonResult
    {
        public SmartJsonResult() : this(true) { }

        public SmartJsonResult(bool useCamelCasePropertyNames)
        {
            CamelCasePropertyNames = useCamelCasePropertyNames;
        }

        /// <summary>
        /// 序列化反序列化时是否启用骆驼写法
        /// </summary>
        protected bool CamelCasePropertyNames { get; set; }

        /// <summary>
        /// 重写JsonResult实现，用Json.net替换其内部实现
        /// </summary>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            ExecuteResultWithJsonNet(context);
        }

        /// <summary>
        /// 自定义序列化Json请实现此方法
        /// </summary>
        /// <param name="context"></param>
        protected virtual void ExecuteResultWithJsonNet(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                response.Write(Data.ToJson(CamelCasePropertyNames));
            }
        }
    }
}