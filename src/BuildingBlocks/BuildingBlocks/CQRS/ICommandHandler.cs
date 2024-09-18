﻿using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
    }
    public interface ICommandHandler<in TCommand, TReponse> : IRequestHandler<TCommand, TReponse>
        where TCommand : ICommand<TReponse>
        where TReponse : notnull
    {
    }
}
