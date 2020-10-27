//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Configuration;

namespace NosCore.Injector
{
    public class InjectorConfiguration : LanguageConfiguration
    {
        public string ExecutableName { get; set; } = null!;
        public string PacketLoggerDllPath { get; set; } = null!;
    }
}