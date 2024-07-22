using AutoMapper;
using Microsoft.Extensions.Logging;

namespace RB.TBC.FinalProject.Application.Services
{
    public abstract class AbstractService<T>(IMapper map, ILogger<T> log)
        where T : class
    {
        protected readonly IMapper mapper = map;
        protected readonly ILogger<T> logger = log;
    }
}
