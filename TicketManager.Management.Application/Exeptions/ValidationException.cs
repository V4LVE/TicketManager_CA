using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace TicketManager.Management.Application.Exeptions
{
    public class ValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            ValidationErrors = new();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
    }
}
