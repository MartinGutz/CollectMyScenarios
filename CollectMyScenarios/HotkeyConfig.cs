using System;
using System.Collections.Generic;
using System.Text;

namespace CollectMyScenarios
{
    internal class HotkeyConfig
    {
        public string Modifier { get; set; } = "CONTROL"; // e.g., CONTROL, ALT, SHIFT
        public string Key { get; set; } = "M";            // e.g., M, S, F12
    }
}
