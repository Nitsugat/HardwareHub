﻿

namespace HardwareHub.core.Entities
{
    public class Sale
    {

      
        public int SaleId { get; set; }
        public int ClientId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public Client? Client { get; set; }





    }
}
