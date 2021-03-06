// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2007
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.2.0.115 (2007-11-7)
// options: lines


using System;
using System.Collections.Generic;
using System.Text;
using gppg;
using Interlace.Pinch.Dom;

namespace Interlace.Pinch.Parsing
{
public enum Tokens {
    error=1,EOF=2,PROTOCOL=3,ENUMERATION=4,MESSAGE=5,STRUCTURE=6,CHOICE=7,REMOVED=8,
    IDENTIFIER=9,INTEGER=10,LBRACE=11,RBRACE=12,LBRACKET=13,RBRACKET=14,LPAREN=15,RPAREN=16,
    LPOINTY=17,RPOINTY=18,DOT=19,COMMA=20,SEMICOLON=21,REQUIRED=22,OPTIONAL=23};

public struct ValueType
#line 4 "PinchParser.y"
			{ 
    public string identifier; 
    public int integer; 
    public Document document;
    public NamespaceName namespaceName; 
    public Versioning versioning; 
    public Protocol protocol;
    public Declaration declaration;
    public ProtocolIdentifier protocolIdentifier;
    public Enumeration enumeration;
    public Structure structure;
    public EnumerationMember enumerationMember;
    public StructureMember structureMember;
    }
// Abstract base class for GPLEX scanners
public abstract class ScanBase : IScanner<ValueType,LexLocation> {
  private LexLocation __yylloc;
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
}

public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
#line 1 "PinchParser.y"

