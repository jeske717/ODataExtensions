using System.Runtime.Serialization;

namespace Jesko.ODataExtensions.Tests.Pocos
{
    [DataContract]
    public class ClassWithDataMembers
    {
        [DataMember(Name = "FormattedProperty")]
        public string DataMemberProperty { get; set; }

        [DataMember]
        public string DefaultName { get; set; }
    }
}