#region Using Directives and Copyright Notice

// Copyright (c) 2010, Bit Plantation
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the Bit Plantation nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL COMPUTER CONSULTANCY PTY LTD BE LIABLE 
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER 
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT 
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY 
// OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH
// DAMAGE.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

#endregion

namespace Interlace.Sharpcap
{
    public static class ByteOrder
    {
        public static uint NetworkToHost(uint value)
        {
            return (uint)IPAddress.NetworkToHostOrder((int)value);
        }

        public static int NetworkToHost(int value)
        {
            return IPAddress.NetworkToHostOrder(value);
        }

        public static ushort NetworkToHost(ushort value)
        {
            return (ushort)IPAddress.NetworkToHostOrder((short)value);
        }

        public static short NetworkToHost(short value)
        {
            return IPAddress.NetworkToHostOrder(value);
        }

        public static uint HostToNetwork(uint value)
        {
            return (uint)IPAddress.HostToNetworkOrder((int)value);
        }

        public static int HostToNetwork(int value)
        {
            return IPAddress.HostToNetworkOrder(value);
        }

        public static ushort HostToNetwork(ushort value)
        {
            return (ushort)IPAddress.HostToNetworkOrder((short)value);
        }

        public static short HostToNetwork(short value)
        {
            return IPAddress.HostToNetworkOrder(value);
        }
    }
}
