using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hollow_knight_ACTS
{
    public class SaveStateLocal
    {
        public bool IsInAct1 { get; set; } = false;
        public bool IsInAct2 { get; set; } = false;
        public bool CanAccessAct3 { get; set; } = false;
        public bool IsInAct3 { get; set; } = false;
    }
}
