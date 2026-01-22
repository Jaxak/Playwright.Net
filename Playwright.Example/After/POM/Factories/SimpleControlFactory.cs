using Microsoft.Playwright;
using PW.Example.After.POM.Controls;

namespace PW.Example.After.POM.Factories;

public class SimpleControlFactory(IDependenciesFactory dependenciesFactory) 
    : IControlFactory  
{  
    public TControl Create<TControl>(ILocator locator) where TControl : ControlBase  
    {  
        var dependency = dependenciesFactory.CreateDependency(typeof(TControl));  
        return (TControl)Activator.CreateInstance(
            typeof(TControl), 
            new []{locator}.Concat(dependency).ToArray()
        )!;  
    }  
}