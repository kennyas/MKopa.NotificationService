# MKopa.NotificationService

### The microservice serves as an sms wrapper service, listening to a published event via RabbitMq, then sending the message to the sms providers using a strategy pattern to determine which sms provider to use based on the phone number country code configuration.

### This service gets the work done but it could be better refactored by creating a data store to save already sent sms, then the service checks the database for the client request id of the message event picked in order to ensure no duplicate messages are being sent. This could not be implemented due to the time alloted to this task.d optimise server resources usage.

## This project is built with C# programming language, on a .NET 6 Framework

## Design Pattern: Strategy

### The following packages should be updated.

```
<PackageReference Include="MassTransit.RabbitMQ" Version="8.1.1" />
<PackageReference Include="Microsoft.Extensions.Http" Version="6.0.0" />
<PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="6.0.1" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstraction" Version="7.0.0" />
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
```
### In order to run this code successfully, Kindly run a dotnet restore on this solution.

