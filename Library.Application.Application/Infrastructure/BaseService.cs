using Library.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Application
{
    public abstract class BaseService
    {
        protected Task<ApplicationResult> Ok<T>(T data)
        {
            var result = new ApplicationResult
            {
                Data = data,
                Success = true
            };
            return Task.FromResult(result);
        }

        protected Task<ApplicationResult> Ok<T>(T data, IEnumerable<Error> errors)
        {
            var result = new ApplicationResult
            {
                Data = data,
                Errors = errors,
                Success = true
            };
            return Task.FromResult(result);
        }

        protected Task<ApplicationResult> Fail(params Error[] errorMessages)
        {
            var commandExecutionResult = new ApplicationResult
            {
                Success = false,
                Errors = errorMessages.ToList()
            };
            return Task.FromResult(commandExecutionResult);
        }

        protected Task<ApplicationResult> Fail<T>(T data, params Error[] errorMessages)
        {
            var commandExecutionResult = new ApplicationResult
            {
                Success = false,
                Data = data,
                Errors = errorMessages.ToList()
            };
            return Task.FromResult(commandExecutionResult);
        }
    }
}
