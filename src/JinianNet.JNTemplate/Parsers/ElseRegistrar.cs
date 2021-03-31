﻿/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the MIT license. See licence.txt file in the project root for full license information.
 ********************************************************************************/
using JinianNet.JNTemplate.CodeCompilation;
using JinianNet.JNTemplate.Nodes;
using System.Reflection;
using System;

namespace JinianNet.JNTemplate.Parsers
{
    /// <summary>
    /// The <see cref="ElseTag"/> registrar
    /// </summary>
    public class ElseRegistrar : TagRegistrar<ElseTag>, IRegistrar
    {
        /// <inheritdoc />
        public override Func<TemplateParser, TokenCollection, ITag> BuildParseMethod()
        {
            return (parser, tc) =>
            {
                if (tc != null
                    && parser != null
                    && tc.Count == 1
                    && Utility.IsEqual(tc.First.Text, Field.KEY_ELSE))
                {
                    return new ElseTag();
                }

                return null;
            };
        }

        /// <inheritdoc />
        public override Func<ITag, CompileContext, MethodInfo> BuildCompileMethod()
        {
            return (tag, c) =>
            {
                return c.IfCompile((ElseTag)tag);
            };
        }
        /// <inheritdoc />
        public override Func<ITag, CompileContext,Type> BuildGuessMethod()
        {
            return (tag, c) =>
            {
                return c.GuessIfType((ElseTag)tag);
            };
        }
    }
}