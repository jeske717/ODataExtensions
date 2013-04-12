OData Extensions
================

The goal of this project is to transform statically typed .NET expressions into an OData representation.  Only basic OData concepts are currently implemented.

Examples
--------

Here are some examples, but feel free to read the tests for more API usage:

### Filtering
	var person = new Person();
	var odata = person.Filter(p => p.FullName == "Jimi Hendrix");
	// odata.ToString() produces "$filter=(FullName eq 'Jimi Hendrix')"
	
### Ordering
	var person = new Person();
	var odata = person.OrderBy(p => p.LastName);
	// odata.ToString() produces "$orderby=(LastName asc)"
	
######In the above examples, the Person class would look something like this:
	public class Person : IODataCapable<Person> {
		public string FullName { get; set; }
		public string LastName { get; set; }
	}