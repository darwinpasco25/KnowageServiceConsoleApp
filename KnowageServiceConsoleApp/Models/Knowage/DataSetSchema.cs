using System.Collections.Generic;

namespace KnowageService.Models.Knowage.DataSetSchema
{
    public class Par
    {
        public string name { get; set; }
        public string type { get; set; }
        public string defaultValue { get; set; }
        public bool multiValue { get; set; }
    }

    public class Dataset
    {
        public string pname { get; set; }
        public string pvalue { get; set; }
    }

    public class Column
    {
        public string column { get; set; }
        public string pname { get; set; }
        public string pvalue { get; set; }
    }

    public class Meta
    {
        public List<Dataset> dataset { get; set; }
        public List<Column> columns { get; set; }
    }

    public class Action
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class RootObject
    {
        public int id { get; set; }
        public string label { get; set; }
        public string name { get; set; }
        public int usedByNDocs { get; set; }
        public string catTypeVn { get; set; }
        public int catTypeId { get; set; }
        public List<Par> pars { get; set; }
        public Meta meta { get; set; }
        public List<object> dsVersions { get; set; }
        public string dsTypeCd { get; set; }
        public string userIn { get; set; }
        public int versNum { get; set; }
        public string dateIn { get; set; }
        public string query { get; set; }
        public string queryScript { get; set; }
        public string queryScriptLanguage { get; set; }
        public string dataSource { get; set; }
        public bool pivotIsNumRows { get; set; }
        public bool isPersisted { get; set; }
        public bool isPersistedHDFS { get; set; }
        public string persistTableName { get; set; }
        public bool isScheduled { get; set; }
        public bool isRealtime { get; set; }
        public bool isIterable { get; set; }
        public string owner { get; set; }
        public string scopeCd { get; set; }
        public int scopeId { get; set; }
        public List<Action> actions { get; set; }
    }
}
