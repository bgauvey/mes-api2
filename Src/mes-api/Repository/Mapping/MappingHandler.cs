using System;
using System.Dynamic;
using System.Xml;
using BOL.API.Domain.Models;
using Newtonsoft.Json;

namespace BOL.API.Repository.Mapping
{
	public class MappingHandler
	{
		private readonly string _factelligenceMwDbMappingFilePath;
		private readonly string _customMwDbMappings;

		ExpandoObject _mwDbMapping;
        ExpandoObject _customMwDbMapping;

        public MappingHandler()
		{
			_factelligenceMwDbMappingFilePath = "FactelligenceMWDBMappings.xml";

            _customMwDbMappings = "FactelligenceMWDBMappingsCustom.xml";

			string path = Path.Combine(AppContext.BaseDirectory, _factelligenceMwDbMappingFilePath);
            if (File.Exists(path))
            {
				dynamic mapping = JsonConvert.DeserializeObject<ExpandoObject>(GetMappings(path));
				_mwDbMapping = mapping;
            }

            path = Path.Combine(AppContext.BaseDirectory, _customMwDbMappings);
            if (File.Exists(path))
            {
                dynamic mapping = JsonConvert.DeserializeObject<ExpandoObject>(GetMappings(path));
                _customMwDbMapping = mapping;
            }
        }

		private string GetMappings(string xmlPath)
		{

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlPath);
			string jsonText = JsonConvert.SerializeXmlNode(doc);

			return jsonText;

        }

	}
}

