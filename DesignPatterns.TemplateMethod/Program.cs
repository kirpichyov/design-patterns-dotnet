// See https://aka.ms/new-console-template for more information

using Bogus;
using DesignPatterns.Common.Contracts;
using DesignPatterns.TemplateMethod;
using DesignPatterns.TemplateMethod.ConcreteHandlers;
using FakeItEasy;

var command = new SendNotificationCommand(Guid.NewGuid(), Guid.NewGuid());

#region SetupDemo

var faker = new Faker();

var userRepository = new Fake<IUserRepository>();
var eventsRepository = new Fake<IEventsRepository>();

userRepository.CallsTo(x => x.GetUserNotificationServices(command.UserId))
    .Returns(new UserNotificationServices(faker.Person.Phone, faker.Person.Email,
        new[] { Guid.NewGuid(), Guid.NewGuid() }));

#endregion SetupDemo

var emailHandler = new EmailHandler(userRepository.FakedObject, eventsRepository.FakedObject);
var smsHandler = new SmsHandler(userRepository.FakedObject, eventsRepository.FakedObject);
var pushHandler = new PushHandler(userRepository.FakedObject, eventsRepository.FakedObject);

SendNotificationCommandHandlerBase[] handlers = { emailHandler, smsHandler, pushHandler };

foreach (var handler in handlers)
{
    handler.Process(command);
}