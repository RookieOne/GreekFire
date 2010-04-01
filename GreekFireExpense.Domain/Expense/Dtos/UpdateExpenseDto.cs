using System;

namespace GreekFire.Domain
{
    [Serializable]
    public class UpdateExpenseDto
    {
        public bool IsNew { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}