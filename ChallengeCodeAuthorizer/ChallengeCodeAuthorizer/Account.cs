﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCodeAuthorizer
{
    public class Account
    {

        public bool activecard { get; set; }
        public int availablelimit { get; set; }
        public ResponseAccount getResponseAccount()
        {
            return new ResponseAccount(this);
        }
    }
}
