// Copyright (c) 2008-2021, Hazelcast, Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// <auto-generated>
//   This code was generated by a tool.
//     Hazelcast Client Protocol Code Generator
//     https://github.com/hazelcast/hazelcast-client-protocol
//   Change to this file will be lost if the code is regenerated.
// </auto-generated>

#pragma warning disable IDE0051 // Remove unused private members
// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Hazelcast.Protocol.BuiltInCodecs;
using Hazelcast.Protocol.CustomCodecs;
using Hazelcast.Core;
using Hazelcast.Messaging;
using Hazelcast.Clustering;
using Hazelcast.Serialization;
using Microsoft.Extensions.Logging;

namespace Hazelcast.Protocol.Codecs
{
    /// <summary>
    /// Retrieves and removes the head of this queue, waiting up to the specified wait time if necessary for an element
    /// to become available.
    ///</summary>
#if SERVER_CODEC
    internal static class QueuePollServerCodec
#else
    internal static class QueuePollCodec
#endif
    {
        public const int RequestMessageType = 197888; // 0x030500
        public const int ResponseMessageType = 197889; // 0x030501
        private const int RequestTimeoutMillisFieldOffset = Messaging.FrameFields.Offset.PartitionId + BytesExtensions.SizeOfInt;
        private const int RequestInitialFrameSize = RequestTimeoutMillisFieldOffset + BytesExtensions.SizeOfLong;
        private const int ResponseInitialFrameSize = Messaging.FrameFields.Offset.ResponseBackupAcks + BytesExtensions.SizeOfByte;

#if SERVER_CODEC
        public sealed class RequestParameters
        {

            /// <summary>
            /// Name of the Queue
            ///</summary>
            public string Name { get; set; }

            /// <summary>
            /// Maximum time in milliseconds to wait for acquiring the lock for the key.
            ///</summary>
            public long TimeoutMillis { get; set; }
        }
#endif

        public static ClientMessage EncodeRequest(string name, long timeoutMillis)
        {
            var clientMessage = new ClientMessage
            {
                IsRetryable = false,
                OperationName = "Queue.Poll"
            };
            var initialFrame = new Frame(new byte[RequestInitialFrameSize], (FrameFlags) ClientMessageFlags.Unfragmented);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.MessageType, RequestMessageType);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.PartitionId, -1);
            initialFrame.Bytes.WriteLongL(RequestTimeoutMillisFieldOffset, timeoutMillis);
            clientMessage.Append(initialFrame);
            StringCodec.Encode(clientMessage, name);
            return clientMessage;
        }

#if SERVER_CODEC
        public static RequestParameters DecodeRequest(ClientMessage clientMessage)
        {
            using var iterator = clientMessage.GetEnumerator();
            var request = new RequestParameters();
            var initialFrame = iterator.Take();
            request.TimeoutMillis = initialFrame.Bytes.ReadLongL(RequestTimeoutMillisFieldOffset);
            request.Name = StringCodec.Decode(iterator);
            return request;
        }
#endif

        public sealed class ResponseParameters
        {

            /// <summary>
            /// The head of this queue, or <tt>null</tt> if this queue is empty
            ///</summary>
            public IData Response { get; set; }
        }

#if SERVER_CODEC
        public static ClientMessage EncodeResponse(IData response)
        {
            var clientMessage = new ClientMessage();
            var initialFrame = new Frame(new byte[ResponseInitialFrameSize], (FrameFlags) ClientMessageFlags.Unfragmented);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.MessageType, ResponseMessageType);
            clientMessage.Append(initialFrame);
            CodecUtil.EncodeNullable(clientMessage, response, DataCodec.Encode);
            return clientMessage;
        }
#endif

        public static ResponseParameters DecodeResponse(ClientMessage clientMessage)
        {
            using var iterator = clientMessage.GetEnumerator();
            var response = new ResponseParameters();
            iterator.Take(); // empty initial frame
            response.Response = CodecUtil.DecodeNullable(iterator, DataCodec.Decode);
            return response;
        }

    }
}
