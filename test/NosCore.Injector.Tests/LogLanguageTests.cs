//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NosCore.Shared.Enumerations;

namespace NosCore.Injector.Tests
{
    [TestClass]
    public class LogLanguageTests
    {
        [TestMethod]
        public void EveryKeyHasAMessageInEveryLanguage()
        {
            foreach (var region in Enum.GetValues<RegionType>())
            {
                foreach (var key in Enum.GetValues<LogLanguageKey>())
                {
                    var message = LogLanguage.Instance.GetMessageFromKey(key, region.ToString());
                    Assert.AreNotEqual($"#<{key}>", message, $"{key} has no message for {region}");
                }
            }
        }
    }
}
