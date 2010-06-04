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
using System.IO;
using System.Text;

using Interlace.Pinch.Dom;
using Interlace.Pinch.Generation;
using Interlace.Utilities;

#endregion

namespace Interlace.Pinch.Languages
{
    public class CppLanguage : Language
    {
        static Dictionary<Pair<IntrinsicType, FieldModifier>, CppType> _intrinsics;

        static CppLanguage()
        {
            _intrinsics = new Dictionary<Pair<IntrinsicType, FieldModifier>, CppType>();

            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Float32, FieldModifier.Required), new CppType("float", "float"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Float64, FieldModifier.Required), new CppType("double", "double"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Int8, FieldModifier.Required), new CppType("unsigned char", "unsigned char"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Int16, FieldModifier.Required), new CppType("short", "short"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Int32, FieldModifier.Required), new CppType("int", "int"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Int64, FieldModifier.Required), new CppType("long long", "long long"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Bool, FieldModifier.Required), new CppType("bool", "bool"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.String, FieldModifier.Required), new CppType("CString", "const CString &"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Bytes, FieldModifier.Required), new CppType("CBlob", "const CBlob &"));

            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Float32, FieldModifier.Optional), new CppType("CNullable<float>", "CNullable<float>"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Float64, FieldModifier.Optional), new CppType("CNullable<double>", "CNullable<double>"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Int8, FieldModifier.Optional), new CppType("CNullable<unsigned char>", "CNullable<unsigned char>"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Int16, FieldModifier.Optional), new CppType("CNullable<short>", "CNullable<short>"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Int32, FieldModifier.Optional), new CppType("CNullable<int>", "CNullable<int>"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Int64, FieldModifier.Optional), new CppType("CNullable<long long>", "CNullable<long long>"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Bool, FieldModifier.Optional), new CppType("CNullable<bool>", "CNullable<bool>"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.String, FieldModifier.Optional), new CppType("CNullable<CString>", "const CNullable<CString> &"));
            _intrinsics.Add(new Pair<IntrinsicType, FieldModifier>(IntrinsicType.Bytes, FieldModifier.Optional), new CppType("CNullable<CBlob>", "const CNullable<CBlob> &"));
        }

        public CppLanguage()
            : base("cpp", "C++")
        {
        }

        public static string IdentifierToClassName(string identifier)
        {
            return string.Format("C{0}", identifier);
        }

        public override object CreateStructureMemberImplementationHelper(StructureMember member)
        {
            if (member.FieldTypeReference is IntrinsicTypeReference)
            {
                IntrinsicTypeReference reference = member.FieldTypeReference as IntrinsicTypeReference;

                return new CppStructureMember(member, _intrinsics[new Pair<IntrinsicType, FieldModifier>(reference.Type, member.Modifier)]);
            }
            else
            {
                DeclarationTypeReference reference = member.FieldTypeReference as DeclarationTypeReference;

                bool isInProtocolNamespace = 
                    reference.Declaration.QualifiedName.ContainingName.Equals(member.Parent.Parent.Name);

                CppType type;

                string referenceClassName = IdentifierToClassName(reference.Declaration.Identifier);

                if (reference.Declaration is Enumeration)
                {
                    string typeName = string.Format("{0}::Enumeration", referenceClassName);

                    if (member.Modifier == FieldModifier.Optional) typeName = string.Format("CNullable<{0}>", typeName);

                    if (isInProtocolNamespace)
                    {
                        type = new CppType(typeName, typeName);
                    }
                    else
                    {
                        type = new CppType(typeName, typeName);
                    }
                }
                else
                {
                    string valueTypeName = string.Format("boost::shared_ptr<{0}>", referenceClassName);
                    string referenceTypeName = string.Format("const boost::shared_ptr<{0}> &", referenceClassName);

                    if (isInProtocolNamespace)
                    {
                        type = new CppType(valueTypeName, referenceTypeName, referenceClassName);
                    }
                    else
                    {
                        type = new CppType(valueTypeName, referenceTypeName, referenceClassName);
                    }
                }

                return new CppStructureMember(member, type);
            }
        }

        public override object CreateStructureImplementationHelper(Structure structure)
        {
            return new CppStructure(structure);
        }

        public override IEnumerable<LanguageOutput> GetLanguageOutputs(string baseName, string destinationPath)
        {
            string baseFileName = baseName.Replace(".", "");

            yield return new LanguageOutput(Path.Combine(destinationPath, baseName + ".h"), 
                LanguageOutputTemplateKind.StringTemplate, Templates.CppTemplate, "h");
            yield return new LanguageOutput(Path.Combine(destinationPath, baseName + ".cpp"), 
                LanguageOutputTemplateKind.StringTemplate, Templates.CppTemplate, "cpp");
        }
    }
}
