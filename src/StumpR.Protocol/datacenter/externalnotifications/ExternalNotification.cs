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

public class ExternalNotification
{

    public int Id { get; set; }

    public int CategoryId { get; set; }

    public int IconId { get; set; }

    public int ColorId { get; set; }

    public uint DescriptionId { get; set; }

    public bool DefaultEnable { get; set; }

    public bool DefaultSound { get; set; }

    public bool DefaultNotify { get; set; }

    public bool DefaultMultiAccount { get; set; }

    public string Name { get; set; }

    public uint MessageId { get; set; }

}