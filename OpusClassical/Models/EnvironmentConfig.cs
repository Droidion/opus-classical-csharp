using dotenv.net;
using dotenv.net.Utilities;

namespace OpusClassical.Models;

public class EnvironmentConfig
{
    public EnvironmentConfig()
    {
        try
        {
            DotEnv.Load();
            SupabaseUrl = EnvReader.GetStringValue("SUPABASE_URL");
            SupabaseKey = EnvReader.GetStringValue("SUPABASE_KEY");
            DatabaseConnectionString = EnvReader.GetStringValue("DATABASE_CONNECTION_STRING");
            ImagesUrl = EnvReader.GetStringValue("IMAGES_URL");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not initialise environment variables: {ex.Message}");
            Environment.Exit(1);
        }
    }

    public string SupabaseUrl { get; }
    public string SupabaseKey { get; }
    public string DatabaseConnectionString { get; }
    public string ImagesUrl { get; }
}