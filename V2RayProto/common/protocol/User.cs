// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: common/protocol/user.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace V2Ray.Core.Common.Protocol {

  /// <summary>Holder for reflection information generated from common/protocol/user.proto</summary>
  public static partial class UserReflection {

    #region Descriptor
    /// <summary>File descriptor for common/protocol/user.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UserReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Chpjb21tb24vcHJvdG9jb2wvdXNlci5wcm90bxIadjJyYXkuY29yZS5jb21t",
            "b24ucHJvdG9jb2waMHYycmF5LmNvbS9jb3JlL2NvbW1vbi9zZXJpYWwvdHlw",
            "ZWRfbWVzc2FnZS5wcm90byJdCgRVc2VyEg0KBWxldmVsGAEgASgNEg0KBWVt",
            "YWlsGAIgASgJEjcKB2FjY291bnQYAyABKAsyJi52MnJheS5jb3JlLmNvbW1v",
            "bi5zZXJpYWwuVHlwZWRNZXNzYWdlQkkKHmNvbS52MnJheS5jb3JlLmNvbW1v",
            "bi5wcm90b2NvbFABWghwcm90b2NvbKoCGlYyUmF5LkNvcmUuQ29tbW9uLlBy",
            "b3RvY29sYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::V2Ray.Core.Common.Serial.TypedMessageReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::V2Ray.Core.Common.Protocol.User), global::V2Ray.Core.Common.Protocol.User.Parser, new[]{ "Level", "Email", "Account" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// User is a generic user for all procotols.
  /// </summary>
  public sealed partial class User : pb::IMessage<User> {
    private static readonly pb::MessageParser<User> _parser = new pb::MessageParser<User>(() => new User());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<User> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::V2Ray.Core.Common.Protocol.UserReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public User() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public User(User other) : this() {
      level_ = other.level_;
      email_ = other.email_;
      account_ = other.account_ != null ? other.account_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public User Clone() {
      return new User(this);
    }

    /// <summary>Field number for the "level" field.</summary>
    public const int LevelFieldNumber = 1;
    private uint level_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Level {
      get { return level_; }
      set {
        level_ = value;
      }
    }

    /// <summary>Field number for the "email" field.</summary>
    public const int EmailFieldNumber = 2;
    private string email_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Email {
      get { return email_; }
      set {
        email_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "account" field.</summary>
    public const int AccountFieldNumber = 3;
    private global::V2Ray.Core.Common.Serial.TypedMessage account_;
    /// <summary>
    /// Protocol specific account information. Must be the account proto in one of the proxies.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::V2Ray.Core.Common.Serial.TypedMessage Account {
      get { return account_; }
      set {
        account_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as User);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(User other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Level != other.Level) return false;
      if (Email != other.Email) return false;
      if (!object.Equals(Account, other.Account)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Level != 0) hash ^= Level.GetHashCode();
      if (Email.Length != 0) hash ^= Email.GetHashCode();
      if (account_ != null) hash ^= Account.GetHashCode();
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
      if (Level != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(Level);
      }
      if (Email.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Email);
      }
      if (account_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Account);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Level != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Level);
      }
      if (Email.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Email);
      }
      if (account_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Account);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(User other) {
      if (other == null) {
        return;
      }
      if (other.Level != 0) {
        Level = other.Level;
      }
      if (other.Email.Length != 0) {
        Email = other.Email;
      }
      if (other.account_ != null) {
        if (account_ == null) {
          Account = new global::V2Ray.Core.Common.Serial.TypedMessage();
        }
        Account.MergeFrom(other.Account);
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
            Level = input.ReadUInt32();
            break;
          }
          case 18: {
            Email = input.ReadString();
            break;
          }
          case 26: {
            if (account_ == null) {
              Account = new global::V2Ray.Core.Common.Serial.TypedMessage();
            }
            input.ReadMessage(Account);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
