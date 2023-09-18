namespace DesignPatterns.Mediator.Components;

public class ComponentBase
{
    protected IMediator Mediator;

    public void SetMediator(IMediator mediator)
    {
        Mediator = mediator;
    }
}