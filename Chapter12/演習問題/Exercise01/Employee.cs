﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Exercise01 {
    [XmlRoot("employee")]
    [DataContract]
    public class Employee {

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "hiredate")]
        [DataMember(Name = "hiredate")]
        public DateTime HireDate { get; set; }
    }
}
