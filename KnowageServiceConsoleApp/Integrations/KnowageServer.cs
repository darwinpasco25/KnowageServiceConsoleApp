using KnowageService.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using static KnowageService.Common.Constants;

namespace KnowageService.Integrations
{
    public class KnowageServer
    {
        public KnowageServer()
        {
        }

        ///<summary>
        ///<para>Get the parameters of a Knowage report from the server</para>
        ///<para>Returns IRestResonse</para>
        ///</summary>
        public IRestResponse GetDocumentParameters(string DocumentLabel, out int outResult)
        {
            IRestResponse response;
            try
            {
                var client = new RestClient(String.Concat(URLs.KnowageURL, "/restful-services/2.0/documents/", DocumentLabel, "/parameters"));
                client.Authenticator = new HttpBasicAuthenticator(KnowageHeaders.UserName, KnowageHeaders.Password);

                var request = new RestRequest(Method.GET);
                request.AddHeader("Host", KnowageHeaders.Host);
                request.AddHeader("Accept", "*/*");
                request.AddHeader("Content-Type", "application/json");
                response = client.Execute(request);

                if (response.ContentLength == -1)
                {
                    outResult = Output.SUCCESSFUL;
                }
                else if (response.Content.Contains("errors"))
                {
                    outResult = Output.ERROR;
                }
                else
                {
                    outResult = Output.EMPTY;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        ///<summary>
        ///<para>Get content of a Knowage report from the server</para>
        ///<para>Report can be a BIRT or Jasper report (.jrxml)</para>
        ///<para>Returns IRestResonse</para>
        ///</summary>
        public IRestResponse GetDocumentContent(string DocumentLabel, string DocumentParameter, out int outResult)
        {
            
            //cleanup JSON string parameter
            string parameters = DocumentParameter.ToString().Replace("\"DocumentParameters\":", string.Empty);
            parameters = parameters.Remove(parameters.Length - 1, 1);
            parameters = parameters.Remove(0, 1);

            IRestResponse response;
            try
            {
                var client = new RestClient(String.Concat(URLs.KnowageURL, "/restful-services/2.0/documents/", DocumentLabel, "/content"));
                client.Authenticator = new HttpBasicAuthenticator(KnowageHeaders.UserName, KnowageHeaders.Password);

                var request = new RestRequest(Method.POST);
                request.AddHeader("Host", KnowageHeaders.Host);
                request.AddHeader("Accept", "*/*");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", parameters, ParameterType.RequestBody);
                request.AddQueryParameter("outputType", "HTML");  //PDF, CSV, XLSX
                response = client.Execute(request);

                if(response.ContentLength == -1)
                {
                    outResult = Output.SUCCESSFUL;
                }
                else if (response.Content.Contains("errors"))
                {
                    outResult = Output.ERROR;
                }
                else
                {
                    outResult = Output.EMPTY;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        ///<summary>
        ///<para>Get content of a Knowage Dataset</para>
        ///<para>Returns IRestResonse</para>
        ///</summary>
        public IRestResponse GetDatasetContent(string DataSetLabel, string DataSetParameter, out int outResult)
        {
            string contentURL;
            if (DataSetParameter == string.Empty)
            {
                contentURL = string.Concat(DataSetLabel, "/content");
            }
            else
            {
                contentURL = string.Concat(DataSetLabel, "/content?", DataSetParameter);
            }

            IRestResponse response;
            try
            {   
                var client = new RestClient(String.Concat(URLs.KnowageURL, "/restful-services/2.0/datasets/", contentURL));
                client.Authenticator = new HttpBasicAuthenticator(KnowageHeaders.UserName, KnowageHeaders.Password);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Host", KnowageHeaders.Host);
                request.AddHeader("Accept", "*/*");
                request.AddHeader("Content-Type", "application/json");
                response = client.Execute(request);

                if (response.ContentLength == -1)
                {
                    outResult = Output.SUCCESSFUL;
                }
                else if (response.Content.Contains("errors"))
                {
                    outResult = Output.ERROR;
                }
                else
                {
                    outResult = Output.EMPTY;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        ///<summary>
        ///<para>Get the schema of a Knowage Dataset</para>
        ///<para>Returns IRestResonse</para>
        ///</summary>
        public IRestResponse GetDatasetSchema(string DataSetLabel, out int outResult)
        {
            IRestResponse response;
            try
            {
                var client = new RestClient(String.Concat(URLs.KnowageURL, "/restful-services/2.0/datasets/", DataSetLabel));
                client.Authenticator = new HttpBasicAuthenticator(KnowageHeaders.UserName, KnowageHeaders.Password);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Host", KnowageHeaders.Host);
                request.AddHeader("Accept", "*/*");
                request.AddHeader("Content-Type", "application/json");
                response = client.Execute(request);

                if (response.ContentLength == -1)
                {
                    outResult = Output.SUCCESSFUL;
                }
                else if (response.Content.Contains("errors"))
                {
                    outResult = Output.ERROR;
                }
                else
                {
                    outResult = Output.EMPTY;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
