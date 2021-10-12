using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    internal class Transaction
    {
        public string merchant { get; set; }
        public int amount { get; set; }
        public DateTime time { get; set; }
    }

}
