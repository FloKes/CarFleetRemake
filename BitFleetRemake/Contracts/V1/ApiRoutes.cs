namespace CarFleet.Contracts.V1
{
    public static class ApiRoutes
    {

        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = $"{Root}/{Version}";


        public static class Cars
        {
            public const string GetAll = $"{Base}/cars";

            public const string Update = Base + "/cars/{carId}";

            public const string Delete = Base + "/cars/{carId}";

            public const string Get = Base + "/cars/{carId}";

            public const string Create = $"{Base}/cars";
        }
    }
}
