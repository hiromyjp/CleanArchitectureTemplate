﻿namespace Hiro.Infrastructure.Identity
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Hours { get; set; }
        public string Key { get; set; }
    }
}
