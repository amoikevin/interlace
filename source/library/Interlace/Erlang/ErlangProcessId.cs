#region Using Directives and Copyright Notice

// Copyright (c) 2007-2010, Computer Consultancy Pty Ltd
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the Computer Consultancy Pty Ltd nor the
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
using System.Text;

#endregion

namespace Interlace.Erlang
{
    public class ErlangProcessId 
    {
        readonly Atom _node;
        readonly uint _id;
        readonly byte _creation;
        readonly uint _serial;

        public ErlangProcessId(Atom node, uint id, uint serial, byte creation)
        {
            _node = node;
            _id = id;
            _serial = serial;
            _creation = creation;
        }

        public Atom Node
        { 	 
            get { return _node; }
        }

        public uint Id
        { 	 
            get { return _id; }
        }

        public byte Creation
        { 	 
            get { return _creation; }
        }

        public uint Serial
        {
            get { return _serial; }
        }

        public override bool Equals(object obj)
        {
            ErlangProcessId rhs = obj as ErlangProcessId;

            if (rhs == null) return false;

            return 
                _node == rhs._node &
                _id == rhs._id &
                _creation == rhs._creation &
                _serial == rhs._serial;
        }

        public override int GetHashCode()
        {
            return
                _node.GetHashCode() ^
                _id.GetHashCode() ^
                _creation.GetHashCode() ^
                _serial.GetHashCode();
        }
    }
}
