using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using Dungeon_RPG.Stores;
using System.Diagnostics;
using System.IO;
using System.Text.Json;


namespace Dungeon_RPG.Services
{
    public class SaveService
    {
        static private readonly string relativePath = "Data/Save.json";
        static private readonly string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);

        static private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public void Load(ref CharacterStore charStore)
        {

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            try
            {
                string readJson = File.ReadAllText(fullPath);
                var allCharacters = JsonSerializer.Deserialize<List<Character>>(readJson, options);

                if (allCharacters != null)
                {
                    HookStatCallbacks(ref allCharacters);
                    charStore.AllCharacters = allCharacters;
                    Debug.WriteLine("Data loaded from file.");
                }
                else
                {
                    Debug.WriteLine("Loaded JSON was null.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error loading JSON: " + ex.Message);
            }
        }
        public static void Save(CharacterStore charStore)
        {
            try
            {
                string json = JsonSerializer.Serialize(charStore.AllCharacters, options);
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                File.WriteAllText(fullPath, json);

                Debug.WriteLine("Data saved on close.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to save data on close: " + ex.Message);
            }
        }
        void HookStatCallbacks(ref List<Character> AllCharacters)
        {
            foreach (var character in AllCharacters)
            {
                foreach (var stat in character.AllStats)
                {
                    stat.OnStatIncreased = () =>
                    {
                        if (character.RemainingStatpoints > 0)
                            character.RemainingStatpoints--;
                    };

                    stat.OnStatDecreased = () =>
                    {
                        character.RemainingStatpoints++;
                    };
                    stat.IncrementCommand = new RelayCommand(_ => stat.IncPoints());
                    stat.DecrementCommand = new RelayCommand(_ => stat.DecPoints());
                }
            }
        }
        public SaveService()
        {

        }
    }
}
