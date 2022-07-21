namespace Models
{
    public class ConnectionInfoSQL
    {
        public string? DataBaseName { get; set; }

        public string? Host { get; set; }

        public string? userDb { get; set; }

        public string? Password { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"Server={this.Host ?? string.Empty};Database={this.DataBaseName ?? string.Empty};User Id={this.userDb ?? string.Empty};Password={this.Password ?? string.Empty};";
            }
        }
    }
}
