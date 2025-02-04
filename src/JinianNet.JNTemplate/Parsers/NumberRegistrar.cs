/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the MIT license. See licence.txt file in the project root for full license information.
 ********************************************************************************/
using System;
using System.Reflection;
using System.Reflection.Emit;
using JinianNet.JNTemplate.CodeCompilation;
using JinianNet.JNTemplate.Nodes;

namespace JinianNet.JNTemplate.Parsers
{
    /// <summary>
    /// The <see cref="NumberTag"/> registrar
    /// </summary>
    public class NumberRegistrar : TagRegistrar<NumberTag>, IRegistrar
    {
        /// <inheritdoc />
        public override Func<TemplateParser, TokenCollection, ITag> BuildParseMethod()
        {
            return (parser, tc) =>
            {
                if (tc != null
                    && tc.Count == 1
                    && tc.First.TokenKind == TokenKind.Number)
                {
                    var tag = new NumberTag();
                    if (tc.First.Text.IndexOf('.') == -1)
                    {
                        if (tc.First.Text.Length < 9)
                        {
                            tag.Value = int.Parse(tc.First.Text);
                        }
                        else if (tc.First.Text.Length == 9)
                        {
                            var value = long.Parse(tc.First.Text);
                            if (value <= int.MaxValue)
                            {
                                tag.Value = int.Parse(tc.First.Text);
                            }
                            else
                            {
                                tag.Value = value;
                            }
                        }
                        else
                        {
                            tag.Value = long.Parse(tc.First.Text);
                        }
                    }
                    else
                    {
                        tag.Value = Double.Parse(tc.First.Text);
                    }

                    return tag;
                }

                return null;
            };
        }
        /// <inheritdoc />
        public override Func<ITag, CompileContext, MethodInfo> BuildCompileMethod()
        {
            return (tag, c) =>
            {
                var t = tag as NumberTag;
                var type = t.Value.GetType();
                var mb = c.CreateReutrnMethod<NumberTag>(type);
                var il = mb.GetILGenerator();
                il.DeclareLocal(type);
                il.CallTypeTag(t);
                il.Emit(OpCodes.Stloc_0);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ret);
                return mb.GetBaseDefinition();
            };
        }
        /// <inheritdoc />
        public override Func<ITag, CompileContext, Type> BuildGuessMethod()
        {
            return (tag, c) =>
            {
                return ((NumberTag)tag).Value.GetType();
            };
        }
        /// <inheritdoc />
        public override Func<ITag, TemplateContext, object> BuildExcuteMethod()
        {
            return (tag, context) =>
            {
                var t = tag as NumberTag;
                return t.Value;
            };
        }
    }
}