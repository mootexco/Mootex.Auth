namespace Mootex.Auth.UseCases;

public abstract class UseCase<TInput, TOutput>
{
    public abstract TOutput Execute(TInput input);
}

public abstract class UseCase<TOutput>
{
    public abstract TOutput Execute();
}

public abstract class AsyncUseCase<TInput, TOutput>
{
    public abstract Task<TOutput> Execute(TInput input);
}

public abstract class AsyncUseCase<TOutput>
{
    public abstract Task<TOutput> Execute();
}