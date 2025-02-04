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
    public interface IExecutor
    {
        /// <summary>
        /// Execute the object.
        /// </summary>
        /// <returns></returns>
        object Execute();
#if NETCOREAPP || NETSTANDARD
        /// <summary>
        /// Asynchronously execute the object.
        /// </summary>
        Task<object> ExecuteAsync();
#endif
    }
}
