using System.Collections.Generic;
using System.Xml.Serialization;

namespace FabricAPP.XMLObjects
{
    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        [XmlElement(ElementName = "City")]
        public string City { get; set; }

        [XmlElement(ElementName = "Street")]
        public string Street { get; set; }

        [XmlElement(ElementName = "StreetNr")]
        public string StreetNr { get; set; }

        [XmlElement(ElementName = "HouseNr")]
        public string HouseNr { get; set; }

        [XmlElement(ElementName = "Zip")]
        public int Zip { get; set; }
    }

    [XmlRoot(ElementName = "Employee")]
    public class Employee
    {

        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "ContactNo")]
        public int ContactNo { get; set; }

        [XmlElement(ElementName = "Email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
    }

    [XmlRoot(ElementName = "Employees")]
    public class Employees
    {

        [XmlElement(ElementName = "Employee")]
        public List<Employee> Employee { get; set; }
    }


}
