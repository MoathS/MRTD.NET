﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.CommandAPDU;
using HelloWord.ISO7816.CommandAPDU.Body;

namespace HelloWord.SecureMessaging
{
    public class DO97 : IBinary
    {
        private readonly ICommandApdu _rawCommandApdu;
        private readonly IBinary _do97 = new BinaryHex("9701");

        public DO97(ICommandApdu rawCommandApdu)
        {
            rawCommandApdu = rawCommandApdu;
        }
        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                    _do97,
                    new Le(
                        new CommandApduBody(_rawCommandApdu)
                    )
                ).Bytes();
        }
    }
}
