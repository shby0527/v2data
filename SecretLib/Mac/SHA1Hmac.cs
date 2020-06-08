using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretLib.Mac
{
    public class SHA1Hmac : IMac
    {
        public string Name => "HMAC-SHA1";

        public byte[] MessageCode(byte[] message, KeyParameter key)
        {
            HMac mac = new HMac(new MD5Digest());
            mac.Init(key);
            mac.BlockUpdate(message, 0, message.Length);
            byte[] output = new byte[mac.GetMacSize()];
            mac.DoFinal(output, 0);
            return output;
        }
    }
}
