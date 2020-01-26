using FluentValidation;
using System.Collections.Generic;
using UpdatesApi.ViewModels;

namespace UpdatesApi.Validators
{
    public class ToDoItemVmValidator : AbstractValidator<ToDoItemVm>
    {
        private readonly List<string> _validStates = new List<string>
        {
            "To do",
            "Doing",
            "Done"
        };

        public ToDoItemVmValidator()
        {
            RuleFor(ctdivv => ctdivv.Title).NotEmpty().MaximumLength(100);
            RuleFor(ctdivv => ctdivv.State)
                .Must(state => _validStates.Contains(state))
                .WithMessage($"The to do items can only be in one of these states - {string.Join(", ", _validStates)}");
        }
    }
}
