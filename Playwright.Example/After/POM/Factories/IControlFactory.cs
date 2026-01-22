using Microsoft.Playwright;
using PW.Example.After.POM.Controls;

namespace PW.Example.After.POM.Factories;

/// <summary>
/// Фабрика для создания контролов на веб-страницах.
/// Предоставляет стандартизированный способ создания переиспользуемых UI-компонентов.
/// </summary>
/// <remarks>
/// Используется для инкапсуляции логики создания контролов (кнопок, полей ввода и т.д.).
/// Позволяет легко подменять реализацию контролов и упрощает поддержку тестов.
/// </remarks>
public interface IControlFactory
{
    /// <summary>Создает экземпляр указанного типа элемента</summary>
    /// <typeparam name="TControl">
    /// Тип создаваемого элемента, должен наследовать <see cref="ControlBase"/>.
    /// </typeparam>
    /// <param name="locator">
    /// Локатор Playwright, определяющий положение элемента на странице.
    /// </param>
    /// <returns>Инициализированный экземпляр контрола</returns>
    TControl Create<TControl>(ILocator locator) where TControl : ControlBase;
}