using System;
using System.Reflection;

namespace Usmp.Fia.WebApiBitacorasV2.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}