using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Atividade02.Core.Common.CQRS;

public abstract class Query : IRequest<List<View>>
{
    
}
