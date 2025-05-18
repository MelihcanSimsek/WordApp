using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WordApp.Application.Exceptions;

public sealed class BusinessProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}