using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InMemory.Models.DbEntities {
    public class Customer {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }

    public class Invoice {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey ("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual List<InvoiceItem> Items { get; set; }
    }

    public class InvoiceItem {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public string Code { get; set; }

        [ForeignKey ("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
    }
}