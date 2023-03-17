using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.CI
{
    public  class Response<T> 
    {
        public bool Result { get; set; }
        public List<T> Entities { get; set; }
        public List<string> Messages { get; set; }

        public Response()
        {
            Entities = new List<T>();
            Messages = new List<string>();
        }
    }
}
