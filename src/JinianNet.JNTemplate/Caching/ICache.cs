/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the MIT license. See licence.txt file in the project root for full license information.
 ********************************************************************************/
using System;
using System.Collections;

namespace JinianNet.JNTemplate.Caching
{
    /// <summary>
    /// 缓存
    /// </summary>
    public interface ICache : IEnumerable, IDisposable
    {
        /// <summary>
        /// 当前缓存数量
        /// </summary>
        int Count { get; }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set(string key, object value);
        /// <summary>
        /// 获取键为key的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Get(string key);
        /// <summary>
        /// 移除键为key的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Remove(string key);
    }
}