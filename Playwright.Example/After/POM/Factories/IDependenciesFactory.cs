namespace PW.Example.After.POM.Factories;

/// <summary>
/// Интерфейс фабрики зависимостей для создания объектов с dependency injection.  /// Определяет контракт для разрешения зависимостей конструкторов POM.
/// </summary>  
public interface IDependenciesFactory  
{  
    /// <summary>    
    /// Создать массив зависимостей для указанного типа контрола.      
    /// </summary>      
    /// <param name="controlType">Тип POM'а</param>      
    /// <returns>Массив разрешённых зависимостей для конструктора</returns>  
    object[] CreateDependency(Type pomType);  
}