using System.Reflection;

namespace Template.Web.API.Presentation;

public static class PresentationAssembly
{
    public static Assembly Get() => Assembly.GetAssembly(typeof(PresentationAssembly));
}
