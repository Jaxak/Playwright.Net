using Microsoft.Playwright;
using NUnit.Framework;

namespace PW.Example;

[SetUpFixture]
public class BrowserInstaller
{
    [OneTimeSetUp]
    public void InstallChromium()
        => Program.Main(["install", "chromium"]);
}