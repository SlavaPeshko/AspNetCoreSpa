using System;
using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Entities.Base
{
    public static class ResultExtensions
    {
        public static T ToValue<T>(this Result result, Func<T> success, Func<IList<Error>, T> failure)
        {
            if (result.IsSucceed)
                return success();
            return failure(result.Errors);
        }
    }
}
