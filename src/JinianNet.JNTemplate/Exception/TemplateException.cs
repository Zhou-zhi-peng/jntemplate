/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the MIT license. See licence.txt file in the project root for full license information.
 ********************************************************************************/
using System;

namespace JinianNet.JNTemplate.Exception
{
    /// <summary>
    /// 常规性错误
    /// </summary>
    public class TemplateException : System.Exception
    {
        private int _errorLine;
        private int _errorColumn;
        private string _errorCode;
        /// <summary>
        /// 所在行
        /// </summary>
        public int Line
        {
            get { return this._errorLine; }
            set { this._errorLine = value; }
        }
        /// <summary>
        /// 所在字符
        /// </summary>
        public int Column
        {
            get { return this._errorColumn; }
            set { this._errorColumn = value; }
        }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string Code
        {
            get { return this._errorCode; }
            set { this._errorCode = value; }
        }
        /// <summary>
        /// 模板错误
        /// </summary>
        public TemplateException()
            : base()
        {

        }

        /// <summary>
        /// 模板错误
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="line">行</param>
        /// <param name="column">字符</param>
        public TemplateException(string message, int line, int column)
            : base(string.Concat("Line:",
                line.ToString(),
                " Column:",
                column.ToString(),
                "\r\n",
                message))
        {
            this._errorColumn = column;
            this._errorLine = line;
        }

        /// <summary>
        /// 模板错误
        /// </summary>
        /// <param name="message">错误信息</param>
        public TemplateException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 模板错误
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="innerException">基础信息</param>
        public TemplateException(string message, System.Exception innerException)
            : base(message, innerException)
        {

        }
    }
}