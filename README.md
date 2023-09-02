# API Exceptions

This is a small library containing a couple of Exception Types useful in creating Web APIs.

## Installation

With dotnet cli

    dotnet add package ApiExceptions
----
Or with nuget package manager console
    
    Install-Package ApiExceptions

## Guide

Here is a list of the exceptions in this library

- `ApiRequestException` : System.Net.Http.HttpRequestException `(: means base class)`
- `EntityNotFoundExcetption` : ApiRequestException
- `EntityAlreadyExistsException` : ApiRequestException
- `BadReqeuestException` : ApiRequestException
- `ForbiddenAccessException` : ApiRequestException
- `UnAuthorizedAccessException` : ApiRequestException

There is also an extension method for throwing `EntityNotFoundExcetption` when the entity is null:

```
User user = await GetUserAsync(userId);
user.ThrowEntityNotFoundIfNull(userId);
```