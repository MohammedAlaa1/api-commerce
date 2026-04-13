using System.Resources;
using System.Reflection;

namespace ECommerce.Application.Helpers;

public static class LocalizerHelper
{
    public static string GetMessage<TEnum>(TEnum key) where TEnum : Enum
    {
        var enumType = typeof(TEnum);
        var namespacePath = enumType.Namespace!;
        var resourceFileName = enumType.Name;

        // e.g. "ECommerce.Application.Resources.Products.ProductValidationMessages"
        var fullResourcePath = $"{namespacePath}.{resourceFileName}";

        var assembly = Assembly.GetExecutingAssembly();
        var resourceManager = new ResourceManager(fullResourcePath, assembly);

        return resourceManager.GetString(key.ToString()) ?? key.ToString();
    }
}
