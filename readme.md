# DAPR Service Invocation

The repo uses dapr for service discovery and tests calling one service from another. It consists of 2 .NET 6 minimal APIs, Outer and Inner.  The Outer API calls the Inner API, passing a parameter using only the Dapr AppId of the Inner API.

To run this example, DAPR needs to be installed locally.  The inner API can be started with the following command..

```
dapr run --app-id inner --app-port 7147 --dapr-http-port 3602 --dapr-grpc-port 60002 --app-ssl dotnet run
```

and similarly for the outer API..

```
dapr run --app-id outer --app-port 7189 --dapr-http-port 3601 --dapr-grpc-port 60001 --app-ssl dotnet run
```

NOTE: you might need to vary the app-port parameters to reflect the default port used by your application.