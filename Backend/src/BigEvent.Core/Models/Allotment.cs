using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigEvent.Core.Models
{
    [Table("allotments")]
    public class Allotment
    {

        [Column("id_allotment")]
        public int Id { get; set; }

        [Column("num_allotment")]
        public string Name { get; set; }

        [Column("price_allotment")]
        public decimal Price { get; set; }

        [Column("limit_guest")]
        public int LimitGuests { get; set; }

        [Column("initial_date")]
        public DateTime? InitialDate { get; set; }

        [Column("finish_date")]
        public DateTime? FinishDate { get; set; }
        

        // Foreign Key
        [Column("event_id")]
        public int EventId { get; set; }
        public Event Event { get; set; }

    }
}