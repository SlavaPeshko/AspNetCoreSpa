﻿using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreSpa.Domain.Entities.Base
{
    public class Result
    {
        public Result()
        {
            Errors = new List<Error>();
        }

        public IList<Error> Errors { get; set; }

        public bool IsFailure => Errors.Any();

        public bool IsSucceed => !Errors.Any();

        public static Result<T> OK<T>(T data)
        {
            return new Result<T>
            {
                Data = data
            };
        }

        public static Result Ok()
        {
            return new Result();
        }

        public static Result<T> Fail<T>(ErrorCode code, string description)
        {
            return new Result<T>
            {
                Errors =
                {
                    new Error
                    {
                        Code = code,
                        Description = description
                    }
                }
            };
        }

        public static Result Fail(ErrorCode code, string description)
        {
            return new Result
            {
                Errors =
                {
                    new Error
                    {
                        Code = code,
                        Description = description
                    }
                }
            };
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}