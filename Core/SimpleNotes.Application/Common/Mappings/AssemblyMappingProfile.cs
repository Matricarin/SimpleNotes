using System.Reflection;
using AutoMapper;

namespace SimpleNotes.Application.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly)
    {
        ApplyMappingsFromAssembly(assembly);
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)));

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            if (instance != null)
            {
                var methodInfo = type.GetMethod("Mapping");
                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] { this });
                }
            }
        }
    }
}