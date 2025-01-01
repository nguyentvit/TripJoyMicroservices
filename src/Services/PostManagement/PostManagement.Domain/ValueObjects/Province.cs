namespace PostManagement.Domain.ValueObjects
{
    public record Province
    {
        public Guid ProvinceId { get; }
        public string ProvinceName { get; }
        private Province(Guid provinceId, string provinceName)
        {
            ProvinceId = provinceId;
            ProvinceName = provinceName;
        }
        public static Province Of(Guid provinceId, string provinceName)
        {
            return new Province(provinceId, provinceName);
        }
    }
}
