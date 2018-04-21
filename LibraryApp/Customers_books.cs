namespace LibraryApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers_books
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Book_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Order_date { get; set; }

        public virtual Book Book { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
