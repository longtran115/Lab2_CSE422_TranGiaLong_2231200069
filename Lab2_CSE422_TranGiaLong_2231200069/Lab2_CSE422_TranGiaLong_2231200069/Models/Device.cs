namespace Lab2_CSE422_TranGiaLong_2231200069.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Code { get; set; } 
        public int CategoryId { get; set; } 
        public string Status { get; set; } 
        public DateTime DateOfEntry { get; set; } 
    }

}
