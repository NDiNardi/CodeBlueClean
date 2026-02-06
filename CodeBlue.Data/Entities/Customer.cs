namespace CodeBlue.Data.Entities;

public class Customer
{
	public Guid Id { get; set; }

	// -----------------------------
	// Knack export columns
	// -----------------------------

	// "Address" (Knack combined string)
	public string Address { get; set; } = "";

	// "Address : Street 1"
	public string Street1 { get; set; } = "";

	// "Address : Street 2"
	public string? Street2 { get; set; }

	// "Address : City"
	public string City { get; set; } = "";

	// "Address : State"
	public string State { get; set; } = "";

	// "Address : Zip"
	public string Zip { get; set; } = "";

	// "Address : Country"
	public string? Country { get; set; }

	// "Address : Latitude"
	public decimal? Latitude { get; set; }

	// "Address : Longitude"
	public decimal? Longitude { get; set; }

	// "Startup Date"
	public DateOnly? StartupDate { get; set; }

	// "Status"
	public string? Status { get; set; }

	// "Contact Name"
	public string? ContactName { get; set; }

	// "Record ID" (Knack record id)
	public string? LegacyRecordId { get; set; }

	// "Contact Phone"
	public string? ContactPhone { get; set; }

	// "Contact E-Mail"
	public string? ContactEmail { get; set; }

	// "Gate Codes"
	public string? GateCodes { get; set; }

	// "Animals Present"
	public bool AnimalsPresent { get; set; }

	// "Original Installer/Dealer"
	public string? OriginalInstallerDealer { get; set; }

	// "AddressKey"
	public string AddressKey { get; set; } = "";

	// -----------------------------
	// Navigation
	// -----------------------------
	public List<WorkOrder> WorkOrders { get; set; } = new();
	public List<WarrantyClaim> WarrantyClaims { get; set; } = new();
}
