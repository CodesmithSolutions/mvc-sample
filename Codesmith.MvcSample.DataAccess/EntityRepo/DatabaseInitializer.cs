using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var sha512CryptoProvider = new SHA512CryptoServiceProvider();

            var user = new UserEntity
            {
                Username = "john.doe",
                PasswordHash = sha512CryptoProvider.ComputeHash(Encoding.ASCII.GetBytes("Password123")),
                IsActive = true,
                //Role = "Admin",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                Profile = new UserProfileEntity
                {
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@fake.com",
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                },
                CreatedBy = new List<IssueEntity>
                {
                    new IssueEntity
                    {
                        Type = "Bug",
                        Status = "InProgress",
                        Priority = "High",
                        Title = "Test Issue Title",
                        Description = "Test Issue Description",
                        CreateDate = DateTime.Now,
                        LastUpdateDate = DateTime.Now
                    }
                }
            };

            context.Users.Add(user);

            base.Seed(context);
        }
    }
}
