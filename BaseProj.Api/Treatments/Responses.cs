using BaseProj.Api.Treatments.Enums;
using System;

namespace BaseProj.Api.Treatments
{
    public class Response
    {
        protected Response(int status = 0) => Status = status;

        protected Response(object data) : this() => Data = data;

        protected Response(string message) : this() => Message = message;

        protected Response(int status, object data) : this(status) => Data = data;

        protected Response(int status, string message) : this(status) => Message = message;

        protected Response(object data, string message) : this(data) => Message = message; 

        protected Response(int status, object data, string message) : this(status, data) => Message = message;

        public int Status;

        public object Data;

        public string Message;
    }

    public class Success : Response
    {
        public Success(Suc suc) : base((int)suc, suc.ToDescription()) { }

        public Success(object data) : base(data) { }

        public Success(string token) : base() => Token = token;

        public Success(Suc suc, object data) : base((int)suc, data, suc.ToDescription()) { }

        public Success(Suc suc, string token) : base((int)suc, suc.ToDescription()) => Token = token;

        public Success(object data, string token) : base(data) => Token = token;

        public Success(Suc suc, object data, string token) : base((int)suc, data, suc.ToDescription()) => Token = token;

        public string Token;
    }

    public class Error : Response
    {
        public Error(Err err) : base((int)err, err.ToDescription()) { }

        public Error(object data) : base((int)Err.InternalOperationError, data, Err.InternalOperationError.ToDescription()) { }

        public Error(Exception ex) : base(ex.HResult, ex.Message) => StackTrace = ex.StackTrace;

        public Error(Err err, object data) : base((int)err, data, err.ToDescription()) { }

        public Error(Err err, Exception ex) : base((int)err, ex, err.ToDescription()) => StackTrace = $"{ex.Message}: {ex.StackTrace}";

        public Error(Err err, object data, Exception ex) : base((int)err, data, err.ToDescription()) => StackTrace = $"{ex.Message}: {ex.StackTrace}";

        public string StackTrace { get; set; }
    }
}
