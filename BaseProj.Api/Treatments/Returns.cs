using BaseProj.Api.Treatments.Enums;
using System;

namespace BaseProj.Api.Treatments
{
    public abstract class Return { }

    public class Success : Return
    {
        public Success(dynamic data)
        {
            Status = 0;
            Data = data;
        }

        public Success(dynamic data, string token)
        {
            Status = 0;
            Data = data;
            Token = token;
        }

        public Success(Suc suc)
        {
            Status = (int)suc;
            Data = suc.ToDescription();
        }

        public Success(Suc suc, dynamic data, string token)
        {
            Status = (int)suc;
            Data = data;
            Token = token;
            Message = suc.ToDescription();
        }

        public int Status;

        public object Data;

        public string Token;

        public string Message;
    }

    public class Error : Success
    {
        public Error(Exception ex) : base(ex.Message)
        {
            Status = ex.HResult;
            StackTrace = ex.StackTrace;
        }

        public Error(Err err) : base(err.ToDescription())
        {
            Status = (int)err;
        }

        public string StackTrace { get; set; }
    }
}
