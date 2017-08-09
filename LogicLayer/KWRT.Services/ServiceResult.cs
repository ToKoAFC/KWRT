using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KWRT.Services
{
    public class ServiceResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
    }
}