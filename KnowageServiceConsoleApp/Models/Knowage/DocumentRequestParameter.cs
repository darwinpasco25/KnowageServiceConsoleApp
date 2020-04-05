using System.Collections.Generic;

namespace KnowageServiceConsoleApp.Models.Knowage.DocumentRequestParameters
{
    public class Document
    {
        public List<DocumentParameters> DocumentParameters { get; set; }
    }

    public class DocumentParameters
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
        public string urlName { get; set; }
        public List<string> values { get; set; }
    }
}
