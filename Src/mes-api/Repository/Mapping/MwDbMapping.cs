using System;
namespace BOL.API.Repository.Mapping
{
	public class MwDbMapping
	{
		public List<DbObject> DbObjects { get; set; }
		public List<DbObject> MwObjects { get; set; }
	}

	public class DbObject
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}
}

