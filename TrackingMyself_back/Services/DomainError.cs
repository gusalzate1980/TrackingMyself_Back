using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class DomainError
    {
        public List<string> ErrorDetail { get; set; }
        public string ObjectName { get; set; }
        public string MethodName { get; set; }

        public DomainError() 
        {
            ErrorDetail = new List<string>();
        }
    }
}
