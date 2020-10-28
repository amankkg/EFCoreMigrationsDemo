using System;
using System.Collections.Generic;

namespace EFCoreReverseEngineering
{
    public partial class Residents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Activity { get; set; }
        public DateTime Entered { get; set; }
    }
}
