using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hiro.Core.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Um ou mais erros de validação foram encotrados.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
