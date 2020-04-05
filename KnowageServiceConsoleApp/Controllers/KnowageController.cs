using KnowageService.Models.Result;
using KnowageServiceConsoleApp.BusinessLogicLayer;
using KnowageServiceConsoleApp.Models.Knowage.DocumentRequestParameters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection;
using static KnowageService.Common.Constants;

namespace KnowageServiceConsoleApp.Controllers
{
    public class KnowageController
    {
        private readonly ILogger<KnowageController> _logger;
        public KnowageController()
        { }

        public SearchRecordResult GetScheduledTasks()
        {
            SearchRecordResult result = new SearchRecordResult();
            //TODO: Fetch a list of reports to be performed at this specific time
            //I choose to keep a list of reports and their execution time in a database. YMMV
            return result;
        }

        public void ExportReport(string DocumentLabel)
        {
            KnowageBLL bll = new KnowageBLL();
            KnowageResult result = new KnowageResult();
            KnowageService.Models.Knowage.DocumentParameters.RootObject DocumentParameters = new KnowageService.Models.Knowage.DocumentParameters.RootObject();
            Document document = new Document();

            string parameter1 = "value1";
            string parameter2 = "value2";
            string parameter3 = "value3";
            string parameter4 = "value4";
            string parameter5 = "value5";
            string documentParameter = "";
            
            GetDocumentParameter(bll, result, DocumentLabel);
            SetDocumentParameter(document, bll, DocumentParameters, parameter1, parameter2);
            documentParameter = JsonConvert.SerializeObject(document);
            GetDocumentContent(bll, result, DocumentLabel, documentParameter);

            string htmlString = result.Response.Content.ToString();

            if (!htmlString.Contains("Error"))
            {
                //Convert htmlString to PDF
                //Send as email attachment to receipients;
            }
        }

        private void GetDocumentContent(KnowageBLL bll, KnowageResult result, string DocumentLabel, string DocumentParameters)
        {
            bll.GetDocumentContent(result ,DocumentLabel, DocumentParameters);

            if (result.Message == Result.SUCCESSFUL)
            {
                //log succesfull
            }
            else if (result.Message == Result.FAILED)
            {
                //log failed;
            }
            else if (result.Message == Result.EXCEPTION)
            {
                string logMessage = string.Concat("Excption occured:", MethodBase.GetCurrentMethod(), " - " ,result.ObjectException);
                _logger.LogError(logMessage);
            }
        }

        private void GetDocumentParameter(KnowageBLL bll, KnowageResult result, string DocumentLabel)
        {
            bll.GetDocumentParameter(result, DocumentLabel);

            if (result.Message == Result.SUCCESSFUL)
            {
                //log succesfull
            }
            else if (result.Message == Result.FAILED)
            {
                //log failed;
            }
            else if (result.Message == Result.EXCEPTION)
            {
                string logMessage = string.Concat("Excption occured:", MethodBase.GetCurrentMethod(), " - ", result.ObjectException);
                _logger.LogError(logMessage); 
            }
        }

        private void SetDocumentParameter(Document document, KnowageBLL bll, KnowageService.Models.Knowage.DocumentParameters.RootObject DocumentParameters,
                                            string Parameter1 = "", string Parameter2 = "", string Parameter3 = "", string Parameter4 = "", string Parameter5 = "")
        {
            bll.SetDocumentParameters(document, DocumentParameters, Parameter1, Parameter2);

        }


    }
}
