namespace Jesko.ODataExtensions
{
    public class OData
    {
        public string Type { get { return "filter"; }}

        public string PropertyName { get; set; }
        public string Method { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("${0}=({1} {2} '{3}')", Type, PropertyName, Method, Value);
        }
    }
}