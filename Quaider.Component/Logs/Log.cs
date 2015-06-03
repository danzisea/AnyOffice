using System;
using System.Text;
using System.Threading;
using System.Web;
using log4net;

namespace Quaider.Component.Logs
{
    /// <summary>
    /// 日志操作
    /// </summary>
    public class Log : ILog
    {
        private readonly log4net.ILog _log;
        /// <summary>
        /// 堆栈跟踪
        /// </summary>
        private string _stackTrace;
        /// <summary>
        /// 错误消息
        /// </summary>
        private string _errorMessage;

        public Log(log4net.ILog log)
        {
            _log = log;
            TraceId = Guid.NewGuid().ToString();
            Params = new StringBuilder();
            Caption = new StringBuilder();
            Content = new StringBuilder();
            Sql = new StringBuilder();
            SqlParams = new StringBuilder();
            Application = string.Empty;
            Class = string.Empty;
            Method = string.Empty;
            _errorMessage = string.Empty;
            _stackTrace = string.Empty;
        }

        #region 保护属性

        /// <summary>
        /// 日志级别
        /// </summary>
        protected LogLevel Level { get; set; }

        #endregion

        #region 公共属性

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public StringBuilder Caption { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public StringBuilder Content { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public StringBuilder Params { get; set; }
        /// <summary>
        /// Sql语句
        /// </summary>
        public StringBuilder Sql { get; set; }
        /// <summary>
        /// Sql参数
        /// </summary>
        public StringBuilder SqlParams { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 异常消息
        /// </summary>
        public Exception Exception { get; set; }

        #endregion

        #region 工厂方法

        /// <summary>
        /// 获取日志
        /// </summary>
        public static ILog GetLog()
        {
            return new Log(LogManager.GetLogger(string.Empty));
        }

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static ILog GetLog<T>()
        {
            return GetLog(typeof(T));
        }

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="className">类名</param>
        public static ILog GetLog(string className)
        {
            return new Log(LogManager.GetLogger(className))
            {
                Class = className
            };
        }

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="instance">实例</param>
        public static ILog GetLog(object instance)
        {
            if (instance == null)
                return GetLog();
            return GetLog(instance.GetType());
        }

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="type">类型</param>
        public static ILog GetLog(Type type)
        {
            return new Log(LogManager.GetLogger(type))
            {
                Class = type.ToString()
            };
        }

        /// <summary>
        /// 获取上下文日志
        /// </summary>
        public static ILog GetContextLog()
        {
            return GetContextLog(GetLog);
        }

        /// <summary>
        /// 获取上下文日志
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static ILog GetContextLog<T>()
        {
            return GetContextLog(typeof(T));
        }

        /// <summary>
        /// 获取上下文日志
        /// </summary>
        /// <param name="type">类型</param>
        public static ILog GetContextLog(Type type)
        {
            var log = GetContextLog(() => GetLog(type));
            log.Class = type.ToString();
            return log;
        }

        /// <summary>
        /// 获取上下文日志
        /// </summary>
        private static ILog GetContextLog(Func<ILog> handler)
        {
            string key = Config.GetLogContextKey();
            var log = Context.Context.Get<ILog>(key);
            if (log != null)
                return log;
            log = handler();
            Context.Context.Add(key, log);
            return log;
        }

        /// <summary>
        /// 获取上下文日志
        /// </summary>
        /// <param name="className">类名</param>
        public static ILog GetContextLog(string className)
        {
            var log = GetContextLog(() => GetLog(className));
            log.Class = className;
            return log;
        }

        /// <summary>
        /// 获取上下文日志
        /// </summary>
        /// <param name="instance">实例</param>
        public static ILog GetContextLog(object instance)
        {
            if (instance == null)
                return GetLog();
            return GetContextLog(instance.GetType());
        }

        #endregion

        #region 公共方法

        public void Debug()
        {
            Execute(() =>
            {
                Level = LogLevel.Debug;
                _log.Debug(GetMessage());
            });
        }

        public void Info()
        {
            Execute(() =>
            {
                Level = LogLevel.Info;
                _log.Info(GetMessage());
            });
        }

        /// <summary>
        /// 警告
        /// </summary>
        public void Warn()
        {
            Execute(() =>
            {
                Level = LogLevel.Warning;
                _log.Warn(GetMessage());
            });
        }

        /// <summary>
        /// 错误
        /// </summary>
        public void Error()
        {
            Execute(() =>
            {
                Level = LogLevel.Error;
                _log.Error(GetMessage());
            });
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        public void Fatal()
        {
            Execute(() =>
            {
                Level = LogLevel.Fatal;
                _log.Fatal(GetMessage());
            });
        }

        #endregion

        /// <summary>
        /// 获取Url
        /// </summary>
        private string GetUrl()
        {
            if (HttpContext.Current == null)
                return string.Empty;
            try
            {
                return HttpContext.Current.Request.Url.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取日志消息
        /// </summary>
        private LogMessage GetMessage()
        {
            InitException();
            return CreateMessage();
        }

        /// <summary>
        /// 创建消息
        /// </summary>
        private LogMessage CreateMessage()
        {
            //TODO:消息需要再次详细初始化
            return new LogMessage
            {
                Level = "",//Level.Description(),
                TraceId = TraceId,
                Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                //TotalSeconds = GetTotalSeconds(),
                Url = GetUrl(),
                Application = GetApplication(),
                Class = Class,
                Method = Method,
                Params = Params.ToString(),
                Ip = Net.Ip,
                Host = Net.Host,
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString(),
                UserId = "",
                Operator = "",
                Role = "",
                Caption = Caption.ToString(),
                Content = Content.ToString(),
                Sql = Sql.ToString(),
                SqlParams = SqlParams.ToString(),
                ErrorCode = ErrorCode,
                Error = _errorMessage,
                StackTrace = _stackTrace
            };
        }

        /// <summary>
        /// 初始化异常
        /// </summary>
        private void InitException()
        {
            if (Exception == null)
                return;
            var warning = new Warning(Exception);
            _errorMessage = warning.Message;
            _stackTrace = warning.StackTrace;
        }

        /// <summary>
        /// 执行
        /// </summary>
        private void Execute(Action action)
        {
            action();
            Clear();
        }

        /// <summary>
        /// 获取应用程序
        /// </summary>
        private string GetApplication()
        {
            //if (Application.IsEmpty())
            //    return GetIdentity().Application;
            //return Application;

            return "to be continued";
        }

        /// <summary>
        /// 清理
        /// </summary>
        private void Clear()
        {
            Method = string.Empty;
            Params.Clear();
            Caption.Clear();
            Content.Clear();
            Sql.Clear();
            SqlParams.Clear();
            Exception = null;
            _errorMessage = string.Empty;
            _stackTrace = string.Empty;
        }
    }
}