using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Configuration;
using System.Net;
using TestAssignment_NopCommerce.Pages;

namespace TestAssignment_NopCommerce.TestCases
{
    [TestFixture]
    public class TC_JsonAPITest
    {
        //fetch values to verify
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string APIURL = ConfigurationManager.AppSettings["APIURL"];
        private static string RecordIdToFetch = ConfigurationManager.AppSettings["RecordIdToFetch"];
        private static string verifyTitle = ConfigurationManager.AppSettings["verifyTitle"];
        private static string verifyUserid = ConfigurationManager.AppSettings["verifyUserid"];

        [Test]  //This Test using NunitFramework
        public void RestApiTestingPOST()
        {
            try
            {
                //
                RestResponse response = FetchAPIParameters(APIURL, RecordIdToFetch);
                bool titleResult = validate_API_response(response, "title", verifyTitle);
                bool userIdResult = validate_API_response(response, "userId", verifyUserid);

                if (titleResult && userIdResult)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Boolean validate_API_response(RestResponse response, string paramtype, string paramvalue)
        {
            Boolean result = false;
            try
            {
                //check if response is not null or 201
                if (response != null && ((response.StatusCode == HttpStatusCode.OK) &&
                     (response.ResponseStatus == ResponseStatus.Completed)))
                {
                    //deserialize Json 
                    var obj = JsonConvert.DeserializeObject<API_Format>(response.Content);
                    //   Console.WriteLine(obj.title);
                    String Response_param_value = null;
                    switch (paramtype)
                    {
                        case "title":
                            Response_param_value = obj.title;
                            break;
                        case "userId":
                            Response_param_value = obj.userId.ToString();
                            break;
                    }
                    if (Response_param_value.Equals(paramvalue))
                    {
                        //     log.Info("Validation Successful");
                        Console.WriteLine("{0}:   Verification Successful with value {1}", paramtype, Response_param_value);
                        //Assert.Pass();

                        result = true;
                    }
                    else
                    {
                        //Console.WriteLine("{0}:   Verification Fails with value {1}", paramtype, Response_param_value);
                        log.Error("Validation Fails");
                        //Assert.Fail();
                        Console.WriteLine("Orig value  ->" + paramvalue + "    Fetched Value --> " + Response_param_value);
                        result = false;
                    }

                }
                else if (response != null)
                {
                    Console.WriteLine(string.Format("Status code is {0} ({1}); response status is {2}", response.StatusCode, response.StatusDescription, response.ResponseStatus));
                    log.Error("Request is incorrect");
                    result = false;
                }
            }
            catch (JsonSerializationException ex)
            {
                log.Error("Error in JSON Serialization  " + ex.Message);
                result = false;
            }
            catch (JsonException ex)
            {
                log.Error("Error in JSON " + ex.Message);
                result = false;
            }

            return result;
        }

        //fetch API Parameters
        public RestResponse FetchAPIParameters(String URL, String requestBody)
        {
            try
            {
                var client = new RestClient(URL);
                var request = new RestRequest(requestBody, Method.GET);
                return client.Execute(request) as RestResponse;
            }
            catch (Exception ex)
            {
                log.Error("Error in fetch API " + ex.Message);
                return null;
            }
        }
    }
}