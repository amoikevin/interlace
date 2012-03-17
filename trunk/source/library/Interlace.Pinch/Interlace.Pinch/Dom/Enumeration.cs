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

using Interlace.Collections;
using Interlace.Pinch.Analysis;

#endregion

namespace Interlace.Pinch.Dom
{
    public class Enumeration : Declaration
    {
        TrackedBindingList<EnumerationMember> _members;
        List<EnumerationMember> _codingOrderMembers;

        public Enumeration()
        {
            _members = new TrackedBindingList<EnumerationMember>();
            _members.Added += new EventHandler<TrackedBindingListEventArgs<EnumerationMember>>(_members_Added);
            _members.Removed += new EventHandler<TrackedBindingListEventArgs<EnumerationMember>>(_members_Removed);
        }

        void _members_Added(object sender, TrackedBindingListEventArgs<EnumerationMember> e)
        {
            e.Item.Parent = this;
        }

        void _members_Removed(object sender, TrackedBindingListEventArgs<EnumerationMember> e)
        {
            e.Item.Parent = null;
        }

        public IList<EnumerationMember> Members
        {
            get { return _members; }
        }

        public override IEnumerable<DeclarationMember> MemberBases
        {
            get 
            {
                foreach (EnumerationMember member in _members)
                {
                    yield return member;
                }
            }
        }

        public override void SortAndNumberVersionables()
        {
            VersionableUtilities.NumberVersionables(_members);
        }

        public override string KindTag 
        {
            get { return "enumeration"; } 
        }

        public IList<EnumerationMember> CodingOrderMembers
        {
            get
            {
                if (_codingOrderMembers == null)
                {
                    List<EnumerationMember> members = new List<EnumerationMember>(_members);
                    members.Sort(delegate(EnumerationMember lhs, EnumerationMember rhs)
                    {
                        return lhs.Number.CompareTo(rhs.Number);
                    });

                    _codingOrderMembers = members;
                }

                return _codingOrderMembers;
            }
        }
    }
}
