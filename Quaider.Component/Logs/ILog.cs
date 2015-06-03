﻿using System;
using System.Text;

namespace Quaider.Component.Logs
{
    /// <summary>
    /// 日志操作
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        string TraceId { get; set; }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        string Application { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        string Class { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        string Method { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        StringBuilder Caption { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        StringBuilder Content { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        StringBuilder Params { get; set; }

        /// <summary>
        /// Sql语句
        /// </summary>
        StringBuilder Sql { get; set; }

        /// <summary>
        /// Sql参数
        /// </summary>
        StringBuilder SqlParams { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        string ErrorCode { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        Exception Exception { get; set; }

        /// <summary>
        /// 调试
        /// </summary>
        void Debug();

        /// <summary>
        /// 信息
        /// </summary>
        void Info();

        /// <summary>
        /// 警告
        /// </summary>
        void Warn();

        /// <summary>
        /// 错误
        /// </summary>
        void Error();

        /// <summary>
        /// 致命错误
        /// </summary>
        void Fatal();
    }
}