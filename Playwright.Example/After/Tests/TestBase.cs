using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PW.Example.After.PlaywrightCore;
using PW.Example.After.POM.Factories;
using PW.Example.After.POM.Pages;

namespace PW.Example.After.Tests;

/// <summary>
/// Базовый класс для всех тестовых классов.
/// Предоставляет общую функциональность для управления зависимостями
/// и взаимодействия с Playwright страницами.
/// </summary>
public abstract class TestBase
{
    /// <summary>
    /// Корневой провайдер, инициализируемый при создании экземпляра TestBase.
    /// Содержит конфигурацию DI контейнера с зарегистрированными сервисами Playwright.
    /// </summary>
    private readonly IServiceProvider _serviceProvider
        = new ServiceCollection().AddPlaywright().BuildServiceProvider();

    /// <summary>
    /// Потокобезопасный словарь для хранения scopes, сопоставленных с идентификаторами тестов.
    /// Гарантирует изоляцию зависимостей между тестами и правильное время жизни объектов.
    /// </summary>
    private static readonly ConcurrentDictionary<string, IServiceScope> ScopeByTestLink = new();

    /// <summary>
    /// Получает экземпляр IServiceProvider для текущего теста.
    /// Для каждого теста создается отдельная область сервисов (scope),
    /// которая автоматически удаляется после завершения теста.
    /// </summary>
    /// <returns>Провайдер для текущего теста</returns>
    protected IServiceProvider ServiceProvider
        => ScopeByTestLink.GetOrAdd(TestContext.CurrentContext.Test.ID, _ => _serviceProvider.CreateScope())
            .ServiceProvider;

    /// <summary>
    /// Выполняется после каждого теста для очистки ресурсов.
    /// Удаляет и освобождает scope, связанную с завершенным тестом.
    /// </summary>
    [TearDown]
    private void CloseScope()
    {
        if (ScopeByTestLink.TryRemove(TestContext.CurrentContext.Test.ID, out var scope))
        {
            scope.Dispose();
        }
    }

    /// <summary>  
    /// Переходит на указанную страницу и возвращает ее объект модели страницы (Page Object).
    /// </summary>
    /// <typeparam name="TPage">Тип страницы, унаследованный от PageBase</typeparam>
    /// <returns>Экземпляр указанного типа страницы</returns>
    /// <remarks>
    /// Метод выполняет следующие действия:
    /// 1. Получает экземпляр Playwright страницы
    /// 2. Создает объект модели страницы через фабрику
    /// 3. Переходит на URL, указанный в свойстве Url объекта страницы
    /// </remarks>   
    protected async Task<TPage> GoToAsync<TPage>() where TPage : PageBase
    {
        var pwPageGetter = ServiceProvider.GetRequiredService<IPlaywrightPageGetter>();
        var pageFactory = ServiceProvider.GetRequiredService<IPageFactory>();
        var pwPage = await pwPageGetter.GetAsync();
        var pageObject = pageFactory.Create<TPage>(pwPage);
        await pwPage.GotoAsync(pageObject.Url);
        return pageObject;
    }
}