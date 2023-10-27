using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddLineDto
    {
        public string LineManagerId { get; set; }

        public IList<string> Employees { get; set; }
    }
}
