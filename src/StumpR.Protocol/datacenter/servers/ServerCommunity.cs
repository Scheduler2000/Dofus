//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 2/19/2022 5:49:39 PM.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------


using System;
using System.Drawing;
using System.Collections.Generic;

namespace StumpR.Protocol.Datacenter;

public class ServerCommunity
{

    public int Id { get; set; }

    public uint NameId { get; set; }

    public string ShortId { get; set; }

    public List<string> DefaultCountries { get; set; }

    public List<int> SupportedLangIds { get; set; }

    public int NamingRulePlayerNameId { get; set; }

    public int NamingRuleGuildNameId { get; set; }

    public int NamingRuleAllianceNameId { get; set; }

    public int NamingRuleAllianceTagId { get; set; }

    public int NamingRulePartyNameId { get; set; }

    public int NamingRuleMountNameId { get; set; }

    public int NamingRuleNameGeneratorId { get; set; }

    public int NamingRuleAdminId { get; set; }

    public int NamingRuleModoId { get; set; }

    public int NamingRulePresetNameId { get; set; }

}