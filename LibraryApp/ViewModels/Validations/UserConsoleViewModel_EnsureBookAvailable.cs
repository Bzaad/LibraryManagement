using System.ComponentModel.DataAnnotations;
using UseCases.Interfaces;

namespace LibraryApp.ViewModels.Validations
{
    public class UserConsoleViewModel_EnsureBookAvailable : ValidationAttribute
    {
        private readonly IGetSingleBookUseCase _getSingleBookUseCase;

        public UserConsoleViewModel_EnsureBookAvailable(IGetSingleBookUseCase getSingleBookUseCase)
        {
            _getSingleBookUseCase = getSingleBookUseCase;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var userConsoleViewModel = validationContext.ObjectInstance as UserConsoleViewModel;

            if (userConsoleViewModel != null)
            {
                var book = _getSingleBookUseCase.Execute(userConsoleViewModel.SelectedBookId);
                if (book != null) 
                {
                    if (book.AvailableCopies <= 0) 
                    {
                        return new ValidationResult($"{book.Name} is not available to borrow.");
                    }
                }
                else
                {
                    return new ValidationResult($"The selected book does not exist.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
