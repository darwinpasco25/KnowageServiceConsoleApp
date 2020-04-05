using RestSharp;

namespace KnowageService.Models.Result
{
    public class KnowageResult : BaseResult
    {
        public IRestResponse Response { get; set; }
        public Knowage.DataSetSchema.RootObject DataSetSchema { get; set; }
        public Knowage.LOV.RootObject LOV { get; set; }
        public Knowage.DocumentParameters.RootObject DocumentParameters { get; set; }
    }
}