  protected override void Initialize()
  {
    this.errToken = (int)Tokens.error;
    this.eofToken = (int)Tokens.EOF;

    states=new State[83];
    AddState(0,new State(new int[]{3,6},new int[]{-1,1,-6,3,-11,82,-12,5}));
    AddState(1,new State(new int[]{2,2}));
    AddState(2,new State(-1));
    AddState(3,new State(new int[]{3,6,2,-2},new int[]{-11,4,-12,5}));
    AddState(4,new State(-3));
    AddState(5,new State(-5));
    AddState(6,new State(new int[]{9,32},new int[]{-7,7,-8,49,-2,52}));
    AddState(7,new State(new int[]{15,72,13,24},new int[]{-10,8}));
    AddState(8,new State(new int[]{11,9}));
    AddState(9,new State(new int[]{4,14,5,68,6,69,7,70},new int[]{-13,10,-14,71,-15,13,-16,34,-5,35}));
    AddState(10,new State(new int[]{12,11,4,14,5,68,6,69,7,70},new int[]{-14,12,-15,13,-16,34,-5,35}));
    AddState(11,new State(-6));
    AddState(12,new State(-15));
    AddState(13,new State(-17));
    AddState(14,new State(new int[]{9,32},new int[]{-2,15}));
    AddState(15,new State(new int[]{13,24},new int[]{-10,16}));
    AddState(16,new State(new int[]{11,17}));
    AddState(17,new State(new int[]{9,32},new int[]{-18,18,-19,33,-2,21}));
    AddState(18,new State(new int[]{12,19,9,32},new int[]{-19,20,-2,21}));
    AddState(19,new State(-19));
    AddState(20,new State(-20));
    AddState(21,new State(new int[]{13,24},new int[]{-10,22}));
    AddState(22,new State(new int[]{21,23}));
    AddState(23,new State(-22));
    AddState(24,new State(new int[]{10,31},new int[]{-3,25}));
    AddState(25,new State(new int[]{14,26,20,27}));
    AddState(26,new State(-10));
    AddState(27,new State(new int[]{8,28}));
    AddState(28,new State(new int[]{10,31},new int[]{-3,29}));
    AddState(29,new State(new int[]{14,30}));
    AddState(30,new State(-11));
    AddState(31,new State(-36));
    AddState(32,new State(-35));
    AddState(33,new State(-21));
    AddState(34,new State(-18));
    AddState(35,new State(new int[]{9,32},new int[]{-2,36}));
    AddState(36,new State(new int[]{13,24},new int[]{-10,37}));
    AddState(37,new State(new int[]{11,39},new int[]{-21,38}));
    AddState(38,new State(-23));
    AddState(39,new State(new int[]{12,66,22,53,23,54,9,32},new int[]{-20,40,-22,67,-4,43,-9,55,-7,48,-8,49,-2,52}));
    AddState(40,new State(new int[]{12,41,22,53,23,54,9,32},new int[]{-22,42,-4,43,-9,55,-7,48,-8,49,-2,52}));
    AddState(41,new State(-24));
    AddState(42,new State(-29));
    AddState(43,new State(new int[]{9,32},new int[]{-9,44,-7,48,-8,49,-2,52}));
    AddState(44,new State(new int[]{9,32},new int[]{-2,45}));
    AddState(45,new State(new int[]{13,24},new int[]{-10,46}));
    AddState(46,new State(new int[]{21,47}));
    AddState(47,new State(-31));
    AddState(48,new State(-34));
    AddState(49,new State(new int[]{19,50,15,-12,13,-12,17,-12,9,-12,18,-12}));
    AddState(50,new State(new int[]{9,32},new int[]{-2,51}));
    AddState(51,new State(-13));
    AddState(52,new State(-14));
    AddState(53,new State(-37));
    AddState(54,new State(-38));
    AddState(55,new State(new int[]{17,59,9,32},new int[]{-2,56}));
    AddState(56,new State(new int[]{13,24},new int[]{-10,57}));
    AddState(57,new State(new int[]{21,58}));
    AddState(58,new State(-32));
    AddState(59,new State(new int[]{22,53,23,54},new int[]{-4,60}));
    AddState(60,new State(new int[]{9,32},new int[]{-9,61,-7,48,-8,49,-2,52}));
    AddState(61,new State(new int[]{18,62}));
    AddState(62,new State(new int[]{9,32},new int[]{-2,63}));
    AddState(63,new State(new int[]{13,24},new int[]{-10,64}));
    AddState(64,new State(new int[]{21,65}));
    AddState(65,new State(-33));
    AddState(66,new State(-25));
    AddState(67,new State(-30));
    AddState(68,new State(-26));
    AddState(69,new State(-27));
    AddState(70,new State(-28));
    AddState(71,new State(-16));
    AddState(72,new State(new int[]{10,31},new int[]{-17,73,-3,81}));
    AddState(73,new State(new int[]{16,74,19,79}));
    AddState(74,new State(new int[]{13,24},new int[]{-10,75}));
    AddState(75,new State(new int[]{11,76}));
    AddState(76,new State(new int[]{4,14,5,68,6,69,7,70},new int[]{-13,77,-14,71,-15,13,-16,34,-5,35}));
    AddState(77,new State(new int[]{12,78,4,14,5,68,6,69,7,70},new int[]{-14,12,-15,13,-16,34,-5,35}));
    AddState(78,new State(-7));
    AddState(79,new State(new int[]{10,31},new int[]{-3,80}));
    AddState(80,new State(-8));
    AddState(81,new State(-9));
    AddState(82,new State(-4));

    rules=new Rule[39];
    rules[1]=new Rule(-23, new int[]{-1,2});
    rules[2]=new Rule(-1, new int[]{-6});
    rules[3]=new Rule(-6, new int[]{-6,-11});
    rules[4]=new Rule(-6, new int[]{-11});
    rules[5]=new Rule(-11, new int[]{-12});
    rules[6]=new Rule(-12, new int[]{3,-7,-10,11,-13,12});
    rules[7]=new Rule(-12, new int[]{3,-7,15,-17,16,-10,11,-13,12});
    rules[8]=new Rule(-17, new int[]{-17,19,-3});
    rules[9]=new Rule(-17, new int[]{-3});
    rules[10]=new Rule(-10, new int[]{13,-3,14});
    rules[11]=new Rule(-10, new int[]{13,-3,20,8,-3,14});
    rules[12]=new Rule(-7, new int[]{-8});
    rules[13]=new Rule(-8, new int[]{-8,19,-2});
    rules[14]=new Rule(-8, new int[]{-2});
    rules[15]=new Rule(-13, new int[]{-13,-14});
    rules[16]=new Rule(-13, new int[]{-14});
    rules[17]=new Rule(-14, new int[]{-15});
    rules[18]=new Rule(-14, new int[]{-16});
    rules[19]=new Rule(-15, new int[]{4,-2,-10,11,-18,12});
    rules[20]=new Rule(-18, new int[]{-18,-19});
    rules[21]=new Rule(-18, new int[]{-19});
    rules[22]=new Rule(-19, new int[]{-2,-10,21});
    rules[23]=new Rule(-16, new int[]{-5,-2,-10,-21});
    rules[24]=new Rule(-21, new int[]{11,-20,12});
    rules[25]=new Rule(-21, new int[]{11,12});
    rules[26]=new Rule(-5, new int[]{5});
    rules[27]=new Rule(-5, new int[]{6});
    rules[28]=new Rule(-5, new int[]{7});
    rules[29]=new Rule(-20, new int[]{-20,-22});
    rules[30]=new Rule(-20, new int[]{-22});
    rules[31]=new Rule(-22, new int[]{-4,-9,-2,-10,21});
    rules[32]=new Rule(-22, new int[]{-9,-2,-10,21});
    rules[33]=new Rule(-22, new int[]{-9,17,-4,-9,18,-2,-10,21});
    rules[34]=new Rule(-9, new int[]{-7});
    rules[35]=new Rule(-2, new int[]{9});
    rules[36]=new Rule(-3, new int[]{10});
    rules[37]=new Rule(-4, new int[]{22});
    rules[38]=new Rule(-4, new int[]{23});

    nonTerminals = new string[] {"", "document", "identifier", "integer", 
      "field_modifier", "structure_kind", "document_element_list", "namespace", 
      "namespace_list", "field_type", "version_attributes", "document_element", 
      "protocol", "declaration_list", "declaration", "enumeration", "structure", 
      "protocol_identifier", "enumeration_member_list", "enumeration_member", 
      "structure_member_list", "structure_member_block", "structure_member", 
      "$accept", };
  }

