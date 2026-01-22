using NUnit.Framework;
using PW.Example.Before.POM.Pages;

namespace PW.Example.Before.Tests;

/// <summary>  
/// Тестовый класс для проверки элементов страницы Контур.  
/// Наследует базовый тестовый класс <see cref="TestBase"/>  
/// </summary>  
public class KonturPageShould : TestBase  
{  
    [Test]  
    public async Task ContainLogo()  
    {  
        var page = await GetPageAsync(Urls.Main);  
        var konturPage = new KonturPage(page);  
        await konturPage.Logo.Expect().ToHaveAttributeAsync("alt", "Kontur");  
    }  
}