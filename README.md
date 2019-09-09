# HappySocialMedia
HappySocialMedia with Microservices Domain Driven Design with all best practices design and architetural patterns as DDD, CrossCutting IoC, SOLID, etc

# Require 
1. .NET Core 2.2
2. Visual Studio 2017

# Feateure 
1. Shared Functions 
2. EntityFrameworkCore
3. MicroORM Dapper
4. Web Api
5. SOLID Principles 
6. Design Patterns
7. Invertion Of Controll
8. Microservices Databases
9. Clean Code
10. Louse Coupling
11. Maintainable
12. Scalable
13. any more :)


# Installation
1. Open CMD and navigate to root of Solution, type “dotnet build”
2. Change appsettings.json => 	"ConnectionStrings": {},
3. Tools –> NuGet Package Manager –> Package Manager Console
Set Detault Project = Happy5SocialMedia.Activity 
Set Startup Project = Happy5SocialMedia.Activity
in Pacakage Manager Console type => Update-Database 

repeat for All Services
Happy5SocialMedia.Message
Happy5SocialMedia.User

4. Set Starup Project, to Multiple StartUp Project
Chose All Services
Happy5SocialMedia.Activity => Action => Start
Happy5SocialMedia.Message => Action => Start
Happy5SocialMedia.User => Action => Start

