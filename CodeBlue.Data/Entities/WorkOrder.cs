namespace CodeBlue.Data.Entities;

public class WorkOrder
{
	public Guid Id { get; set; }

	// -----------------------------
	// Knack export columns
	// -----------------------------

	// Builder-Contact (Knack person field exploded)
	public string? BuilderContact { get; set; }
	public string? BuilderContactTitle { get; set; }
	public string? BuilderContactFirst { get; set; }
	public string? BuilderContactMiddle { get; set; }
	public string? BuilderContactLast { get; set; }

	// "Record ID"
	public string? LegacyRecordId { get; set; }

	// ServiceAddress (Knack address field)
	public string ServiceAddress { get; set; } = "";
	public string ServiceStreet1 { get; set; } = "";
	public string? ServiceStreet2 { get; set; }
	public string ServiceCity { get; set; } = "";
	public string ServiceState { get; set; } = "";
	public string ServiceZip { get; set; } = "";
	public string? ServiceCountry { get; set; }
	public decimal? ServiceLatitude { get; set; }
	public decimal? ServiceLongitude { get; set; }

	// "Gate Code"
	public string? GateCode { get; set; }

	// "Animals Present"
	public bool AnimalsPresent { get; set; }

	// "ServiceStartupDate"
	public DateOnly? ServiceStartupDate { get; set; }

	// "ServiceDetails"
	public string? ServiceDetails { get; set; }

	// ServiceContact (Knack person field exploded)
	public string? ServiceContact { get; set; }
	public string? ServiceContactTitle { get; set; }
	public string? ServiceContactFirst { get; set; }
	public string? ServiceContactMiddle { get; set; }
	public string? ServiceContactLast { get; set; }

	// "ServicePhone"
	public string? ServicePhone { get; set; }

	// Builder fields
	public string? BuilderCompanyName { get; set; }
	public string? BuilderPhoneNumber { get; set; }
	public string? BuilderEmail { get; set; }

	// "Scheduled Service Date"
	public DateOnly? ScheduledServiceDate { get; set; }

	// "AddressKey"
	public string AddressKey { get; set; } = "";

	// "Assigned To"
	public string? AssignedTo { get; set; }

	// "Status"
	public string? Status { get; set; }

	// "Space"
	public string? Space { get; set; }

	// "PreKey"
	public string? PreKey { get; set; }

	// "Completed By"
	public string? CompletedBy { get; set; }

	// -----------------------------
	// Linkage
	// -----------------------------
	public Guid? CustomerId { get; set; }
	public Customer? Customer { get; set; }

	// One WorkOrder -> Many Claims
	public List<WarrantyClaim> WarrantyClaims { get; set; } = new();
}
