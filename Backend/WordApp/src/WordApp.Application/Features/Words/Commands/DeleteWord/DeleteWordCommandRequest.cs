using MediatR;

namespace WordApp.Application.Features.Words.Commands.DeleteWord;

public sealed record DeleteWordCommandRequest(Guid Id) : IRequest<DeleteWordCommandResponse>;
