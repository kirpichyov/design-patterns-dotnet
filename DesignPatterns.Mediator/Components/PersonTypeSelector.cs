namespace DesignPatterns.Mediator.Components;

public class PersonTypeSelector : ComponentBase
{
    public void SelectPhysicalPerson()
    {
        Mediator.Notify(this, EventType.ValueChanged, "physical");
    }
    
    public void SelectJuryPerson()
    {
        Mediator.Notify(this, EventType.ValueChanged, "jury");
    }
}