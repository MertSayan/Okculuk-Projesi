﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://locahost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "okculukUyGuLamasi0101++okculu*k--nbck";
        public const int Expire = 10; // 10 dk sonra token iptal olacak

    }
}
