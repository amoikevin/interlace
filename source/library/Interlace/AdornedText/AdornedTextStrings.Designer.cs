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

#endregion

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Interlace.AdornedText {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AdornedTextStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AdornedTextStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Interlace.AdornedText.AdornedTextStrings", typeof(AdornedTextStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected internal error has occurred. A sequence of lines that should not have been passed by the classifier has been found by a later parsing stage..
        /// </summary>
        internal static string AdornedInternalUnexpected {
            get {
                return ResourceManager.GetString("AdornedInternalUnexpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A document has already been parsed by the AdornedProcessor instance. To parse or process another document, create a new instance rather than reusing instances..
        /// </summary>
        internal static string AdornedProcessorAlreadyParsed {
            get {
                return ResourceManager.GetString("AdornedProcessorAlreadyParsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An operation failed on the AdornedProcessor because the document to be processed has not yet been parsed..
        /// </summary>
        internal static string AdornedProcessorNotParsed {
            get {
                return ResourceManager.GetString("AdornedProcessorNotParsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A definition list can not be used within a list. A list earlier in the document may not have been completed with two empty lines..
        /// </summary>
        internal static string DefinitionListInListIsInvalid {
            get {
                return ResourceManager.GetString("DefinitionListInListIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The end of the document was reached inside a table. One of the tables in the document may not have been finished..
        /// </summary>
        internal static string EndOfStreamInTable {
            get {
                return ResourceManager.GetString("EndOfStreamInTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error was found in a link or image reference. A reference should be either &quot;link&quot; or &quot;image&quot; followed by the reference. For example, &quot;[link http://www.google.com/ Click Here For Google!]&quot;..
        /// </summary>
        internal static string InvalidReferenceContents {
            get {
                return ResourceManager.GetString("InvalidReferenceContents", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A list can not be used within a definition list. A list earlier in the document may not have been completed with two empty lines..
        /// </summary>
        internal static string ListInDefinitionListIsInvalid {
            get {
                return ResourceManager.GetString("ListInDefinitionListIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A title can not be used within a list. A list earlier in the document may not have been completed with two empty lines..
        /// </summary>
        internal static string TitleInListIsInvalid {
            get {
                return ResourceManager.GetString("TitleInListIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Section titles and tables are not permitted inside table cells. A table may not have been closed..
        /// </summary>
        internal static string TitlesAndTablesInTableAreInvalid {
            get {
                return ResourceManager.GetString("TitlesAndTablesInTableAreInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unexpected internal error has occurred. An invalid line classification was  found after a listing item..
        /// </summary>
        internal static string UnexpectedLineClassificationInList {
            get {
                return ResourceManager.GetString("UnexpectedLineClassificationInList", resourceCulture);
            }
        }
    }
}
