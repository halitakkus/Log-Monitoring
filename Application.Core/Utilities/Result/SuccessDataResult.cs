﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Result
{
    /// <summary>
    /// Success data result for successfully done method.
    /// </summary>
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(T data, string key, string message) : base(data, true, key, message)
        {

        }
    }
}
