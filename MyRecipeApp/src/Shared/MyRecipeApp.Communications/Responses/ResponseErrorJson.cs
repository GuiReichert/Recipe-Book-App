﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeApp.Communications.Responses
{
    public class ResponseErrorJson
    {
        public IList<string> Errors { get; set; }

        public ResponseErrorJson(IList<string> errors)
        {
            Errors = errors;
        }

        public ResponseErrorJson(string error)
        {
            Errors = new List<string> { error };
        }
    }
}
