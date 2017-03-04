using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Services.ConfigService
{
    public enum LoadResult
    {
        None,
        Success,
        FileNotFound,
        ParseError,
        IncorrectStructure
    }
}