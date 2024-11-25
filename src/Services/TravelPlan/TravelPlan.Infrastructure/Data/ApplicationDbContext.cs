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
    new Province(ProvinceId.Of(Guid.Parse("66B66C13-269F-4F6E-A673-2E085E9C8109")), ProvinceName.Of("Vĩnh Long")),
    new Province(ProvinceId.Of(Guid.Parse("D2CFA81A-87FD-4FC2-BFD4-05EB5939110D")), ProvinceName.Of("Bắc Ninh")),
    new Province(ProvinceId.Of(Guid.Parse("AF7F2569-0EFE-47AD-871B-471F53AA5388")), ProvinceName.Of("Bình Định")),
    new Province(ProvinceId.Of(Guid.Parse("C869D581-D3BC-4FC7-9C65-6F9BC6776324")), ProvinceName.Of("Hà Nam")),
    new Province(ProvinceId.Of(Guid.Parse("A995C907-1B5B-4FBB-BFD7-781B1EF3CE87")), ProvinceName.Of("Sóc Trăng")),
    new Province(ProvinceId.Of(Guid.Parse("0A56C5B7-8283-4C22-A555-81C8C77EFB9F")), ProvinceName.Of("Hà Nội")),
    new Province(ProvinceId.Of(Guid.Parse("43F04EFD-9498-416E-BDF8-E474EB98C48E")), ProvinceName.Of("Bình Dương")),
    new Province(ProvinceId.Of(Guid.Parse("F520027B-7E86-47B3-8FE3-676498C6929D")), ProvinceName.Of("Điện Biên")),
    new Province(ProvinceId.Of(Guid.Parse("2FC5E4CD-EDDB-44A2-A792-56292ABEA2DB")), ProvinceName.Of("Đà Nẵng")),
    new Province(ProvinceId.Of(Guid.Parse("B9DFDACA-BB4F-4921-ADFE-0F5173AD456E")), ProvinceName.Of("Hải Phòng")),
    new Province(ProvinceId.Of(Guid.Parse("8E4E0F95-55AB-48DD-9AA7-70B6D63B435C")), ProvinceName.Of("Cần Thơ")),
    new Province(ProvinceId.Of(Guid.Parse("1EADD14F-31AE-4046-ABCA-3CFDD5BF43E3")), ProvinceName.Of("Thành phố Hồ Chí Minh")),
    new Province(ProvinceId.Of(Guid.Parse("89D35CC2-8CDF-41B4-97D0-4DD8B5199AE3")), ProvinceName.Of("An Giang")),
    new Province(ProvinceId.Of(Guid.Parse("8CC96E0F-07BE-4874-AC23-E6297FCACC9B")), ProvinceName.Of("Bà Rịa - Vũng Tàu")),
    new Province(ProvinceId.Of(Guid.Parse("BF64F2AC-A7FC-40A8-B4EE-317CF80A0E5E")), ProvinceName.Of("Bắc Giang")),
    new Province(ProvinceId.Of(Guid.Parse("35555D6D-2292-4C5E-AA64-79C00560D358")), ProvinceName.Of("Bắc Kạn")),
    new Province(ProvinceId.Of(Guid.Parse("D05BBF91-5E47-4155-BB29-E3EBC56E18CA")), ProvinceName.Of("Bạc Liêu")),
    new Province(ProvinceId.Of(Guid.Parse("8E1C7A51-6505-45B7-B9C5-291AADBFBA45")), ProvinceName.Of("Bến Tre")),
    new Province(ProvinceId.Of(Guid.Parse("94983E70-6088-43BF-A69F-5E3AFDE1DC0A")), ProvinceName.Of("Bình Phước")),
    new Province(ProvinceId.Of(Guid.Parse("0A97DEFF-644D-49F2-A710-70E1C54DC4CE")), ProvinceName.Of("Bình Thuận")),
    new Province(ProvinceId.Of(Guid.Parse("7C12D94C-83BC-40AA-8912-83C9E6CA25C7")), ProvinceName.Of("Cà Mau")),
    new Province(ProvinceId.Of(Guid.Parse("41FDA8A9-66A2-4749-8F6F-5772EDF88D5B")), ProvinceName.Of("Cao Bằng")),
    new Province(ProvinceId.Of(Guid.Parse("1685DE7F-9F41-4620-9EE0-A133A802D3FC")), ProvinceName.Of("Đắk Lắk")),
    new Province(ProvinceId.Of(Guid.Parse("84661E95-3027-42B6-977B-BD204EAA8564")), ProvinceName.Of("Đắk Nông")),
    new Province(ProvinceId.Of(Guid.Parse("6B08F721-A3CF-412F-9BB0-1EE200E1B3D2")), ProvinceName.Of("Đồng Nai")),
    new Province(ProvinceId.Of(Guid.Parse("B4DC9369-10E3-4A37-9D7E-E6CFB609E40D")), ProvinceName.Of("Đồng Tháp")),
    new Province(ProvinceId.Of(Guid.Parse("C5556C9E-D51F-4BBF-A190-40EBF3FFC8B7")), ProvinceName.Of("Gia Lai")),
    new Province(ProvinceId.Of(Guid.Parse("6980124C-AAA3-4807-A188-846EF6B7F090")), ProvinceName.Of("Hà Giang")),
    new Province(ProvinceId.Of(Guid.Parse("5ECD8FA9-468B-418C-AFE5-5E9098AB0659")), ProvinceName.Of("Hà Tĩnh")),
    new Province(ProvinceId.Of(Guid.Parse("64930E47-3E18-4878-9830-A86CA00E51DF")), ProvinceName.Of("Hải Dương")),
    new Province(ProvinceId.Of(Guid.Parse("35370D91-DABA-4423-AA4F-7F555EB5427F")), ProvinceName.Of("Hòa Bình")),
    new Province(ProvinceId.Of(Guid.Parse("AD09D53A-FE5B-45AA-A1D6-4AFBCD673BFC")), ProvinceName.Of("Hậu Giang")),
    new Province(ProvinceId.Of(Guid.Parse("E874352A-3A44-4398-BA8A-A3FB2B69ADF7")), ProvinceName.Of("Hưng Yên")),
    new Province(ProvinceId.Of(Guid.Parse("A9891668-008E-4F51-98C3-60C4ADE39847")), ProvinceName.Of("Khánh Hòa")),
    new Province(ProvinceId.Of(Guid.Parse("3380B8F5-E854-4E72-8021-C6F2146655F0")), ProvinceName.Of("Kiên Giang")),
    new Province(ProvinceId.Of(Guid.Parse("E21AB1B1-D75D-4D7F-AF0A-109E015E6B10")), ProvinceName.Of("Kon Tum")),
    new Province(ProvinceId.Of(Guid.Parse("0B97FDD6-4FCE-4339-86DB-19ADA04DDABE")), ProvinceName.Of("Lai Châu")),
    new Province(ProvinceId.Of(Guid.Parse("3DDCEEDF-A16B-4FAC-B92F-F2E7211F878A")), ProvinceName.Of("Lâm Đồng")),
    new Province(ProvinceId.Of(Guid.Parse("FAB88A89-58A2-4813-B24C-99D15978622A")), ProvinceName.Of("Lạng Sơn")),
    new Province(ProvinceId.Of(Guid.Parse("2488EC0F-0086-428D-88C2-8B4551636B31")), ProvinceName.Of("Lào Cai")),
    new Province(ProvinceId.Of(Guid.Parse("DB62B353-8AA3-414B-8B0F-D9A6F1CA1AE3")), ProvinceName.Of("Long An")),
    new Province(ProvinceId.Of(Guid.Parse("39DAA34E-B0B1-44ED-B54E-84123563BD9D")), ProvinceName.Of("Nam Định")),
    new Province(ProvinceId.Of(Guid.Parse("4D065DA1-A78B-4F0E-97C6-0BB5D3F55FFB")), ProvinceName.Of("Nghệ An")),
    new Province(ProvinceId.Of(Guid.Parse("E79A15F0-2A14-4FB8-8299-F2F866BEEDC9")), ProvinceName.Of("Ninh Bình")),
    new Province(ProvinceId.Of(Guid.Parse("2C3F37AA-57AF-4D55-85A5-3074D13BD40C")), ProvinceName.Of("Ninh Thuận")),
    new Province(ProvinceId.Of(Guid.Parse("5DC9D3AA-7C7A-4D71-B481-746AB155E1E8")), ProvinceName.Of("Phú Thọ")),
    new Province(ProvinceId.Of(Guid.Parse("0F44EEB8-2EB6-4D9C-B2F9-E17FA0645307")), ProvinceName.Of("Phú Yên")),
    new Province(ProvinceId.Of(Guid.Parse("EF6B32FF-FFBE-43EA-9F16-9C379E029F90")), ProvinceName.Of("Quảng Bình")),
    new Province(ProvinceId.Of(Guid.Parse("DB5A59F0-5D3A-4307-A5EE-9898F9F781C9")), ProvinceName.Of("Quảng Nam")),
    new Province(ProvinceId.Of(Guid.Parse("A690946D-3046-494B-9641-B2AC361B51E0")), ProvinceName.Of("Quảng Ngãi")),
    new Province(ProvinceId.Of(Guid.Parse("823D7032-AC29-4904-81A3-37E2612C1DB2")), ProvinceName.Of("Quảng Ninh")),
    new Province(ProvinceId.Of(Guid.Parse("B2346372-4D2E-4597-A96F-B12D2F6C66FB")), ProvinceName.Of("Quảng Trị")),
    new Province(ProvinceId.Of(Guid.Parse("D1E3C73A-02AB-463C-965D-5BA1CF74857F")), ProvinceName.Of("Sóc Trăng")),
    new Province(ProvinceId.Of(Guid.Parse("7B916C3F-04A4-43AF-A7BD-D128A3A36293")), ProvinceName.Of("Sơn La")),
    new Province(ProvinceId.Of(Guid.Parse("A7E2CC11-2FFA-40B4-BE70-F2F253F33886")), ProvinceName.Of("Tây Ninh")),
    new Province(ProvinceId.Of(Guid.Parse("526FA4EF-E9D8-4575-84FD-C0F2EF9D96EA")), ProvinceName.Of("Thái Bình")),
    new Province(ProvinceId.Of(Guid.Parse("0D57D40B-90DD-43A1-BE67-C3D01A33A90D")), ProvinceName.Of("Thái Nguyên")),
    new Province(ProvinceId.Of(Guid.Parse("7CE6EBE3-F3C8-40DA-8DBE-CF533AED0077")), ProvinceName.Of("Thanh Hóa")),
    new Province(ProvinceId.Of(Guid.Parse("BA149EC2-C97C-46D2-86D1-BE3AF2AB008E")), ProvinceName.Of("Thừa Thiên Huế")),
    new Province(ProvinceId.Of(Guid.Parse("0815B31E-4329-4CA5-88B4-2A137C09BDF1")), ProvinceName.Of("Tiền Giang")),
    new Province(ProvinceId.Of(Guid.Parse("4942B167-0EAA-4776-BFB3-43AD85E190B5")), ProvinceName.Of("Trà Vinh")),
    new Province(ProvinceId.Of(Guid.Parse("4938E4E5-F624-41BF-B3F6-6B4DBC50B246")), ProvinceName.Of("Tuyên Quang")),
    new Province(ProvinceId.Of(Guid.Parse("E4775923-9725-497D-AD4E-225772EB7E68")), ProvinceName.Of("Vĩnh Phúc")),
    new Province(ProvinceId.Of(Guid.Parse("5DFFC807-AADD-4F33-98BA-35209158F41F")), ProvinceName.Of("Yên Bái")),
    new Province(ProvinceId.Of(Guid.Parse("2FC19558-5FF8-4B39-BE3D-950DE1928B93")), ProvinceName.Of("Thái Bình"))
);

            base.OnModelCreating(builder);
        }
    }
}
