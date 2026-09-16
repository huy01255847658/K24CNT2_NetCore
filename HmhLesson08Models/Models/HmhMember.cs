using System.ComponentModel;

namespace HmhLesson08Models.Models
{
    public class HmhMember
    {
        public string HmhMemberId { get; set; }
        public string HmhUserName { get; set; }
        public string HmhPassword { get; set; }

        [DisplayName("Họ và tên")]
        public string HmhFullName { get; set; }
        public string HmhEmail { get; set; }
    }
}
