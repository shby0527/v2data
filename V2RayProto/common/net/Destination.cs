// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: common/net/destination.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace V2Ray.Core.Common.Net {

  /// <summary>Holder for reflection information generated from common/net/destination.proto</summary>
  public static partial class DestinationReflection {

    #region Descriptor
    /// <summary>File descriptor for common/net/destination.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DestinationReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chxjb21tb24vbmV0L2Rlc3RpbmF0aW9uLnByb3RvEhV2MnJheS5jb3JlLmNv",
            "bW1vbi5uZXQaJ3YycmF5LmNvbS9jb3JlL2NvbW1vbi9uZXQvbmV0d29yay5w",
            "cm90bxondjJyYXkuY29tL2NvcmUvY29tbW9uL25ldC9hZGRyZXNzLnByb3Rv",
            "In0KCEVuZHBvaW50Ei8KB25ldHdvcmsYASABKA4yHi52MnJheS5jb3JlLmNv",
            "bW1vbi5uZXQuTmV0d29yaxIyCgdhZGRyZXNzGAIgASgLMiEudjJyYXkuY29y",
            "ZS5jb21tb24ubmV0LklQT3JEb21haW4SDAoEcG9ydBgDIAEoDUI6Chljb20u",
            "djJyYXkuY29yZS5jb21tb24ubmV0UAFaA25ldKoCFVYyUmF5LkNvcmUuQ29t",
            "bW9uLk5ldGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::V2Ray.Core.Common.Net.NetworkReflection.Descriptor, global::V2Ray.Core.Common.Net.AddressReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::V2Ray.Core.Common.Net.Endpoint), global::V2Ray.Core.Common.Net.Endpoint.Parser, new[]{ "Network", "Address", "Port" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Endpoint of a network connection.
  /// </summary>
  public sealed partial class Endpoint : pb::IMessage<Endpoint> {
    private static readonly pb::MessageParser<Endpoint> _parser = new pb::MessageParser<Endpoint>(() => new Endpoint());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Endpoint> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::V2Ray.Core.Common.Net.DestinationReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Endpoint() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Endpoint(Endpoint other) : this() {
      network_ = other.network_;
      address_ = other.address_ != null ? other.address_.Clone() : null;
      port_ = other.port_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Endpoint Clone() {
      return new Endpoint(this);
    }

    /// <summary>Field number for the "network" field.</summary>
    public const int NetworkFieldNumber = 1;
    private global::V2Ray.Core.Common.Net.Network network_ = global::V2Ray.Core.Common.Net.Network.Unknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::V2Ray.Core.Common.Net.Network Network {
      get { return network_; }
      set {
        network_ = value;
      }
    }

    /// <summary>Field number for the "address" field.</summary>
    public const int AddressFieldNumber = 2;
    private global::V2Ray.Core.Common.Net.IPOrDomain address_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::V2Ray.Core.Common.Net.IPOrDomain Address {
      get { return address_; }
      set {
        address_ = value;
      }
    }

    /// <summary>Field number for the "port" field.</summary>
    public const int PortFieldNumber = 3;
    private uint port_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Port {
      get { return port_; }
      set {
        port_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Endpoint);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Endpoint other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Network != other.Network) return false;
      if (!object.Equals(Address, other.Address)) return false;
      if (Port != other.Port) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Network != global::V2Ray.Core.Common.Net.Network.Unknown) hash ^= Network.GetHashCode();
      if (address_ != null) hash ^= Address.GetHashCode();
      if (Port != 0) hash ^= Port.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Network != global::V2Ray.Core.Common.Net.Network.Unknown) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Network);
      }
      if (address_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Address);
      }
      if (Port != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(Port);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Network != global::V2Ray.Core.Common.Net.Network.Unknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Network);
      }
      if (address_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Address);
      }
      if (Port != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Port);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Endpoint other) {
      if (other == null) {
        return;
      }
      if (other.Network != global::V2Ray.Core.Common.Net.Network.Unknown) {
        Network = other.Network;
      }
      if (other.address_ != null) {
        if (address_ == null) {
          Address = new global::V2Ray.Core.Common.Net.IPOrDomain();
        }
        Address.MergeFrom(other.Address);
      }
      if (other.Port != 0) {
        Port = other.Port;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Network = (global::V2Ray.Core.Common.Net.Network) input.ReadEnum();
            break;
          }
          case 18: {
            if (address_ == null) {
              Address = new global::V2Ray.Core.Common.Net.IPOrDomain();
            }
            input.ReadMessage(Address);
            break;
          }
          case 24: {
            Port = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code