using System;
namespace BOL.API.Service.Models;

public class EntityAttribute
{
	public int AttrId { get; set; }
	public string AttrDesc { get; set; }
	public string AttrValue { get; set; }
	public int EntId { get; set; }
}

