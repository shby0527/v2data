// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: transport/internet/headers/wireguard/config.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace V2Ray.Core.Transport.Internet.Headers.Wireguard {

  /// <summary>Holder for reflection information generated from transport/internet/headers/wireguard/config.proto</summary>
  public static partial class ConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for transport/internet/headers/wireguard/config.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjF0cmFuc3BvcnQvaW50ZXJuZXQvaGVhZGVycy93aXJlZ3VhcmQvY29uZmln",
            "LnByb3RvEi92MnJheS5jb3JlLnRyYW5zcG9ydC5pbnRlcm5ldC5oZWFkZXJz",
            "LndpcmVndWFyZCIRCg9XaXJlZ3VhcmRDb25maWdCdAozY29tLnYycmF5LmNv",
            "cmUudHJhbnNwb3J0LmludGVybmV0LmhlYWRlcnMud2lyZWd1YXJkUAFaCXdp",
            "cmVndWFyZKoCL1YyUmF5LkNvcmUuVHJhbnNwb3J0LkludGVybmV0LkhlYWRl",
            "cnMuV2lyZWd1YXJkYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::V2Ray.Core.Transport.Internet.Headers.Wireguard.WireguardConfig), global::V2Ray.Core.Transport.Internet.Headers.Wireguard.WireguardConfig.Parser, null, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class WireguardConfig : pb::IMessage<WireguardConfig> {
    private static readonly pb::MessageParser<WireguardConfig> _parser = new pb::MessageParser<WireguardConfig>(() => new WireguardConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WireguardConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::V2Ray.Core.Transport.Internet.Headers.Wireguard.ConfigReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WireguardConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WireguardConfig(WireguardConfig other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WireguardConfig Clone() {
      return new WireguardConfig(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WireguardConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WireguardConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
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
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WireguardConfig other) {
      if (other == null) {
        return;
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
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code