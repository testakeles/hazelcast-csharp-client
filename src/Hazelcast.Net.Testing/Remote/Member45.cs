﻿// Copyright (c) 2008-2020, Hazelcast, Inc. All Rights Reserved.
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

#if !NETSTANDARD
#pragma warning disable

//Autogenerated by Thrift Compiler (0.13.0)

using System;
using System.Text;
using Thrift.Protocol;

namespace Hazelcast.Testing.Remote
{

#if !SILVERLIGHT
  [Serializable]
#endif
  public partial class Member : TBase
  {
    private string _uuid;
    private string _host;
    private int _port;

    public string Uuid
    {
      get
      {
        return _uuid;
      }
      set
      {
        __isset.uuid = true;
        this._uuid = value;
      }
    }

    public string Host
    {
      get
      {
        return _host;
      }
      set
      {
        __isset.host = true;
        this._host = value;
      }
    }

    public int Port
    {
      get
      {
        return _port;
      }
      set
      {
        __isset.port = true;
        this._port = value;
      }
    }


    public Isset __isset;
#if !SILVERLIGHT
    [Serializable]
#endif
    public struct Isset {
      public bool uuid;
      public bool host;
      public bool port;
    }

    public Member() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) {
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Uuid = iprot.ReadString();
              } else {
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Host = iprot.ReadString();
              } else {
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I32) {
                Port = iprot.ReadI32();
              } else {
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default:
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("Member");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Uuid != null && __isset.uuid) {
          field.Name = "uuid";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Uuid);
          oprot.WriteFieldEnd();
        }
        if (Host != null && __isset.host) {
          field.Name = "host";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Host);
          oprot.WriteFieldEnd();
        }
        if (__isset.port) {
          field.Name = "port";
          field.Type = TType.I32;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Port);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Member(");
      bool __first = true;
      if (Uuid != null && __isset.uuid) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Uuid: ");
        __sb.Append(Uuid);
      }
      if (Host != null && __isset.host) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Host: ");
        __sb.Append(Host);
      }
      if (__isset.port) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Port: ");
        __sb.Append(Port);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}

#endif