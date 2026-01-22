using Microsoft.Playwright;

namespace PW.Example.After.PlaywrightCore;

/// <summary>  
/// Интерфейс для асинхронного получения экземпляра IPlaywright - корневого объекта библиотеки Playwright.  
/// Определяет стратегию инициализации или получения экземпляра Playwright, абстрагируя конкретную реализацию.  
/// </summary>  
public interface IPlaywrightGetter  
{  
    /// <summary>  
    /// Асинхронно возвращает инициализированный экземпляр IPlaywright, готовый к использованию.    
    /// Реализация может создавать новый экземпляр, возвращать существующий или использовать пул объектов.    
    /// </summary>    
    /// <returns>Задача, результатом которой является готовый к использованию объект IPlaywright</returns>    
    Task<IPlaywright> GetAsync();  
}