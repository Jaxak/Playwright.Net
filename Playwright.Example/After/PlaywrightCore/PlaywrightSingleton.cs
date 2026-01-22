using Microsoft.Playwright;

namespace PW.Example.After.PlaywrightCore;

public class PlaywrightSingleton 
    : IPlaywrightGetter  
{  
    /// <summary>  
    /// Создаётся при первом обращении 1 раз.    
    /// </summary>    
    private static readonly Task<IPlaywright> PlaywrightTask 
        = Playwright.CreateAsync();  
  
    public Task<IPlaywright> GetAsync()  
        => PlaywrightTask;  
}