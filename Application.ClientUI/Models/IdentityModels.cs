using System.Collections;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Application.ClientUI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string AreaCode { get; set; }
        public string DateOfBirth { get; set; }
        public string CellNo { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Name", Name));
            userIdentity.AddClaim(new Claim("Surname", Surname));
            userIdentity.AddClaim(new Claim("IdentityNumber", IdentityNumber));
            userIdentity.AddClaim(new Claim("Title", Title));
            userIdentity.AddClaim(new Claim("Address ", Address));
            userIdentity.AddClaim(new Claim("Country", Country));
            userIdentity.AddClaim(new Claim("Province", Province));
            userIdentity.AddClaim(new Claim("AreaCode", AreaCode));
            userIdentity.AddClaim(new Claim(" DateOfBirth", DateOfBirth));
            userIdentity.AddClaim(new Claim(" CellNo", CellNo));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        internal IEnumerable Technicians;
        internal IEnumerable Devices;

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Application.ClientUI.Models.BookingViewModel> BookingViewModels { get; set; }

        public System.Data.Entity.DbSet<Application.ClientUI.Models.DeviceModel> DeviceModels { get; set; }

        public System.Data.Entity.DbSet<Application.ClientUI.Models.QuotationModel> QuotationModels { get; set; }

        public System.Data.Entity.DbSet<Application.ClientUI.Models.Bookings> Bookings { get; set; }

        public System.Data.Entity.DbSet<Application.ClientUI.Models.ProfileModel> Profiles { get; set; }

        public System.Data.Entity.DbSet<Application.ClientUI.Models.TechnicianModel> TechnicianModels { get; set; }

        //public System.Data.Entity.DbSet<Application.ClientUI.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<Application.ClientUI.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}