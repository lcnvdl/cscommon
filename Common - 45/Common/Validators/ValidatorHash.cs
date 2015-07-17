using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Validators
{
    public class ValidatorHash: IValidator
    {
        public string Hash { get; set; }

        public ValidatorHash(string hash)
        {
            Hash = hash;
        }

        public void Validate()
        {
            if (Regex.IsMatch(Hash, "[^a-fA-F0-9]+"))
            {
                throw new Exception("Invalid hash.");
            }
        }
    }
}
