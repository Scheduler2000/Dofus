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

public class Server
{

    public int Id { get; set; }

    public uint NameId { get; set; }

    public uint CommentId { get; set; }

    public double OpeningDate { get; set; }

    public string Language { get; set; }

    public int PopulationId { get; set; }

    public uint GameTypeId { get; set; }

    public int CommunityId { get; set; }

    public List<string> RestrictedToLanguages { get; set; }

    public bool MonoAccount { get; set; }

}