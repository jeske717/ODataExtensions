using NUnit.Framework;

namespace Jesko.ODataExtensions.Tests
{
    [TestFixture]
    public class ODataExtensionsTests
    {
        [Test]
        public void Filter_Generates_OData_Filter_For_Equality()
        {
            var instance = new ClassWithProperties();

            var actual = instance.Filter(x => x.StringProperty == "value");

            Assert.AreEqual("$filter(StringProperty eq 'value')", actual.ToString());
        }
    }

    class ClassWithProperties
    {
        public string StringProperty { get; set; }
        public int IntegerProperty { get; set; }
    }
}