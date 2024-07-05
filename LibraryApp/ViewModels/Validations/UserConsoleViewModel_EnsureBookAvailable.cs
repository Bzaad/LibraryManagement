using LibraryApp.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.ViewModels.Validations
{
    public class UserConsoleViewModel_EnsureBookAvailable : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var userConsoleViewModel = validationContext.ObjectInstance as UserConsoleViewModel;

            if (userConsoleViewModel != null)
            {
                var book = BookRepo.GetBookById(userConsoleViewModel.SelectedBookId);
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
