namespace xCarpaccio.client
{
    class Bill
    {
        public Bill(decimal total)
        {
            this.total = total;
        }

        public decimal total { get; set; }
    }
}
