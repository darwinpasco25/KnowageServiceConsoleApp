using KnowageService.Integrations;
using KnowageService.Models.Result;
using KnowageServiceConsoleApp.Models.Knowage.DocumentRequestParameters;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using static KnowageService.Common.Constants;

namespace KnowageServiceConsoleApp.BusinessLogicLayer
{
    public class KnowageBLL
    {
        public KnowageBLL()
        { }

        KnowageServer knowageServer = new KnowageServer();

        public void GetDocumentParameter(KnowageResult result, string DocumentLabel)
        {
            try
            {
                IRestResponse response = knowageServer.GetDocumentParameters(DocumentLabel, out int outResult);

                if (outResult == Output.SUCCESSFUL)
                {
                    result.Result = Result.SUCCESSFUL;
                    result.Response = response;

                    KnowageService.Models.Knowage.DocumentParameters.RootObject rootObject = new KnowageService.Models.Knowage.DocumentParameters.RootObject();
                    result.DocumentParameters = JsonConvert.DeserializeObject<KnowageService.Models.Knowage.DocumentParameters.RootObject >(response.Content.ToString());
                }
                else if (outResult == Output.EMPTY)
                {
                    result.Result = Result.FAILED;
                    result.Message = Messages.RESPONSE_CONTENT_IS_EMPTY;
                }
                else
                {
                    result.Result = Result.FAILED;
                    result.Message = Messages.RESPONSE_CONTAINS_ERROR;
                    result.ErrorMessage = response.Content.ToString();
                }
            }
            catch (Exception ex)
            {
                result.Result = Result.EXCEPTION;
                result.ErrorMessage = ex.Message;
                result.ObjectException = ex;
            }
        }

        public void SetDocumentParameters(Document document, KnowageService.Models.Knowage.DocumentParameters.RootObject documentParameters,
                                                string Parameter1 = "", string Parameter2 = "", string Parameter3 = "", string Parameter4 = "", string Parameter5 = "")
        {
            List<DocumentParameters> parameters = new List<DocumentParameters>();
            var stringProps = documentParameters
                .GetType()
                .GetProperties()
                .Where(p => p.Name == "parameterUrlName");

            foreach (var prop in stringProps)
            {
                string parameterUrlName = (string)prop.GetValue(documentParameters.parameterUrlName);

                foreach (var parameter in documentParameters.parameter)
                {
                    List<string> values = new List<string>();

                    KnowageService.Models.Knowage.LOV.RootObject lov = new KnowageService.Models.Knowage.LOV.RootObject();

                    //validate the url name of the parameter and assign value to it
                    if (parameterUrlName == "param1") //"_PrincipalCode"
                    {
                        values.Add(Parameter1);
                    }
                    else if (parameterUrlName == "param2") //_BankCode
                    {
                        values.Add(Parameter2);
                    }
                    else if (parameterUrlName == "param3") //whatever
                    {
                        values.Add(Parameter3);
                    }
                    else if (parameterUrlName == "param4") //whatever
                    {
                        values.Add(Parameter4);
                    }
                    else if (parameterUrlName == "param5") //whatever
                    {
                        values.Add(Parameter5);
                    }
                    else if (parameterUrlName == "param_date_from") //"_FromDate"
                    {
                        //date range start date, first day of nonth
                        var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        values.Add(firstDayOfMonth.ToString("yyyy-MM-dd"));
                    }
                    else if (parameterUrlName == "param_date_to") //"_ToDate"
                    {
                        //date range end date. last day of month
                        var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                        values.Add(lastDayOfMonth.ToString("yyyy-MM-dd"));
                    }
                    else if (parameterUrlName == "param_date") //TranxDate
                    {
                        //date
                        values.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                    }

                    parameters.Add(new DocumentParameters()
                    {
                        id = parameter.id.ToString(),
                        label = parameter.label,
                        type = parameter.type,
                        urlName = parameterUrlName,
                        values = values
                    });
                }
            }

            document.DocumentParameters = parameters;
        }
        public void GetDocumentContent(KnowageResult result, string DocumentLabel, string DocumentParameters)
        {
            try
            {
                IRestResponse response = knowageServer.GetDocumentContent(DocumentLabel, DocumentParameters, out int outResult);

                if (outResult == Output.SUCCESSFUL)
                {
                    result.Result = Result.SUCCESSFUL;
                    result.Response = response;
                }
                else if (outResult == Output.EMPTY)
                {
                    result.Result = Result.FAILED;
                    result.Message = Messages.RESPONSE_CONTENT_IS_EMPTY;
                }
                else
                {
                    result.Result = Result.FAILED;
                    result.Message = Messages.RESPONSE_CONTAINS_ERROR;
                    result.ErrorMessage = response.Content.ToString();
                }
            }
            catch (Exception ex)
            {
                result.Result = Result.EXCEPTION;
                result.ErrorMessage = ex.Message;
                result.ObjectException = ex;
            }
        }

