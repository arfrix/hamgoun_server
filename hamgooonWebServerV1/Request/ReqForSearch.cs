using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hamgooonWebServerV1.Request
{
    public class ReqForSearch
    {
        public string KeyWord { get; set; }
        // for global content search should assign -1 to MainCat
        public int MainCat { get; set; }

        // for global user search should assign -1 to bio
        public int Bio { get; set; }
    }
}
