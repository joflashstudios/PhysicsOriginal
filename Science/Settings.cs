using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Science
{
    internal class Settings
    {
        public GeneralSettings General { get; set; }
        public VectorSettings Vector { get; set; }
        
        internal struct GeneralSettings
        {
            bool AchievementsOn { get; set; }
            bool AchievementsHide { get; set; }

            int Precision { get; set; }
        }

        internal struct VectorSettings
        {
            int OutputWidth { get; set; }
            int OutputHeight { get; set; }

            bool ThickenHighrez { get; set; }
        }
    }
}
