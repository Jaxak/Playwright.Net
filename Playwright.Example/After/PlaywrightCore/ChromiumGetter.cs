using Microsoft.Playwright;

namespace PW.Example.After.PlaywrightCore;

public class ChromiumGetter(IPlaywrightGetter playwrightGetter) 
    : IBrowserGetter  
{  
    /// <summary>  
    /// Лениво инициализируемый контекст браузера.    
    /// Создаётся при первом обращении.    
    /// </summary>    
    private readonly Lazy<Task<IBrowser>> _browser 
        = new(() => CreateBrowserAsync(playwrightGetter));  
  
    public Task<IBrowser> GetAsync()  
        => _browser.Value;  
    
    private static async Task<IBrowser> CreateBrowserAsync(IPlaywrightGetter getter)     {  
        var pw = await getter.GetAsync();  
        return await pw.Chromium.LaunchAsync();  
    }  
}