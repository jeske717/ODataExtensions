using System.Runtime.Serialization;

namespace Jesko.ODataExtensions.Tests.Pocos
{
    [DataContract]
    public class ClassWithDataMembers
    {
        [DataMember(Name = "FormattedProperty")]
        public string DataMemberProperty { get; set; }
    }
}