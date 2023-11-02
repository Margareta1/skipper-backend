using skipper_backend.Models.CV;

namespace skipper_backend.DTO
{
    public class GetCVWithItemsDto
    {
        public CV CV { get; set; }
        public List<CVItem> Items { get; set; }
    }
}
