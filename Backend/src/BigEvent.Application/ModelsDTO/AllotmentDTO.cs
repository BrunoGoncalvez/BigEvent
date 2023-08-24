using System;

namespace BigEvent.Application.ModelsDTO
{
    public class AllotmentDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int LimitGuests { get; set; }

        public DateTime? InitialDate { get; set; }

        public DateTime? FinishDate { get; set; }


        // Foreign Key
        public int EventId { get; set; }
        public EventDTO Event { get; set; }

    }
}
