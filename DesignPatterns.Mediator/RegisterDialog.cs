using System.Net;
using DesignPatterns.Mediator.Components;

namespace DesignPatterns.Mediator;

public class RegisterDialog : IMediator
{
    private readonly PhysicalPersonRegisterForm _physicalPersonForm;
    private readonly JuryPersonRegisterForm _juryPersonRegisterForm;
    private readonly Loader _loader;
    private readonly NotificationBox _notificationBox;
    private readonly ApiService _apiService;

    private Type activeForm;
    
    public RegisterDialog(
        PhysicalPersonRegisterForm physicalPersonForm,
        JuryPersonRegisterForm juryPersonRegisterForm,
        Loader loader,
        NotificationBox notificationBox,
        ApiService apiService)
    {
        _physicalPersonForm = physicalPersonForm;
        _juryPersonRegisterForm = juryPersonRegisterForm;
        _loader = loader;
        _notificationBox = notificationBox;
        _apiService = apiService;
    }

    public void Notify(object sender, EventType @event, object args)
    {
        if (sender is RegisterButton && @event is EventType.Click)
        {
            if (activeForm == typeof(PhysicalPersonRegisterForm))
            {
                _physicalPersonForm.Submit();
            }
            
            if (activeForm == typeof(JuryPersonRegisterForm))
            {
                _juryPersonRegisterForm.Submit();
            }
        }
        
        if (sender is PersonTypeSelector && @event is EventType.ValueChanged)
        {
            var selectedPersonType = (string)args;

            switch (selectedPersonType)
            {
                case "physical":
                    activeForm = typeof(PhysicalPersonRegisterForm);
                    _juryPersonRegisterForm.Hide();
                    _physicalPersonForm.Show();
                    break;
                case "jury":
                    activeForm = typeof(JuryPersonRegisterForm);
                    _physicalPersonForm.Hide();
                    _juryPersonRegisterForm.Show();
                    break;
            }
        }

        if (sender is PhysicalPersonRegisterForm or JuryPersonRegisterForm && @event is EventType.Submit)
        {
            var formInfo = ((bool IsValid, Dictionary<string, string> Data))args;

            if (formInfo.IsValid)
            {
                _notificationBox.Show("Form data is invalid!");
            }
            else
            {
                _loader.Run();
                var response = _apiService.SendRegisterRequest(formInfo.Data);

                if (response is HttpStatusCode.OK)
                {
                    _notificationBox.Show("Success! Redirect to other window.");
                }
                else
                {
                    _notificationBox.Show($"Error while making the request to API. {response}");
                }
                
                _loader.Stop();
            }
        }
    }
}