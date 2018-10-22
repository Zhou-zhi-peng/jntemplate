/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the MIT license. See licence.txt file in the project root for full license information.
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using JinianNet.JNTemplate.Parsers;

namespace JinianNet.JNTemplate
{
    /// <summary>
    /// Context
    /// </summary>
    public class TemplateContext
#if NET20 || NET40
        : ICloneable
#endif
    {
        private VariableScope _variableScope;
        private string _currentPath;
        private Encoding _charset;
        private bool _throwErrors;
        private bool _stripWhiteSpace;
        private List<System.Exception> _errors;

        /// <summary>
        /// 模板上下文
        /// </summary>
        public TemplateContext()
            : this(null)
        {

        }

        /// <summary>
        /// 模板上下文
        /// </summary>
        /// <param name="data">数据</param>
        public TemplateContext(VariableScope data)
        {
            string charset;
            this._variableScope = data ?? new VariableScope();
            this._errors = new List<System.Exception>();
            this._currentPath = null;
            this._throwErrors = Common.Utility.ToBoolean(Engine.GetEnvironmentVariable("ThrowExceptions"));
            this._stripWhiteSpace = Common.Utility.ToBoolean(Engine.GetEnvironmentVariable("StripWhiteSpace"));
            if (string.IsNullOrEmpty(charset = Engine.GetEnvironmentVariable("Charset")))
            {
                this._charset = Encoding.UTF8;
            }
            else
            {
                this._charset = Encoding.GetEncoding(charset);
            }

        }

        /// <summary>
        /// 处理标签前后空格
        /// </summary>
        public bool StripWhiteSpace
        {
            get { return _stripWhiteSpace; }
            set { this._stripWhiteSpace = value; }
        }


        /// <summary>
        /// 模板数据
        /// </summary>
        public VariableScope TempData
        {
            get { return this._variableScope; }
            set { this._variableScope = value; }
        }

        /// <summary>
        /// 当前资源路径
        /// </summary>
        public string CurrentPath
        {
            get { return this._currentPath; }
            set { this._currentPath = value; }
        }

        /// <summary>
        /// 当前资源编码
        /// </summary>
        public Encoding Charset
        {
            get { return this._charset; }
            set { this._charset = value; }
        }


        /// <summary>
        /// 是否抛出异常(默认为true)
        /// </summary>
        public bool ThrowExceptions
        {
            get { return this._throwErrors; }
            set { this._throwErrors = value; }
        }

        /// <summary>
        /// 当前异常集合（当ThrowExceptions为false时有效）
        /// </summary>
        public virtual System.Exception[] AllErrors
        {
            get { return this._errors.ToArray(); }
        }

        /// <summary>
        /// 获取当前第一个异常信息（当ThrowExceptions为false时有效）
        /// </summary>
        public virtual System.Exception Error
        {
            get
            {
                if (this.AllErrors.Length > 0)
                {
                    return this.AllErrors[0];
                }

                return null;
            }
        }

        /// <summary>
        /// 将异常添加到当前 异常集合中。
        /// </summary>
        /// <param name="e">异常</param>
        public void AddError(System.Exception e)
        {
            if (this.ThrowExceptions)
            {
                throw e;
            }
            this._errors.Add(e);
        }

        /// <summary>
        /// 清除所有异常
        /// </summary>
        public void ClearError()
        {
            this._errors.Clear();
        }

        /// <summary>
        /// 从指定TemplateContext创建一个类似的实例
        /// </summary>
        /// <param name="context"></param>
        /// <returns>TemplateContext</returns>
        public static TemplateContext CreateContext(TemplateContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("\"context\" cannot be null.");
            }
            TemplateContext ctx = new TemplateContext();
            ctx.TempData = new VariableScope(context.TempData);
            ctx.Charset = context.Charset;
            ctx.CurrentPath = context.CurrentPath;
            ctx.ThrowExceptions = context.ThrowExceptions;
            ctx.StripWhiteSpace = context.StripWhiteSpace;
            return ctx;
        }

#region ICloneable 成员
        /// <summary>
        /// 浅克隆当前实例
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

#endregion
    }
}