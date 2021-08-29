using StringMatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StringMatcher.Helpers.EnumHelper;

namespace StringMatcher.Interfaces
{
    public interface ICompare
    {
        Compare findWords();
    }
}
