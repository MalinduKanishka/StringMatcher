using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StringMatcher.Helpers.EnumHelper;

namespace StringMatcher.Models
{
    public class Compare
    {
        public string InputString { get; set; }
        public string SubString { get; set; }
        public List<MatchedWord> MatchedWords { get; set; }

        public CaseSearch CaseSearch {get; set;}
    }
}
