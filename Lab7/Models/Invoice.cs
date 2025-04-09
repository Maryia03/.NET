using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }
		[Display(Name = "Invoice Id")]
		public long InvoiceId { get; set; }
		[Display(Name = "Customer Id")]
		public long CustomerId { get; set; }
        [DataType(DataType.DateTime)]
        [UIHint("InvoiceDate")]
		[Display(Name = "Invoice Date")]
		public DateTime InvoiceDate { get; set; }
        [Display(Name = "Billing Address")]
		public string? BillingAddress { get; set; }
		[Display(Name = "Billing City")]
		public string? BillingCity { get; set; }
		[Display(Name = "Billing State")]
		public string? BillingState { get; set; }
		[Display(Name = "Billing Country")]
		public string? BillingCountry { get; set; }
		[Display(Name = "Billing Postal Code")]
		public string? BillingPostalCode { get; set; }
        [DataType(DataType.Currency)]
		[Display(Name = "Total")]
		public decimal Total { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
