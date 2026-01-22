using Microsoft.Playwright;

namespace PW.Example.After.PlaywrightCore;

public class BrowserContextGetter(IBrowserGetter browserGetter) 
    : IBrowserContextGetter  
{  
    /// <summary>  
    /// Лениво инициализируемый контекст браузера.    
    /// Создаётся при первом обращении.    
    /// </summary>    
    private readonly Lazy<Task<IBrowserContext>> _browserContext
        = new(() => CreateContextAsync(browserGetter));  
  
    public Task<IBrowserContext> GetAsync()  
        =>  _browserContext.Value;  
  
    private static async Task<IBrowserContext> CreateContextAsync(IBrowserGetter getter)  
    {  
        var browser =  await getter.GetAsync();  
        return await browser.NewContextAsync();  
    }  
}