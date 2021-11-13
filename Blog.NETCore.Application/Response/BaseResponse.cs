﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }
        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

    }
}