  protected override void DoAction(int action)
  {
    switch (action)
    {
      case 2: // document -> document_element_list 
#line 46 "PinchParser.y"
			{ _result = value_stack.array[value_stack.top-1].document; }
        break;
      case 3: // document_element_list -> document_element_list document_element 
#line 49 "PinchParser.y"
			{ value_stack.array[value_stack.top-2].document.Protocols.Add(value_stack.array[value_stack.top-1].protocol); }
        break;
      case 4: // document_element_list -> document_element 
#line 50 "PinchParser.y"
			{ yyval.document = new Document(); yyval.document.Protocols.Add(value_stack.array[value_stack.top-1].protocol); }
        break;
      case 5: // document_element -> protocol 
#line 53 "PinchParser.y"
			{ yyval.protocol = value_stack.array[value_stack.top-1].protocol; }
        break;
      case 6: // protocol -> PROTOCOL namespace version_attributes LBRACE declaration_list RBRACE 
#line 57 "PinchParser.y"
			{ yyval.protocol = value_stack.array[value_stack.top-2].protocol; yyval.protocol.Name = value_stack.array[value_stack.top-5].namespaceName; yyval.protocol.Versioning = value_stack.array[value_stack.top-4].versioning; }
        break;
      case 7: // protocol -> PROTOCOL namespace LPAREN protocol_identifier RPAREN version_attributes LBRACE declaration_list RBRACE 
#line 59 "PinchParser.y"
			{ yyval.protocol = value_stack.array[value_stack.top-2].protocol; yyval.protocol.Name = value_stack.array[value_stack.top-8].namespaceName; yyval.protocol.ProtocolIdentifier = value_stack.array[value_stack.top-6].protocolIdentifier; yyval.protocol.Versioning = value_stack.array[value_stack.top-4].versioning; }
        break;
      case 8: // protocol_identifier -> protocol_identifier DOT integer 
#line 62 "PinchParser.y"
			{ yyval.protocolIdentifier = new ProtocolIdentifier(value_stack.array[value_stack.top-3].protocolIdentifier, value_stack.array[value_stack.top-1].integer); }
        break;
      case 9: // protocol_identifier -> integer 
#line 63 "PinchParser.y"
			{ yyval.protocolIdentifier = new ProtocolIdentifier(value_stack.array[value_stack.top-1].integer); }
        break;
      case 10: // version_attributes -> LBRACKET integer RBRACKET 
#line 66 "PinchParser.y"
			{ yyval.versioning = new Versioning(value_stack.array[value_stack.top-2].integer); }
        break;
      case 11: // version_attributes -> LBRACKET integer COMMA REMOVED integer RBRACKET 
#line 67 "PinchParser.y"
			{ yyval.versioning = new Versioning(value_stack.array[value_stack.top-5].integer, value_stack.array[value_stack.top-2].integer); }
        break;
      case 12: // namespace -> namespace_list 
#line 70 "PinchParser.y"
			{ yyval.namespaceName = value_stack.array[value_stack.top-1].namespaceName; }
        break;
      case 13: // namespace_list -> namespace_list DOT identifier 
#line 73 "PinchParser.y"
			{ yyval.namespaceName = new NamespaceName(value_stack.array[value_stack.top-3].namespaceName, value_stack.array[value_stack.top-1].identifier); }
        break;
      case 14: // namespace_list -> identifier 
#line 74 "PinchParser.y"
			{ yyval.namespaceName = new NamespaceName(value_stack.array[value_stack.top-1].identifier); }
        break;
      case 15: // declaration_list -> declaration_list declaration 
#line 77 "PinchParser.y"
			{ yyval.protocol = value_stack.array[value_stack.top-2].protocol; yyval.protocol.Declarations.Add(value_stack.array[value_stack.top-1].declaration); }
        break;
      case 16: // declaration_list -> declaration 
#line 78 "PinchParser.y"
			{ yyval.protocol = new Protocol(); yyval.protocol.Declarations.Add(value_stack.array[value_stack.top-1].declaration); }
        break;
      case 17: // declaration -> enumeration 
#line 81 "PinchParser.y"
			{ yyval.declaration = value_stack.array[value_stack.top-1].declaration; }
        break;
      case 18: // declaration -> structure 
#line 82 "PinchParser.y"
			{ yyval.declaration = value_stack.array[value_stack.top-1].declaration; }
        break;
      case 19: // enumeration -> ENUMERATION identifier version_attributes LBRACE enumeration_member_list RBRACE 
#line 86 "PinchParser.y"
			{ yyval.declaration = value_stack.array[value_stack.top-2].enumeration; value_stack.array[value_stack.top-2].enumeration.Identifier = value_stack.array[value_stack.top-5].identifier; value_stack.array[value_stack.top-2].enumeration.Versioning = value_stack.array[value_stack.top-4].versioning; }
        break;
      case 20: // enumeration_member_list -> enumeration_member_list enumeration_member 
#line 89 "PinchParser.y"
			{ yyval.enumeration = value_stack.array[value_stack.top-2].enumeration; value_stack.array[value_stack.top-2].enumeration.Members.Add(value_stack.array[value_stack.top-1].enumerationMember); }
        break;
      case 21: // enumeration_member_list -> enumeration_member 
#line 90 "PinchParser.y"
			{ yyval.enumeration = new Enumeration(); yyval.enumeration.Members.Add(value_stack.array[value_stack.top-1].enumerationMember); }
        break;
      case 22: // enumeration_member -> identifier version_attributes SEMICOLON 
#line 93 "PinchParser.y"
			{ yyval.enumerationMember = new EnumerationMember(value_stack.array[value_stack.top-3].identifier, value_stack.array[value_stack.top-2].versioning); }
        break;
      case 23: // structure -> structure_kind identifier version_attributes structure_member_block 
#line 97 "PinchParser.y"
			{ yyval.declaration = value_stack.array[value_stack.top-1].structure; value_stack.array[value_stack.top-1].structure.Identifier = value_stack.array[value_stack.top-3].identifier; value_stack.array[value_stack.top-1].structure.Versioning = value_stack.array[value_stack.top-2].versioning; value_stack.array[value_stack.top-1].structure.StructureKind = (StructureKind)value_stack.array[value_stack.top-4].integer; }
        break;
      case 24: // structure_member_block -> LBRACE structure_member_list RBRACE 
#line 100 "PinchParser.y"
			{ yyval.structure = value_stack.array[value_stack.top-2].structure; }
        break;
      case 25: // structure_member_block -> LBRACE RBRACE 
#line 101 "PinchParser.y"
			{ yyval.structure = new Structure(); }
        break;
      case 26: // structure_kind -> MESSAGE 
#line 104 "PinchParser.y"
			{ yyval.integer = (int)StructureKind.Message; }
        break;
      case 27: // structure_kind -> STRUCTURE 
#line 105 "PinchParser.y"
			{ yyval.integer = (int)StructureKind.Structure; }
        break;
      case 28: // structure_kind -> CHOICE 
#line 106 "PinchParser.y"
			{ yyval.integer = (int)StructureKind.Choice; }
        break;
      case 29: // structure_member_list -> structure_member_list structure_member 
#line 109 "PinchParser.y"
			{ yyval.structure = value_stack.array[value_stack.top-2].structure; value_stack.array[value_stack.top-2].structure.Members.Add(value_stack.array[value_stack.top-1].structureMember); }
        break;
      case 30: // structure_member_list -> structure_member 
#line 110 "PinchParser.y"
			{ yyval.structure = new Structure(); yyval.structure.Members.Add(value_stack.array[value_stack.top-1].structureMember); }
        break;
      case 31: // structure_member -> field_modifier field_type identifier version_attributes SEMICOLON 
#line 114 "PinchParser.y"
			{ yyval.structureMember = new StructureMember((FieldModifier)value_stack.array[value_stack.top-5].integer, value_stack.array[value_stack.top-4].namespaceName, value_stack.array[value_stack.top-3].identifier, value_stack.array[value_stack.top-2].versioning); }
        break;
      case 32: // structure_member -> field_type identifier version_attributes SEMICOLON 
#line 116 "PinchParser.y"
			{ yyval.structureMember = new StructureMember((FieldModifier)0, value_stack.array[value_stack.top-4].namespaceName, value_stack.array[value_stack.top-3].identifier, value_stack.array[value_stack.top-2].versioning); }
        break;
      case 33: // structure_member -> field_type LPOINTY field_modifier field_type RPOINTY identifier version_attributes SEMICOLON 
#line 118 "PinchParser.y"
			{ yyval.structureMember = new StructureMember((FieldModifier)value_stack.array[value_stack.top-6].integer, value_stack.array[value_stack.top-5].namespaceName, value_stack.array[value_stack.top-3].identifier, value_stack.array[value_stack.top-2].versioning, value_stack.array[value_stack.top-8].namespaceName); }
        break;
      case 34: // field_type -> namespace 
#line 121 "PinchParser.y"
			{ yyval.namespaceName = value_stack.array[value_stack.top-1].namespaceName; }
        break;
      case 35: // identifier -> IDENTIFIER 
#line 124 "PinchParser.y"
			{ yyval.identifier = value_stack.array[value_stack.top-1].identifier; }
        break;
      case 36: // integer -> INTEGER 
#line 127 "PinchParser.y"
			{ yyval.integer = value_stack.array[value_stack.top-1].integer; }
        break;
      case 37: // field_modifier -> REQUIRED 
#line 130 "PinchParser.y"
			{ yyval.integer = 1; }
        break;
      case 38: // field_modifier -> OPTIONAL 
#line 131 "PinchParser.y"
			{ yyval.integer = 2; }
        break;
    }
  }

  protected override string TerminalToString(int terminal)
  {
    if (((Tokens)terminal).ToString() != terminal.ToString())
      return ((Tokens)terminal).ToString();
    else
      return CharToString((char)terminal);
  }

#line 134 "PinchParser.y"


Document _result = null;

public Document Result
{
	get { return _result; }
}
}
}
