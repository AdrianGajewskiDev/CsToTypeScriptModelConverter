using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Core.Values
{
    public interface IClassMember
    {
         string Type { get; set; }
         string Value { get; set; }
    }
}
