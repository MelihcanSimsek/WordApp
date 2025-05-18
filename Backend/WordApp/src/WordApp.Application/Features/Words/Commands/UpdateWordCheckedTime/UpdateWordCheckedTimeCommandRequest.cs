using MediatR;

namespace WordApp.Application.Features.Words.Commands.UpdateWordCheckedTime;

public sealed record UpdateWordCheckedTimeCommandRequest(Guid Id) 
    : IRequest<UpdateWordCheckedTimeCommandResponse>;
