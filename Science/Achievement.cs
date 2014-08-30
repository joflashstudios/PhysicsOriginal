using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Science
{
    public class Achievement
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public object Metadata { get; set; }
        public bool Unlocked { get; set; }
        public int Progress { get; set; }
        public int ProgressIncrement { get; set; }
        public int UnlockProgress { get; set; }


        public string ResourceName { get; set; }

        public static void AddProgress(string Title, int Amount)
        {
            foreach (Achievement A in Acheivements)
            {
                if (A.Title == Title)
                {
                    AddProgress(A, Amount);
                }
            }
        }

        public static void AddProgress(Achievement ToProgress, int Amount)
        {
            if (!ToProgress.Unlocked)
            {
                if (ToProgress.Progress + Amount >= ToProgress.UnlockProgress)
                {
                    Trigger(ToProgress);
                }
                else
                {
                    if (ToProgress.Progress % ToProgress.ProgressIncrement != (ToProgress.Progress + Amount) % ToProgress.ProgressIncrement)
                    {
                        ProgressDisplay(ToProgress);
                    }
                }
                ToProgress.Progress += Amount;
            }
        }

        public static void ProgressDisplay(Achievement ToProgress)
        {
        }

        public static void Trigger(string Title)
        {
            foreach (Achievement A in Acheivements)
            {
                if (A.Title == Title)
                {
                    Trigger(A);
                }
            }
        }

        public static void Trigger(Achievement ToTrigger)
        {
            if (!ToTrigger.Unlocked)
            {
                F.DisplayAchievement(ToTrigger);
                ToTrigger.Unlocked = true;
            }
            
        }

        internal static ProgramForm F;
        private static XmlSerializer X = new XmlSerializer(typeof(List<Achievement>));

        public static void Save()
        {
            StringWriter W = new StringWriter();
            X.Serialize(W, Acheivements);
            Properties.Settings.Default.Achievements = W.GetStringBuilder().ToString();
            Properties.Settings.Default.Save();
        }

        public static void Clear()
        {
            Acheivements.Clear();
            _Acheivements.Clear();
            StringWriter W = new StringWriter();
            X.Serialize(W, _Acheivements);
            Properties.Settings.Default.Achievements = W.GetStringBuilder().ToString();
            Properties.Settings.Default.Save();
        }
        
        public static List<Achievement> Acheivements
        {
            get
            {
                if (_Acheivements == null || _Acheivements.Count == 0)
                {
                    if (string.IsNullOrEmpty(Properties.Settings.Default.Achievements))
                    {
                        _Acheivements = ConstructAcheivements();
                        return _Acheivements;
                    }
                    else
                    {
                        _Acheivements = (List<Achievement>)X.Deserialize(new StringReader(Properties.Settings.Default.Achievements));
                        if (_Acheivements.Count == 0)
                            _Acheivements = ConstructAcheivements();
                        return _Acheivements;
                    }
                }
                else
                {
                    return _Acheivements;
                }
            }
        }

        private static List<Achievement> _Acheivements;

        private static List<Achievement> ConstructAcheivements()
        {
            List<Achievement> tmp = new List<Achievement>() {
                new Achievement() {Title = "That's Not Right!", Subtitle = "Make an impossible right-triangle"},
                new Achievement() {Title = "Trash Collector", Subtitle = "Enter a garbage value into a form"},
                new Achievement() {Title = "That's no moon!", Subtitle = "And that's no valid vector angle either."},
                new Achievement() {Title = "Vector Virtuoso", Subtitle = "Use 8 vectors at once. I'm out of colors!"}
            };
            return tmp;
        }
    }
}
