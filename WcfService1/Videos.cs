using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    [DataContract]
    public class Videos
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string tittle { get; set; }
        [DataMember]
        public string url { get; set; }
    }
}