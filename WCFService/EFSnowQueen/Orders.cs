namespace WCFService.EFSnowQueen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public int id { get; set; }

        public int id_product { get; set; }

        [Column(TypeName = "money")]
        public decimal? priceOfProduct { get; set; }

        public int? countOfProduct { get; set; }

        public virtual Products Products { get; set; }
    }
}
