using DesignPatterns.Mediator;
using DesignPatterns.Mediator.Components;

var loader = new Loader();
var personTypeSelector = new PersonTypeSelector();
var registerButton = new RegisterButton();
var validationErrorMessage = new NotificationBox();
var physicalForm = new PhysicalPersonRegisterForm();
var juryForm = new JuryPersonRegisterForm();

var mediator = new RegisterDialog(
    physicalForm,
    juryForm,
    loader,
    validationErrorMessage,
    new ApiService(isHealthy: true));

personTypeSelector.SetMediator(mediator);
registerButton.SetMediator(mediator);
physicalForm.SetMediator(mediator);
juryForm.SetMediator(mediator);
    
personTypeSelector.SelectJuryPerson();
registerButton.Click();;