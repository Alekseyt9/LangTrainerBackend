
using System.Diagnostics;

namespace LangTrainerEntity.Entities.Lang
{
    [DebuggerDisplay("{Name}")]
    public class Language
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
