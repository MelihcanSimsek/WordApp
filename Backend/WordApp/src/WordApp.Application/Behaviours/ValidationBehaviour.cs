﻿using FluentValidation;
using MediatR;

namespace WordApp.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> validator;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
    {
        this.validator = validator;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = validator.Select(p => p.Validate(context))
            .SelectMany(c => c.Errors).Where(failure => failure != null)
            .ToList();

        if (failures.Any()) throw new ValidationException(failures);

        return next();
    }
}
