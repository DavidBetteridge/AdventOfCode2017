using System;
using System.Linq;

namespace Solutions
{
    public class Day4
    {
        public bool CheckPassPhrase(string input)
        {
            var words = input.Split(new char[] { ' ' });
            return (words.Length == words.Distinct().Count());
        }

        public int CountValidPassPhrases(string input)
        {
            return input.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None)
                        .Where(CheckPassPhrase)
                        .Count();
        }

        public bool CheckPassPhraseWithExtraRules(string input)
        {
            var words = input
                            .Split(new char[] { ' ' })
                            .Select(a => new string(a.OrderBy(w => w).ToArray()));
            return (words.Count() == words.Distinct().Count());
        }

        public int CountValidPassPhrasesWithExtraRules(string input)
        {
            return input.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.None)
                        .Where(CheckPassPhraseWithExtraRules)
                        .Count();
        }
    }
}
