# contacts_backend
Dotnet backend for contact book
- Simple web api using ASP.Net for the first time. Does basic crud operations with room for improvement

## Still to implement:
### L1
- [ ] Enable CRUD operations independent of GET -> Seeding only happens with getall operation
- [ ] Decide between using ContactService and ContactContext -> currently using 1 methods in CS to seed the getall operation
- [ ] Review routing -> it feels like I may still be mixing up options I've seen in blogs
- [ ] Add basic exception handling for CRUD operations
- [ ] Bolster caching


### L2
- [ ] Create SQL database
- [ ] Seed database with initial contacts
- [ ] Test API endpoints


### L3
- [ ] Auto generate contact IDs
- [ ] Handle errors gracefully

### Questions:

### Handy commands
- `dotnet watch`
- `httprepl \n connect http://127.0.0.1:5240 —openapi /swagger/v1/swagger.json`
- 

## Resources
### Read
- [ ] Tutorial: Create a web API with ASP.NET Core -- https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/7-crud
- [ ] https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio-code
- [ ] Get started with Swashbuckle and ASP.NET Core -- https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio
- [ ] Creating the Data Model with Entity Framework 7 -- https://learn.microsoft.com/en-us/archive/msdn-magazine/2016/august/asp-net-core-write-apps-with-visual-studio-code-and-entity-framework
- [ ] Test web APIs with the HttpRepl -- https://learn.microsoft.com/en-us/aspnet/core/web-api/http-repl/?view=aspnetcore-7.0&tabs=macos
- [ ] https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio-code
- [ ] https://stackoverflow.blog/2020/03/02/best-practices-for-rest-api-design/

## Read again
- [ ] 

## Helpful?
- [ ] Supporting both Swagger v2 and OpenApi v3 in .NET 6 -- https://blogs.u2u.be/lander/post/2022/05/18/supporting-both-swagger-v2-and-openapi-v3-in-net-6
- [ ] Make HTTP requests using IHttpClientFactory in ASP.NET Core -- https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-7.0
