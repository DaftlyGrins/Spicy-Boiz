namespace davidsProperties.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using davidsProperties.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<davidsProperties.Models.davidsPropertiesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(davidsProperties.Models.davidsPropertiesContext context)
        {
            context.Properties.AddOrUpdate(i => i.postcode,
            new Property
            {
                postcode = 4109,
                address = "73 Dixon St Sunnybank",
                rent = 1500,
                image = "https://static.pexels.com/photos/106399/pexels-photo-106399.jpeg"
            }
        );
        }
    }
}
