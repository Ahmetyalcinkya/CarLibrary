using Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(review => review.CustomerName).NotEmpty().WithMessage("Please enter a customer name!");
            RuleFor(review => review.CustomerName).MinimumLength(5).WithMessage("Customer name must be bigger than 5 characters!");
            RuleFor(review => review.Rating).NotEmpty().WithMessage("Rating value cannot be empty!");
            RuleFor(review => review.Comment).NotEmpty().WithMessage("Comment cannot be empty!");
            RuleFor(review => review.Comment).MinimumLength(50).WithMessage("Comment length cannot smaller than 50!");
            RuleFor(review => review.Comment).MaximumLength(500).WithMessage("Comment length cannot bigger than 500!");
            RuleFor(review => review.CustomerImage).NotEmpty().WithMessage("Customer image cannot be empty!").MinimumLength(10).WithMessage("Please enter a data with minimum 10 characters!").MaximumLength(1000).WithMessage("Please enter a data with maximum 1000 characters!");
        }
    }
}
