using Microsoft.Playwright;

namespace PW.Example.Before.Tests;

/// <summary>  
/// Базовый абстрактный класс для тестов с настройкой Playwright.  
/// Предоставляет общую логику инициализации браузера и создания страниц.  
/// </summary>  
public abstract class TestBase  
{  
    /// <summary>  
    /// Инициализация экземпляра Playwright.
    /// Выполняется один раз при первом обращении и используется всеми тестами.
    /// </summary>
    private static readonly Task<IPlaywright> PlaywrightTask = Playwright.CreateAsync();  
  
    /// <summary>  
    /// Создает и возвращает новую страницу браузера, переходит по указанному URL.
    /// Запускает Chromium в видимом режиме (Headless = false).
    /// </summary>
    /// <param name="url">URL для перехода</param>
    /// <returns>Экземпляр страницы Playwright</returns>    
    protected async Task<IPage> GetPageAsync(string url)  
    {  
        var pw = await PlaywrightTask;  
        var browser = await pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions(){Headless = false});  
        var browserContext = await browser.NewContextAsync();  
        var page = await browserContext.NewPageAsync();  
        await page.GotoAsync(url);  
        return page;  
    }  
}