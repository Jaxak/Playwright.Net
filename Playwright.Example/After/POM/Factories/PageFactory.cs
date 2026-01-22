using Microsoft.Playwright;
using PW.Example.After.POM.Pages;

namespace PW.Example.After.POM.Factories;

public class PageFactory(IDependenciesFactory dependenciesFactory) 
    : IPageFactory  
{  
    public TPage Create<TPage>(IPage page) where TPage : PageBase  
    {  
        var dependency = dependenciesFactory.CreateDependency(typeof(TPage));  
        return (TPage)Activator.CreateInstance(
            typeof(TPage), 
            new []{page}.Concat(dependency).ToArray()
        )!;  
    }  
}