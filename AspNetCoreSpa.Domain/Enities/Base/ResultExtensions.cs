using System;
using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Enities.Base
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
