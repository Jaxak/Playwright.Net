using Microsoft.Playwright;
using PW.Example.After.POM.Pages;

namespace PW.Example.After.POM.Factories;

/// <summary>
/// Фабрика для создания экземпляров Page Object'ов.
/// Обеспечивает единый механизм инициализации страниц в тестах.
/// </summary>
/// <remarks>
/// Реализует паттерн "Фабрика" для создания объектов, представляющих веб-страницы.
/// Позволяет централизовать логику создания Page Object'ов.
/// </remarks>
public interface IPageFactory
{
    /// <summary>Создает экземпляр указанного типа страницы</summary>
    /// <typeparam name="TPage">
    /// Тип создаваемого PageObject, должен наследовать <see cref="PageBase"/>.
    /// </typeparam>
    /// <param name="page">Экземпляр страницы Playwright</param>
    /// <returns>Инициализированный экземпляр страницы</returns>
    TPage Create<TPage>(IPage page) where TPage : PageBase;
}