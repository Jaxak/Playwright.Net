using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;

namespace PW.Example.After.POM.Factories;

/// <summary>  
/// Фабрика зависимостей для интеграции с Microsoft.Extensions.DependencyInjection.  /// Создаёт зависимости для конструкторов POM через DI контейнер.  
/// </summary>  
public class DependencyFactory(IServiceProvider serviceProvider)  
    : IDependenciesFactory  
{  
    /// <summary>    
    /// Создать массив зависимостей для указанного типа контрола.  
    /// Использует DI контейнер для разрешения зависимостей.
    /// </summary> /// <param name="pomType">Тип объекта, для которого создаются зависимости</param>
    /// <returns>Массив разрешённых зависимостей для конструктора</returns>
    /// <exception cref="NotSupportedException">Выбрасывается, если класс имеет более одного конструктора</exception>
    public object[] CreateDependency(Type pomType)  
    {  
        var constructors = pomType.GetConstructors();  
        if (constructors.Length != 1)  
        {  
            throw new NotSupportedException($"{pomType} должен иметь только один конструктор");  
        }  
  
        var constructor = constructors.Single();  
  
        var parameters = constructor  
            .GetParameters()  
            .Where(x => x.ParameterType != typeof(IPage))  
            .Where(x => x.ParameterType != typeof(ILocator))  
            .Select<ParameterInfo, object>(x => serviceProvider.GetRequiredService(x.ParameterType));  
        return parameters.ToArray();  
    }  
}