        public KnowageResult GetDataSetSchema(string DataSetLabel)
        {
            KnowageResult knowageResult = new KnowageResult();
            try
            {
                IRestResponse response = knowageServer.GetDatasetSchema(DataSetLabel, out int outResult);

                if (outResult == Output.SUCCESSFUL)
                {
                    knowageResult.Result = Result.SUCCESSFUL;
                    knowageResult.Response = response;

                    KnowageService.Models.Knowage.DataSetSchema.RootObject rootObject = new KnowageService.Models.Knowage.DataSetSchema.RootObject();
                    knowageResult.DataSetSchema = JsonConvert.DeserializeObject<KnowageService.Models.Knowage.DataSetSchema.RootObject>(response.Content.ToString());
                }
                else if (outResult == Output.EMPTY)
                {
                    knowageResult.Result = Result.FAILED;
                    knowageResult.Message = Messages.RESPONSE_CONTENT_IS_EMPTY;
                }
                else
                {
                    knowageResult.Result = Result.FAILED;
                    knowageResult.Message = Messages.RESPONSE_CONTAINS_ERROR;
                    knowageResult.ErrorMessage = response.Content.ToString();
                }

            }
            catch(Exception ex)
            {
                knowageResult.Result = Result.EXCEPTION;
                knowageResult.ErrorMessage = ex.Message;
                knowageResult.ObjectException = ex;
            }
            return knowageResult;
        }

        public KnowageResult GetLOV(string DataSetLabel, string DataSetParameter)
        {
            /* There really is no API method for LOV
              create a DataSet in knowage that returns a list of value for your parameter
            */
            KnowageResult knowageResult = new KnowageResult();
            try
            {
                IRestResponse response = knowageServer.GetDatasetContent(DataSetLabel, DataSetParameter, out int outResult);

                if (outResult == Output.SUCCESSFUL)
                {
                    knowageResult.Result = Result.SUCCESSFUL;
                    knowageResult.Response = response;

                    KnowageService.Models.Knowage.LOV.RootObject rootObject = new KnowageService.Models.Knowage.LOV.RootObject();
                    knowageResult.LOV = JsonConvert.DeserializeObject<KnowageService.Models.Knowage.LOV.RootObject>(response.Content.ToString());
                }
                else if (outResult == Output.EMPTY)
                {
                    knowageResult.Result = Result.FAILED;
                    knowageResult.Message = Messages.RESPONSE_CONTENT_IS_EMPTY;
                }
                else
                {
                    knowageResult.Result = Result.FAILED;
                    knowageResult.Message = Messages.RESPONSE_CONTAINS_ERROR;
                    knowageResult.ErrorMessage = response.Content.ToString();
                }
            }
            catch (Exception ex)
            {
                knowageResult.Result = Result.EXCEPTION;
                knowageResult.ErrorMessage = ex.Message;
                knowageResult.ObjectException = ex;
            }
            return knowageResult;
        }
    }
}
