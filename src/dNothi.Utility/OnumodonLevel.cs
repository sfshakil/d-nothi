using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
  public class OnumodonLevel
    {
        public int id { get; set; }

        public string Text { get; set; }

        public OnumodonLevel(int level)
        {
            this.Text = "লেভেল " + string.Concat(level.ToString().Select(c => (char)('\u09E6' + c - '0')));
            this.id = level;
        }

        public OnumodonLevel(int level, string levelText)
        {
            this.Text = levelText;
            this.id = level;
        }

    }
}
