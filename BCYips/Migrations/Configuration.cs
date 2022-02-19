using BCYips.Models;


/*
Install-Package EntityFramework
Enable-Migrations -ContextTypeName BCYips.Models.YipDbContext (-force will regenerate this file)
Add-Migration Initial
Update-Database –Verbose
 */


namespace BCYips.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BCYips.Models.YipDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BCYips.Models.YipDbContext context)
        {

            var yipper1 = new Yipper
                {
                    UserName = "user",
                    FirstName = "FirstName",
                    LastName = "LastName"
                };

            var yipper2 = new Yipper
                {
                    UserName = "PinkFloyd",
                    FirstName = "Pink",
                    LastName = "Floyd"
                };
            
            context.Yippers.AddOrUpdate(
                i => i.ID,
                yipper1,
                yipper2
                );

            var yip1 = new Yip
                {
                    Content = "You reached for the secret too soon",
                    Posted = DateTime.Now,
                    Yipper = yipper2
                };

            var yip3 = new Yip
                {
                    Content = "You run and you run to catch up with the sun, but it's sinking",
                    Posted = DateTime.Now,
                    Yipper = yipper2
                };

            context.Yips.AddOrUpdate(
                i => i.ID,
                yip1,
                new Yip
                    {
                        Content = "Is There anybody out there?",
                        Posted = DateTime.Now,
                        Yipper = yipper2
                    },
                yip3,
                new Yip
                    {
                        Content = "I've always had a deep respect and I mean that most sincere",
                        Posted = DateTime.Now,
                        Yipper = yipper2
                    },
                new Yip
                    {
                        Content = "You cried for the moon",
                        Posted = DateTime.Now,
                        Yipper = yipper1,
                        ReplyTo = yip1
                    },
                new Yip
                    {
                        Content = "",
                        Posted = DateTime.Now,
                        Yipper = yipper1,
                        ReYip = yip3
                    }
                );
        }
    }
}
