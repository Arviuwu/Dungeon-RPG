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
            _rm = new ResourceManager("Dungeon_RPG.Resources.Languages.Menu", Assembly.GetExecutingAssembly());
        }

        public static string GetString(string name)
        {
            return string.IsNullOrEmpty(_rm.GetString(name)) || string.IsNullOrEmpty(name) ? "???" : _rm.GetString(name);
        }

        public static void ChangeLanguage(string language)
        {
            CultureInfo cultureInfo = new(language);

            //CultureInfo.CurrentCulture = cultureInfo; not needed?
            CultureInfo.CurrentUICulture = cultureInfo;
        }
    }
}
