﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.RoadReady.Domain.Abstractions
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }


        protected internal Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None) { throw new InvalidOperationException(); }

            if (!isSuccess && error == Error.None) { throw new InvalidOperationException(); }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

        public static Result<TValue> Success<TValue>(TValue value)
            => new(value, true, Error.None);

        public static Result<TValue> Failure<TValue>(Error error)
            => new(default, false, error);

        public static Result<TValue> Create<TValue>(TValue value)
            => value is not null
            ? Success(value)
            : Failure<TValue>(Error.NullValue);


    }


    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        [NotNull]
        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("Error value result is not admited");

        public static implicit operator Result<TValue>(TValue value) => Create(value);
    }
}