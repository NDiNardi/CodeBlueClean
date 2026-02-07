namespace CodeBlue.Data.Entities;

public class WarrantyClaim
{
	public Guid Id { get; set; }

	// -----------------------------
	// Knack export columns
	// -----------------------------

	// "Claim Number" (e.g. W1372108)
	public string ClaimNumber { get; set; } = "";

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

	// "Record ID" (Knack record id)
	public string? LegacyRecordId { get; set; }

	// "Original Installer/Dealer"
	public string? OriginalInstallerDealer { get; set; }

	// "Original Installation Date"
	public DateOnly? OriginalInstallationDate { get; set; }

	// "Component Code"
	public string? ComponentCode { get; set; }

	// "ID/Serial #"
	public string? IdSerialNumber { get; set; }

	// "Component Serial #"
	public string? ComponentSerialNumber { get; set; }

	// "AddressKey"
	public string AddressKey { get; set; } = "";

	// "Service Request" (link field in Knack; store raw value for now)
	public string? ServiceRequest { get; set; }

	// "Image 1" / "Image 1 : URL"
	public string? Image1 { get; set; }
	public string? Image1Url { get; set; }

	// "Image 2" / "Image 2 : URL"
	public string? Image2 { get; set; }
	public string? Image2Url { get; set; }

	// "Completed By"
	public string? CompletedBy { get; set; }

	// "Model #"
	public string? ModelNumber { get; set; }

	// "Failure Date"
	public DateOnly? FailureDate { get; set; }

	// "Repair Date"
	public DateOnly? RepairDate { get; set; }

	// -----------------------------
	// Statuses (keep separate)
	// -----------------------------

	// Internal lifecycle status: New / Pending / Synced (or whatever you decide)
	public string? Status { get; set; }

	// Date the office clicked "Claim has been filed"
	public DateOnly? FiledOnDate { get; set; }

	// Status from Hayward website: Approved / NeedMoreInfo / Denied / etc
	public string? HaywardStatus { get; set; }

	// When your scraper last updated HaywardStatus / scraped fields
	public DateOnly? HaywardStatusUpdatedOn { get; set; }

	// -----------------------------
	// Linkage (both links you want)
	// -----------------------------
	public Guid? CustomerId { get; set; }
	public Customer? Customer { get; set; }

	public Guid? WorkOrderId { get; set; }
	public WorkOrder? WorkOrder { get; set; }
}
