using MediatR;

namespace WordApp.Application.Features.Words.Commands.UpdateWordToKnown;

public sealed record UpdateWordToKnownCommandRequest(Guid Id) : IRequest<UpdateWordToKnownCommandResponse>;
