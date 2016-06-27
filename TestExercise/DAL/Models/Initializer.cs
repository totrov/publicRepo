using System.Data.Entity;

namespace DAL.Models
{
    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            var xPhone3 = new Product
            {
                Price = new decimal(2.48),
                Name = "XPhone 3"
            };
            var xPhone3Plus = new Product
            {
                Price = new decimal(15.16),
                Name = "XPhone 3 Plus"
            };

            context.Products.AddRange(new[] { xPhone3, xPhone3Plus });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
