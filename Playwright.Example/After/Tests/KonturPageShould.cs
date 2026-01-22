using NUnit.Framework;
using PW.Example.After.POM.Pages;

namespace PW.Example.After.Tests;

/// <summary>  
/// Тестовый класс для проверки элементов страницы Контур.  
/// Наследует базовый тестовый класс <see cref="TestBase"/>  
/// </summary>  
public class KonturPageShould : TestBase  
{  
    [Test]  
    public async Task ContainLogo()  
    {  
        var konturPage = await GoToAsync<KonturPage>();
        await konturPage.Logo.Expect().ToHaveAttributeAsync("alt", "Kontur");  
    }  
}