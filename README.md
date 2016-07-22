# NancyFileUpload #

This project shows how to implement file uploads with [Nancy], which is "... a lightweight, low-ceremony, framework for building HTTP based services on .Net and Mono".

I have used this project to experiment with Validation, Model Binding, Error Handling and Unit Tests with [Nancy]. So the project also shows how to bind complex 
incoming requests, validate them with FluentValidation, how to provide a custom error handling pipeline and how to implement full unit tests for Nancy modules.

## Uploading a File with curl ##

```
curl --verbose --form title="File Title" --form description="File Description" --form tags="Tag1,Tag2" --form file=@"C:\Users\philipp\image.png" http://localhost:1234/file/upload
```

[Nancy]: https://github.com/NancyFx/Nancy

## Disclaimer ##
This is an updated fork of the Philipp Wagner's excellent file upload example (https://github.com/bytefish/NancyFileUpload) to reflect the latest updates in both Nancy and .NET world.

This code serves only as an example and in *no way* is production ready.
