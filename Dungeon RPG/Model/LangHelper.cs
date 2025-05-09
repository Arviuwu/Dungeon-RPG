using System.Resources;
using System.Reflection;
using System.Globalization;

namespace Dungeon_RPG.Model
{
    public static class LangHelper
    {
        private static ResourceManager _rm;

        static LangHelper()
        {
            _rm = new ResourceManager("Dungeon_RPG.Resources.Menu", Assembly.GetExecutingAssembly());
        }

        public static string? GetString(string name)
        {
            if (!String.IsNullOrEmpty(_rm.GetString(name)))
            {
                return _rm.GetString(name);
            }
            else
            {
                return "Error";
            }
        }

        public static void ChangeLanguage(string language)
        {
            var cultureInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
