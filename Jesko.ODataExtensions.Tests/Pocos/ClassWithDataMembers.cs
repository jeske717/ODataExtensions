using System.Runtime.Serialization;
using Jesko.ODataExtensions.Mixins;

namespace Jesko.ODataExtensions.Tests.Pocos
{
    [DataContract]
    public class ClassWithDataMembers : IODataCapable<ClassWithDataMembers>
    {
        [DataMember(Name = "FormattedProperty")]
        public string DataMemberProperty { get; set; }

        [DataMember]
        public string DefaultName { get; set; }
    }
}