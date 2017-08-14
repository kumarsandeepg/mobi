using MobileAshApi.BL;
using MobileAshApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MobileAshApi.Controllers
{
    public class MobileAshController : ApiController
    {

        public const string baseurl = "http://www.digigroups.in/apiservice.asmx/";

        WebServiceClient client = new WebServiceClient();

        ErrorCodes errors = new ErrorCodes();

        public void go() { }
        [HttpGet]
        [Route("recharge/{apiToken}/{mobile}/{vendor}/{amount}/{reqid}")]
        //[Route("recharge/{apiToken}/{mobile}/{vendor}/{amount}/{reqid}/{optionalField1}")]
        //[Route("recharge/{apiToken}/{mobile}/{vendor}/{amount}/{reqid}/{optionalField1}/{optionalField2}")]
        public async Task<RechargeStatus> Recharge(string apiToken, string mobile, int vendor, int amount, string reqid)
        {
            var model = await client.WebClientResponse<RechargeStatus>(baseurl + "Recharge",
                new { apiToken = apiToken, mn = mobile, op = vendor, amt = amount, reqid = reqid, field1 = "", field2 = "" });

             model.Error = errors.Codes[model.EC];
            

            return model;
        }
        
        [HttpGet]
        [Route("getoperator/{mobile}")]
        public async Task<MobileServiceProvider> GetOperator(string mobile)
        {
            var model = await client.WebClientResponse<MobileServiceProvider>(baseurl + "GetOperator", new { mn = mobile });
            return model;
        }       

        [HttpGet]
        [Route("balance/{apiToken}")]
        public async Task<BalanceProvider> Balance(string apiToken)
        {
            var model = await client.WebClientJSonStr(baseurl + "GetBalance", new { apiToken = apiToken }, true);

            return new BalanceProvider { Balance=model };
        }

        [HttpGet]
        [Route("registercomplaint/{apiToken}/{reqid}")]
        public async Task<ResponseStatus> RegisterComplaint(string apiToken, string reqId)
        {
            var model = await client.WebClientJSonStr(baseurl + "RegisterComplaint", new { apiToken = apiToken, reqid = reqId }, true);

            return new ResponseStatus { Status = model };
        }

        [HttpGet]
        [Route("getrechargestatus/{apiToken}/{reqid}")]
        public async Task<RechargeStatus> GetRechargeStatus(string apiToken, string reqid)
        {
            var model = await client.WebClientResponse<RechargeStatus>(baseurl + "GetRechargeStatus ", new { apiToken = apiToken, reqid = reqid },true);
            return model;
        }
    }
}
