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

using Interlace.PropertyLists;
using Interlace.Pinch.Dom;

#endregion

namespace Interlace.Pinch.Languages.Cs
{
    public class CsStructure 
    {
        Structure _structure;
        PropertyDictionary _options;

        public CsStructure(Structure structure, PropertyDictionary options)
        {
            _structure = structure;
            _options = options;

            if (_options.HasStringFor("surrogate-for") && !_options.HasValueFor("surrogate-for-is-reference-type"))
            {
                throw new LanguageException("Any use of \"surrogate-for\" must be accompanied with \"surrogate-for-is-reference-type\".");
            }
        }

        public bool IsSurrogate
        {
            get { return _options.HasStringFor("surrogate-for"); }
        }

        public bool IsReferenceType
        {
            get 
            {
                if (IsSurrogate)
                {
                    return _options.BooleanFor("surrogate-for-is-reference-type").Value;
                }
                else
                {
                    return true;
                }
            }
        }

        public string ListTypeName
        {
            get
            {
                return _options.StringFor("list-type-name", "List");
            }
        }

        public string SetTypeName
        {
            get
            {
                return _options.StringFor("set-type-name", "Set");
            }
        }

        public NamespaceName QualifiedName
        {
            get
            {
                return new NamespaceName(_structure.QualifiedName.ContainingName, Identifier);
            }
        }

        public string Identifier
        {
            get 
            {
                if (!_options.HasStringFor("surrogate-for")) return _structure.Identifier;

                return string.Format("{0}Surrogate", _structure.Identifier);
            }
        }

        public NamespaceName ReferenceTypeName
        {
            get
            {
                if (IsSurrogate)
                {
                    return SurrogateFor;
                }
                else
                {
                    return QualifiedName;
                }
            }
        }

        public NamespaceName SurrogateFor
        {
            get
            {
                string identifier = _options.StringFor("surrogate-for", null);

                if (identifier == null) return null;

                return NamespaceName.Parse(identifier);
            }
        }

        public string OptionalSurrogateFor
        {
            get 
            {
                return SurrogateFor.ToString() + (IsReferenceType ? "" : "?");
            }
        }

        public bool GenerateOnMissingNewFields 
        {
            get { return _options.BooleanFor("generate-on-missing-new-fields", false); }
        }
    }
}
