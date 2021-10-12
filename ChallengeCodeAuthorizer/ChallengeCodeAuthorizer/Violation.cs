using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
   
    public class Violation
    {
        private Violation(string value) { Value = value; }

        public string Value { get; private set; }

        public static Violation InsufficientLimit { get { return new Violation("insufficient-limit"); } }
        public static Violation AccountAlreadyInitialized { get { return new Violation("account-already-initialized"); } }
        public static Violation Info { get { return new Violation("Info"); } }
        public static Violation Warning { get { return new Violation("Warning"); } }
        public static Violation Error { get { return new Violation("Error"); } }
    }
}
