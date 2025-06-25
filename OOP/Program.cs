using BethanysPieShopHRM.HR;

Employee bethany = new("Bethany", "Harold", "bharold@shralpersunion.org", new DateTime(1993, 12, 08), 45);
Employee george = new("George", "Flannigan", "gflannigan@shralpersunion.org", new DateTime(1987, 5, 18));

Employee jake = new Employee("Jake", "Chambers", "oy@shralpersunion.org", new DateTime(1966, 5, 19), 190, "40 Irving Pl 2nd Floor", "1900", "New York", "New York", "10003");

bethany.DisplayEmployeeDetails();

Console.WriteLine(bethany.HourlyRate);
Console.WriteLine(bethany.Birthday);
Console.WriteLine(george.Birthday);
Console.WriteLine(jake.Address.Street);
