using System.Text.Json;
using Automation.Common.Models;

namespace Automation.Common.Services
{
    public static class UserDataManager
    {
        private static readonly string FilePath = GetSharedFilePath();

        private static string GetSharedFilePath()
        {
            
            var solutionRoot = Directory.GetParent(AppContext.BaseDirectory)!
                                        .Parent!.Parent!.Parent!.Parent!.FullName;

            var sharedFolder = Path.Combine(solutionRoot, "SharedUserData");

            Directory.CreateDirectory(sharedFolder);

            return Path.Combine(sharedFolder, "userData.json");
        }

        public static void SaveUser(UserModel user)
        {
            var json = JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
        }

        public static UserModel GetUser()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException(
                    $"userData.json not found at {FilePath}. Run Playwright test first.");

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<UserModel>(json)!;
        }
    }
}
