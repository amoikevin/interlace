﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute("schema", Namespace="", IsNullable=false)]
public partial class DatabaseSchema {
    
    private DatabaseSchemaUpgrade[] upgradeField;
    
    private string productField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("upgrade", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public DatabaseSchemaUpgrade[] upgrade {
        get {
            return this.upgradeField;
        }
        set {
            this.upgradeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string product {
        get {
            return this.productField;
        }
        set {
            this.productField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DatabaseSchemaUpgrade {
    
    private string[] commandField;
    
    private string fromversionField;
    
    private string toversionField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("command", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string[] command {
        get {
            return this.commandField;
        }
        set {
            this.commandField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fromversion {
        get {
            return this.fromversionField;
        }
        set {
            this.fromversionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string toversion {
        get {
            return this.toversionField;
        }
        set {
            this.toversionField = value;
        }
    }
}
