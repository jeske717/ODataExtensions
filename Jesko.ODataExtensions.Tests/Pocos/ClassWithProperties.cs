using Jesko.ODataExtensions.Mixins;

namespace Jesko.ODataExtensions.Tests.Pocos
{
    class ClassWithProperties : IODataCapable<ClassWithProperties>
    {
        public string Field;
        public string StringProperty { get; set; }
        public int IntegerProperty { get; set; }
    }
}