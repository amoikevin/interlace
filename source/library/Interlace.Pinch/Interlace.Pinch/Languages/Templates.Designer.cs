﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Interlace.Pinch.Languages {
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
    internal class Templates {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Templates() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Interlace.Pinch.Languages.Templates", typeof(Templates).Assembly);
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
        ///   Looks up a localized string similar to group CppTemplate;
        ///
        ///h(Document) ::= &lt;&lt;
        ///#pragma once
        ///
        ///&lt;Document.Protocols:protocol_h()&gt;
        ///&gt;&gt;
        ///
        ///protocol_h(Protocol) ::= &lt;&lt;
        ///&lt;if(Protocol.Implementation.UsesNamespace)&gt;
        ///namespace &lt;Protocol.Implementation.Namespace&gt;
        ///{
        ///&lt;endif&gt;
        ///
        ///&lt;Protocol.Declarations:{ d | &lt;d:(d.KindTag + &quot;_forward_h&quot;)()&gt; }; separator=&quot;\r\n&quot;&gt;
        ///
        ///&lt;Protocol.Declarations:{ d | &lt;d:(d.KindTag + &quot;_h&quot;)()&gt; }; separator=&quot;\r\n&quot;&gt;
        ///
        ///&lt;if(Protocol.Implementation.UsesNamespace)&gt;
        ///}
        ///&lt;endif&gt;
        ///
        ///&gt;&gt;
        ///
        ///structure_forward_h(Structure) ::= &lt;&lt;
        ///class &lt;Str [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CppTemplate {
            get {
                return ResourceManager.GetString("CppTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to group CsTemplate;
        ///
        ///file(Document) ::= &lt;&lt;
        ///using System.Collections.Generic;
        ///using System.ComponentModel;
        ///
        ///using Interlace.Pinch.Implementation;
        ///
        ///&lt;Document.Protocols:protocol()&gt;
        ///&gt;&gt;
        ///
        ///protocol(Protocol) ::= &lt;&lt;
        ///namespace &lt;Protocol.Name&gt;
        ///{
        ///&lt;Protocol.Declarations:declaration()&gt;
        ///}
        ///
        ///&gt;&gt;
        ///
        ///declaration(Declaration) ::= &lt;&lt;
        ///&lt;Declaration:(Declaration.KindTag)()&gt;
        ///
        ///&gt;&gt;
        ///
        ///structure(Structure) ::= &lt;&lt;
        ///    public class &lt;Structure.Implementation.Identifier&gt;Factory : IPinchableFactory
        ///    {
        ///        static  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CsTemplate {
            get {
                return ResourceManager.GetString("CsTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to group JavaTemplate;
        ///
        ///file(Declaration) ::= &lt;&lt;
        ///package &lt;Declaration.Parent.Implementation.PackageName&gt;;
        ///
        ///import com.interlacelibrary.pinch.*;
        ///
        ///&lt;Declaration:(Declaration.KindTag)()&gt;
        ///
        ///&gt;&gt;
        ///
        ///structure(Structure) ::= &lt;&lt;
        ///public class &lt;Structure.Implementation.Identifier&gt; implements IPinchable
        ///{
        ///    public static class Factory implements IPinchableFactory
        ///    {
        ///        public Object create(IPinchDecodingContext context)
        ///        {
        ///            return new &lt;Structure.Implementation.Identifier&gt;(context) [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string JavaTemplate {
            get {
                return ResourceManager.GetString("JavaTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to group CsTemplate;
        ///
        ///file(Document) ::= &lt;&lt;
        ///using System.Collections.Generic;
        ///using System.ComponentModel;
        ///
        ///using Interlace.Pinch.Implementation;
        ///
        ///&lt;Document.Protocols:protocol()&gt;
        ///&gt;&gt;
        ///
        ///protocol(Protocol) ::= &lt;&lt;
        ///namespace &lt;Protocol.Name&gt;
        ///{
        ///&lt;Protocol.Declarations:declaration()&gt;
        ///}
        ///
        ///&gt;&gt;
        ///
        ///declaration(Declaration) ::= &lt;&lt;
        ///&lt;Declaration:(Declaration.KindTag)()&gt;
        ///
        ///&gt;&gt;
        ///
        ///structure(Structure) ::= &lt;&lt;
        ///    public class &lt;Structure.Implementation.Identifier&gt;Factory : IPinchableFactory
        ///    {
        ///        static  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PythonTemplate {
            get {
                return ResourceManager.GetString("PythonTemplate", resourceCulture);
            }
        }
    }
}
