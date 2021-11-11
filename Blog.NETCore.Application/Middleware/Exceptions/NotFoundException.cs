using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Middleware.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
