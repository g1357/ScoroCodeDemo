using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class RegexOptions
    {
        [JsonProperty("options")]
        private string options;

        public RegexOptions()
        {
            options = "";
        }

        public void setRegexCaseInsenssitive()
        {
            addOption("i");
        }

        public void setMatchAnchorsOnEveryStringLine()
        {
            addOption("m");
        }

        public void setIgnoreWhitespacesInPattern()
        {
            addOption("x");
        }

        public void setAllowDotCharacterInPattern()
        {
            addOption("s");
        }

        private void addOption(string option)
        {
            if (!options.Contains(option))
            {
                options += option;
            }
        }

        public string getRegexOptions()
        {
            return options;
        }
    }
}