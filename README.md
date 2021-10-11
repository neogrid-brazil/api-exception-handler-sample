# API Exception Handler Sample

This simple project aims to share how to handle exceptions in ASP.Net Core APIs using Middlewares. Although the simplicity, the solution has three projects to show you how to handle the exceptions in application scenarios with multiple layers. The main idea is to segregate the exception handling(cross-cutting concern) of the deeper layers and catch them in the presentation layer. 

*Notice* - For sample purposes, the API throws exceptions to show the middleware catching them. Try the endpoint many times to receive 200 and 503 responses randomly. ;) 

## Usage
```bash
dotnet run --project ExceptionHandlerSample
curl --request GET 'http://localhost:5000/weatherforecast'
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


## License
[MIT](https://choosealicense.com/licenses/mit/)