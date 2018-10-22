/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the MIT license. See licence.txt file in the project root for full license information.
 ********************************************************************************/
using System;

namespace JinianNet.JNTemplate
{
    /// <summary>
    /// 动态对象执行类
    /// </summary>
    public interface ICallProxy
    {
        /// <summary>
        /// 动态执行方法
        /// </summary>
        /// <param name="container">对象</param>
        /// <param name="methodName">方法名</param>
        /// <param name="args">实参</param>
        /// <returns>执行结果（Void返回NULL）</returns>
        object CallMethod(object container, string methodName, object[] args);
        /// <summary>
        /// 动态获取属性或字段
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="propertyName">属性或字段名</param>
        /// <returns>返回结果</returns>
        object CallPropertyOrField(object value, string propertyName);

        /// <summary>
        /// 动态获取索引值
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="index">索引</param>
        /// <returns>返回结果</returns>
        object CallIndexValue(object value, object index);
    }
}