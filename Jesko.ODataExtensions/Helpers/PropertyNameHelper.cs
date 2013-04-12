using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Jesko.ODataExtensions.Helpers
{
    public static class PropertyNameHelper
    {
         public static string PropertyName(MemberInfo memberInfo)
         {
             var dataMemberAttribute = memberInfo.GetCustomAttributes(typeof(DataMemberAttribute), false);
             if (dataMemberAttribute.Any())
             {
                 var dataMemberName = (dataMemberAttribute.First() as DataMemberAttribute).Name;
                 return string.IsNullOrEmpty(dataMemberName) ? memberInfo.Name : dataMemberName;
             }
             return memberInfo.Name;
         }
    }
}