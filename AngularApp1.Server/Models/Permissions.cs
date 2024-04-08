namespace Online_Buy_Plus
{
    public class Permissions
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public bool ProductsPanel { get; set; } = false;
        public bool DeleteProduct { get; set; } = false;
        public bool BranchPanel { get; set; } = false;
        public bool CategoryPanel { get; set; } = false;
        public bool FwaterPanel { get; set; } = false;
        public bool DeleteFatora { get; set; } = false;
        public bool UserPanel { get; set; } = false;
        public bool DeleteUser { get; set; } = false;
        public bool BillPanel { get; set; } = false;
        public bool StoragePanel { get; set; } = false;
        public bool SuppliersPanel { get; set; } = false;
        public bool CustomersPanel { get; set; } = false;
        public bool SitePanel { get; set; } = false;
        public bool CommunityWorld { get; set; } = true;
        public bool ReservationPanel { get; set; } = false;
    }
}