run file ScripExplain.sql

// Register
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