﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZavrsniRDMA
{
    public interface AuthHelper
    {
        Task<String> LoginWithEmailAndPassword(string email, string password);
        Task<String> SignUpWithEmailAndPassword(string email, string password);

        bool SignOut();
        bool IsSignIn();
    }
}
