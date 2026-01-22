using Microsoft.Playwright;
using PW.Example.Before.POM.Controls;

namespace PW.Example.Before.POM.Pages;

/// <summary>
/// Класс для главной страницы приложения (Kontur).
/// Наследует общую функциональность из PageBase и добавляет специфичные для страницы элементы.
/// </summary>
/// <remarks>
/// 1. Преврящает локаторы элементов страницы в типизированные свойства
/// 2. Скрывает детали селекторов и структуры HTML
/// </remarks>
public class KonturPage(IPage page) : PageBase(page)
{
    /// <summary>
    /// URL главной страницы. Используется для навигации.
    /// </summary>
    public override string Url { get; } = Urls.Main;

    /// <summary>
    /// Элемент логотипа на странице.
    /// Инициализируется локатором, найденным по селектору ".kontur-logo-image".
    /// </summary>
    public Logo Logo => new Logo(Page.Locator(".kontur-logo-image").First);
}