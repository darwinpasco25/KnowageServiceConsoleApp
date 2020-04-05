using System.Collections.Generic;

namespace KnowageService.Models.Knowage.DocumentParameters
{
    public class Parameter
    {
        public int id { get; set; }
        public string description { get; set; }
        public int length { get; set; }
        public string label { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string mask { get; set; }
        public int typeId { get; set; }
        public string modality { get; set; }
        public object modalityValue { get; set; }
        public object modalityValueForDefault { get; set; }
        public string defaultFormula { get; set; }
        public string valueSelection { get; set; }
        public object selectedLayer { get; set; }
        public object selectedLayerProp { get; set; }
        public object checks { get; set; }
        public bool temporal { get; set; }
        public bool functional { get; set; }
    }

    public class RootObject
    {
        public int id { get; set; }
        public int biObjectID { get; set; }
        public int parID { get; set; }
        public List<Parameter> parameter { get; set; }
        public string label { get; set; }
        public int modifiable { get; set; }
        public int visible { get; set; }
        public object colSpan { get; set; }
        public object thickPerc { get; set; }
        public int prog { get; set; }
        public int priority { get; set; }
        public string parameterUrlName { get; set; }
        public object parameterValues { get; set; }
        public object parameterValuesDescription { get; set; }
        public bool transientParmeters { get; set; }
        public object parameterValuesRetriever { get; set; }
        public bool iterative { get; set; }
        public bool required { get; set; }
        public bool multivalue { get; set; }
    }
}
