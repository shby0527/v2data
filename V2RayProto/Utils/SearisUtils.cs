using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;
using V2Ray.Core.Common.Serial;

namespace V2RayProto.Utils
{
    /// <summary>
    /// 装换
    /// </summary>
    public static class SearisUtils
    {
        /// <summary>
        ///  装换对象到TypedMessage
        /// </summary>
        /// <param name="message">对象</param>
        /// <returns></returns>
        public static TypedMessage ToTypedMessage(IMessage message)
        {
            TypedMessage typedMessage = new TypedMessage
            {
                Type = message.Descriptor.FullName,
                Value = message.ToByteString()
            };
            return typedMessage;
        }
    }
}
