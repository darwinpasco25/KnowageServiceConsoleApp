using System.Collections.Generic;

namespace KnowageService.Models.Knowage.LOV
{
    public class MetaData
    {
        public string totalProperty { get; set; }
        public string root { get; set; }
        public string id { get; set; }
        public List<object> fields { get; set; }
    }

    public class Row
    {
        public int id { get; set; }
        public string column_1 { get; set; }
        public string column_2 { get; set; }

        //Limit to 2 columns
        // column_1 - value
        // column_2 - description
    }

    public class RootObject
    {
        public MetaData metaData { get; set; }
        public int results { get; set; }
        public List<Row> rows { get; set; }
    }
}
