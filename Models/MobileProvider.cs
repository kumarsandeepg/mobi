using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MobileAshApi.Models
{
    public class ErrorCodes
    {
        public static Dictionary<int, string> Codes = new Dictionary<int, string> { };

        private ErrorCodes()
        {
            Codes.Add(1000, "SUCCESS");
            Codes.Add(1002, "LOGIN FAILED");
            Codes.Add(1003, "ACCESS DENIED");
            Codes.Add(1004, "API NOT ASSIGNED");
            Codes.Add(1005, "INVALID MOBILE NUMBER");
            Codes.Add(1006, "INVALID AMOUNT");
            Codes.Add(1007, "DUPLICATE REQID");
            Codes.Add(1008, "NETWORK ERROR");
            Codes.Add(1009, "FREQUENT RECHARGE");
            Codes.Add(1010, "RECHARGE PENDING");
            Codes.Add(1011, "INTERNAL ERROR");
            Codes.Add(1013, "OPERATOR DOWN");
            Codes.Add(1014, "REFUND");
            Codes.Add(1015, "INSUFFICIENT BALANCE");
            Codes.Add(1016, "INSUFFICIENT MINIMUM BALANCE");
            Codes.Add(1017, "REFUND DECLINED");
        }
    }

    public class ResponseStatus
    {        
    }


    public class MobileServiceProvider : ResponseStatus
    {
        internal string __type { get; set; }
        public string Code { get; set; }
        public string Provider { get; set; }
        public string State { get; set; }
        public int OpId { get; set; }
        public int CId { get; set; }
    }

    public class RechargeStatus : ResponseStatus
    {
        internal string ReqId { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public string Balance { get; set; }
        internal string Field1 { get; set; }
        public string Error { get; set; }
        public string MobileNumber { get; set; }
        internal int ErrorCode { get; set; }        
    }
}