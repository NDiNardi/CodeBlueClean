namespace CodeBlue.Data.Entities;

public class Customer
{
	public Guid Id { get; set; }
	public string Address { get; set; } = "";
	public string GateCode { get; set; } = "";
	public bool AnimalsPresent { get; set; }
	public string ContactName { get; set; } = "";
	public string ContactPhone { get; set; } = "";
}
