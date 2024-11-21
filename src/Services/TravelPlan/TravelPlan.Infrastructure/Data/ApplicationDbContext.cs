using System.Reflection;
using TravelPlan.Application.Data;

namespace TravelPlan.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<PlanLocation> PlanLocations => Set<PlanLocation>();
        public DbSet<Province> Provinces => Set<Province>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Province>().HasData(
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("An Giang")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bà Rịa-Vũng Tàu")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bắc Giang")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bắc Kạn")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bạc Liêu")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bắc Ninh")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bến Tre")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bình Định")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bình Dương")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bình Phước")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Bình Thuận")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Cà Mau")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Cần Thơ")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Cao Bằng")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Đà Nẵng")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Đắk Lắk")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Đắk Nông")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Điện Biên")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Đồng Nai")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Đồng Tháp")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Gia Lai")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hà Giang")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hà Nam")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hà Nội")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hà Tĩnh")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hải Dương")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hải Phòng")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hậu Giang")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("TP. Hồ Chí Minh")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hòa Bình")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Hưng Yên")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Khánh Hòa")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Kiên Giang")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Kon Tum")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Lai Châu")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Lâm Đồng")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Lạng Sơn")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Lào Cai")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Long An")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Nam Định")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Nghệ An")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Ninh Bình")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Ninh Thuận")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Phú Thọ")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Phú Yên")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Quảng Bình")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Quảng Nam")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Quảng Ngãi")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Quảng Ninh")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Quảng Trị")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Sóc Trăng")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Sơn La")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Tây Ninh")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Thái Bình")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Thái Nguyên")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Thanh Hóa")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Thừa Thiên - Huế")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Tiền Giang")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Trà Vinh")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Tuyên Quang")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Vĩnh Long")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Vĩnh Phúc")),
                new Province(ProvinceId.Of(Guid.NewGuid()), ProvinceName.Of("Yên Bái"))
    );

            base.OnModelCreating(builder);
        }
    }
}
