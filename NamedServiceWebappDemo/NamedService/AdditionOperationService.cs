﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamedServiceWebappDemo.NamedService
{
    public class AdditionOperationService : IOperationService
    {
        public object DoOperation(double x, double y)
        {
            return x + y;
        }
    }
}
