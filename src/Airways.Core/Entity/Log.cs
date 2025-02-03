using Airways.Core.Common;
using Microsoft.Extensions.Logging;

namespace Airways.Core.Entity
{
    public class Log 
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedOn { get ; set; } = DateTime.UtcNow;
    }
}
