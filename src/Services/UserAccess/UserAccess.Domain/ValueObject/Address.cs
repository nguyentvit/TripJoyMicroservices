﻿namespace UserAccess.Domain.ValueObject
{
    public record Address
    {
        public string District { get; } = default!;
        public string Ward { get; } = default!;
        public string Province { get; } = default!;
        public string Country { get; } = default!;
        [JsonConstructor]
        private Address(string district, string ward, string province, string country)
        {
            District = district;
            Ward = ward;
            Country = country;
            Province = province;
        }
        public static Address Of(string district, string ward, string province, string country)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(district);
            ArgumentException.ThrowIfNullOrWhiteSpace(ward);
            ArgumentException.ThrowIfNullOrWhiteSpace(province);
            if (string.IsNullOrWhiteSpace(country))
            {
                country = "Việt Nam";
            }

            return new Address(district, ward, province, country);
        }
    }
}
