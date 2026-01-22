using Microsoft.Playwright;
using PW.Example.After.POM.Controls;
using PW.Example.After.POM.Factories;

namespace PW.Example.After.POM.Pages;

/// <summary>
/// Класс для главной страницы приложения (Kontur).
/// Наследует общую функциональность из PageBase и добавляет специфичные для страницы элементы.
/// </summary>
public class KonturPage(IPage page, IControlFactory controlFactory) : PageBase(page)
{
    /// <summary>
    /// URL главной страницы. Используется для навигации.
    /// </summary>
    public override string Url { get; } = Urls.Main;

    /// <summary>
    /// Элемент логотипа на странице.
    /// </summary>
    public Logo Logo => controlFactory.Create<Logo>(Page.Locator(".kontur-logo-image").First);
}