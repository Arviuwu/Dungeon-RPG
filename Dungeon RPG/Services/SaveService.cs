using Dungeon_RPG.Model;
using Dungeon_RPG.MVVM;
using Dungeon_RPG.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Dungeon_RPG.Services
{
    public class SaveService
    {
        private readonly string relativePath = "Data/Save.json";
        public void Load(ref CharacterStore charStore)
        {

            string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            if (File.Exists(fullPath))
            {
                try
                {
                    string readJson = File.ReadAllText(fullPath);
                    var characterStore = JsonSerializer.Deserialize<CharacterStore>(readJson, options);
                    if (characterStore != null)
                    {

                        if (characterStore.AllCharacters != null)
                        {
                            HookStatCallbacks(characterStore.AllCharacters);
                            charStore.AllCharacters = characterStore.AllCharacters;
                            Debug.WriteLine("Data loaded from file.");
                        }
                        else
                        {
                            Debug.WriteLine("Loaded JSON was null.");

                        }
                        if (characterStore.LastCharacter != null)
                        {
                            charStore.LastCharacter = characterStore.LastCharacter;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error loading JSON: " + ex.Message);

                }
            }
            else
            {
                Debug.WriteLine("File not found. Creating default data...");


            }

        }
        public static void Save(CharacterStore charStore)
        {
            string relativePath = "Data/Save.json";
            string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,


            };

            try
            {
                string json = JsonSerializer.Serialize(charStore, options);
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                File.WriteAllText(fullPath, json);

                Debug.WriteLine("Data saved on close.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to save data on close: " + ex.Message);
            }

        }
        void HookStatCallbacks(List<Character> AllCharacters)
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
        void HookStatCallbackSingle(Character character)
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
        public SaveService()
        {

        }
    }
}
