using Microsoft.Playwright;

namespace PW.Example.After.POM.Controls;

/// <summary>
/// Базовый абстрактный класс для всех PageElements (UI-компонентов, контролов).
/// Инкапсулирует локатор элемента и предоставляет методы для работы с ним.
/// </summary>
/// <remarks>
/// Оборачивает низкоуровневый ILocator в семантически значимый объект предметной области.
/// </remarks>
public abstract class ControlBase(ILocator locator)
{
    /// <summary>
    /// Локатор элемента страницы. Предоставляет доступ к низкоуровневым операциям
    /// взаимодействия с UI-элементом через Playwright API.
    /// </summary>
    public ILocator Locator { get; } = locator;

    /// <summary>
    /// Создает объект для утверждений (assertions) над текущим элементом.
    /// Позволяет выполнять проверки состояния элемента в тестах.
    /// </summary>
    /// <returns>Объект ILocatorAssertions для цепочки утверждений</returns>
    public ILocatorAssertions Expect()
        => Assertions.Expect(Locator);
}