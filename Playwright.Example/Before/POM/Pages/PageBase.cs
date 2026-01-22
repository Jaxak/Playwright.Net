using Microsoft.Playwright;

namespace PW.Example.Before.POM.Pages;

/// <summary>
/// Абстрактный базовый класс для всех PageObjects.
/// Содержит общую логику и структуру для работы со страницами приложения.
/// </summary>
/// <remarks>
/// Реализует базовый уровень паттерна Wrapper для страниц,
/// оборачивая объект IPage.
/// </remarks>
public abstract class PageBase(IPage page)
{
    /// <summary>
    /// Объект страницы Playwright. Предоставляет доступ к навигации,
    /// взаимодействию с элементами и другим API браузера.
    /// </summary>
    public IPage Page { get; } = page;

    /// <summary>
    /// Абстрактное свойство, возвращающее URL страницы.
    /// Должно быть реализовано в конкретных классах страниц.
    /// </summary>
    public abstract string Url { get; }
}