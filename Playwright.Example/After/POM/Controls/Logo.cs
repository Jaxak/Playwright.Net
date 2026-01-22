using Microsoft.Playwright;

namespace PW.Example.After.POM.Controls;

/// <summary>
/// Элемент логотипа на странице. Наследует базовую функциональность из ControlBase.
/// </summary>
public class Logo(ILocator locator) : ControlBase(locator);