using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class PersonelConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var newUser = new AppUser()
            {
                Id = 1,
                Email = "aliakin@gmail.com",
                EmailConfirmed = true,
                Name = "Ali",
                Surname = "Akin",
                UserName = "aliakin",
                NormalizedUserName = "ALIAKIN",
            };

            PasswordHasher<AppUser> newPass = new PasswordHasher<AppUser>();
            newUser.PasswordHash = newPass.HashPassword(newUser, "123456789*Aa");

            builder.HasData(newUser);
        }
    }
}
