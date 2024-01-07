dotnet ef migrations add InitialCreate --context UserLoginContext --output-dir Migrations/UserLoginContextMigrate
update-database -context UserLoginContext


create from /api/authentication/register-user in swagger

{
  "firstName": "admin",
  "lastName": "admin",
  "userName": "admin",
  "password": "admin-admin",
  "email": "admin@gmail.com",
  "phoneNumber": "0909999999",
  "roles": [
    "AdminGov"
  ]
}