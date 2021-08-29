using StringMatcher.Interfaces;
using StringMatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static StringMatcher.Helpers.EnumHelper;

namespace StringMatcher.Providers
{
    public class StringComparisonProvider : ICompare
    {
        private string _inputString = string.Empty;
        private string _subString = string.Empty;        
        private RegexOptions _matchCase = RegexOptions.IgnoreCase;

        public StringComparisonProvider(string inputString, string subString, CaseSearch matchCase)
        {
            _inputString = inputString.Trim();
            _subString = subString.Trim();
            
            if (matchCase == CaseSearch.MatchCase)
            {
                _matchCase = RegexOptions.None;
            }
        }

        public Compare findWords()
        {
            Compare compare = new Compare();
            compare.InputString = _inputString;
            compare.SubString = _subString;

            string pattern = _subString; //@"\b" + _subString + @"\w*\b";
            var reg = new Regex(pattern, _matchCase);
            Match match = reg.Match(_inputString);
            compare.MatchedWords = new List<MatchedWord>();
            while (match.Success)
            {
                MatchedWord matchedWord = new MatchedWord();
                matchedWord.startIndex = match.Index;
                matchedWord.finishIndex = matchedWord.startIndex + match.Length;
                compare.MatchedWords.Add(matchedWord);

                match = match.NextMatch();
            }

            return compare;

        }

    }
}
