﻿/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the MIT license. See licence.txt file in the project root for full license information.
 ********************************************************************************/
#if !NET20
using System.Threading.Tasks;
#endif


namespace JinianNet.JNTemplate
{
    /// <summary>
    /// Represents an executor.
    /// </summary>
    /// <typeparam name="T">The type of return object.</typeparam>
    public interface IExecutor<T>
    {
        /// <summary>
        /// Execute the object.
        /// </summary>
        /// <returns></returns>
        T Execute();
#if NETCOREAPP || NETSTANDARD
        /// <summary>
        /// Asynchronously execute the object.
        /// </summary>
        Task<T> ExecuteAsync();
#endif
    }
}
