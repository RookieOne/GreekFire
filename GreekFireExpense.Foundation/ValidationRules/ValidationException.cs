﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreekFire.Foundation.ValidationRules
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
