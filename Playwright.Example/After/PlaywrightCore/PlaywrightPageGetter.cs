using Microsoft.Playwright;

namespace PW.Example.After.PlaywrightCore;

public class PlaywrightPageGetter(IBrowserContextGetter browserContextGetter) 
    : IPlaywrightPageGetter  
{  
    /// <summary>  
    /// Лениво инициализируемая страница браузера.
    /// При первом обращении получает существующую страницу или создаёт новую.
    /// </summary>
    private readonly Lazy<Task<IPage>> _page
        = new(() => CreatePageAsync(browserContextGetter));  
  
    public Task<IPage> GetAsync()  
        => _page.Value;  
    
    private static async Task<IPage> CreatePageAsync(IBrowserContextGetter getter)  
    {  
        var browser =  await getter.GetAsync();  
        return await browser.NewPageAsync();  
    }  
}