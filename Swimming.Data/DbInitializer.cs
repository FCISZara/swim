using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Swimming.Data
{
    public class DbInitializer
    {
        public static void Initialize(SwimmingContext context)
        {
            // context.Database.EnsureCreated();
            context.Database.Migrate();
            //AttachmentType 
            
        }

    }
}
