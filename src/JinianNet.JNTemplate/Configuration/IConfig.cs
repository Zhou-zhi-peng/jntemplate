﻿/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the MIT license. See licence.txt file in the project root for full license information.
 ********************************************************************************/

using JinianNet.JNTemplate.Dynamic;
using JinianNet.JNTemplate.Resources;
using System;
using System.Collections.Generic;

namespace JinianNet.JNTemplate.Configuration
{
    /// <summary>
    /// The config of the engine.
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Gets or sets the global resource directories of the engine.
        /// </summary>
        List<string> ResourceDirectories { get; set; }
        /// <summary>
        /// Gets or sets the charset of the engine.
        /// </summary>
        string Charset { get; set; }
        /// <summary>
        /// Gets or sets the tag prefix .
        /// </summary>
        string TagPrefix { get; set; }
        /// <summary>
        /// Gets or sets the tag suffix.
        /// </summary>
        string TagSuffix { get; set; }

        /// <summary>
        /// Gets or sets the tag flag.
        /// </summary>
        char TagFlag { get; set; }

        /// <summary>
        /// Gets or sets whether throw exceptions.
        /// </summary>
        bool ThrowExceptions { get; set; }

        /// <summary>
        /// Gets or sets whether strip white-space.
        /// </summary>
        bool StripWhiteSpace { get; set; }

        /// <summary>
        /// IgnoreCase
        /// </summary>
        [Obsolete]
        bool IgnoreCase { get; set; }

        /// <summary>
        /// Enable or disenable the cache.
        /// </summary> 
        bool EnableTemplateCache { get; set; }

        /// <summary>
        /// Gets or sets whether disablee logogram .
        /// </summary>
        bool DisableeLogogram { get; set; } 
    }
}
