using System.Reflection;

namespace Template.Web.API.Application;

public static class ApplicationAssembly
{
    public static Assembly Get() => Assembly.GetAssembly(typeof(ApplicationAssembly));
}
