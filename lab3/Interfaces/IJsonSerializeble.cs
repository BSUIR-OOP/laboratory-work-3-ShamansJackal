﻿using lab3.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Interfaces
{
    public interface IJsonSerializeble
    {
        object FromJson(JsonToken json);
        string ToJson();
        string ClassName();
    }
}