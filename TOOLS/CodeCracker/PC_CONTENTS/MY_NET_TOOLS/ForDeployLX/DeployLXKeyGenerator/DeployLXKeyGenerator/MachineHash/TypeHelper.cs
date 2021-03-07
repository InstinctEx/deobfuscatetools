namespace DeployLX.Licensing.v4
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text.RegularExpressions;

    public sealed class TypeHelper
    {
        private TypeHelper()
        {
        }

        public static Type FindType(string typeName, bool throwOnError)
        {
            return FindType(typeName, throwOnError, null);
        }

        public static Type FindType(string typeName, bool throwOnError, string defaultNamespace)
        {
            Type type = null;
            try
            {
                type = Type.GetType(typeName, false, true);
            }
            catch (Exception)
            {
            }
            if (type == null)
            {
                if ((defaultNamespace != null) && (defaultNamespace[defaultNamespace.Length - 1] != '.'))
                {
                    defaultNamespace = defaultNamespace + '.';
                }
                int index = typeName.IndexOf(',');
                if (index <= -1)
                {
                    foreach (Assembly assembly3 in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        type = assembly3.GetType(typeName, false, true);
                        if (type != null)
                        {
                            break;
                        }
                        if (defaultNamespace != null)
                        {
                            type = assembly3.GetType(defaultNamespace + typeName, false, true);
                        }
                        if (type != null)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    string name = typeName.Substring(0, index);
                    string assemblyString = typeName.Substring(index + 1).Trim();
                    Assembly assembly = null;
                    try
                    {
                        assembly = Assembly.Load(assemblyString);
                    }
                    catch
                    {
                    }
                    if (assembly == null)
                    {
                        try
                        {
                            assembly = Assembly.Load(assemblyString);
                        }
                        catch
                        {
                        }
                    }
                    if (assembly == null)
                    {
                        try
                        {
                            assemblyString = Regex.Replace(assemblyString, @",\s*Version\s?=\s?[0-9\.]*\s*", ",");
                            assembly = Assembly.Load(assemblyString);
                        }
                        catch
                        {
                        }
                    }
                    if ((assembly == null) && (assemblyString.IndexOf(',') < 0))
                    {
                        foreach (Assembly assembly2 in AppDomain.CurrentDomain.GetAssemblies())
                        {
                            if (string.Compare(assembly2.GetName().Name, assemblyString, true) == 0)
                            {
                                assembly = assembly2;
                                break;
                            }
                        }
                    }
                    if (assembly != null)
                    {
                        type = assembly.GetType(name, throwOnError, true);
                        if ((type == null) && (defaultNamespace != null))
                        {
                            type = assembly.GetType(defaultNamespace + name, throwOnError, true);
                        }
                    }
                }
            }
            if ((type == null) && throwOnError)
            {
                type = Type.GetType(typeName, true, true);
            }
            return type;
        }


        public static string GetNonVersionedAssemblyName(Assembly asm)
        {
            return GetNonVersionedAssemblyName(asm.FullName);
        }

        public static string GetNonVersionedAssemblyName(string assemblyName)
        {
            int index = assemblyName.IndexOf("Version=");
            if (index == -1)
            {
                return assemblyName;
            }
            index = assemblyName.LastIndexOf(',', index);
            if (index == -1)
            {
                return null;
            }
            int startIndex = assemblyName.IndexOf(',', index + 1);
            if (startIndex == -1)
            {
                return assemblyName.Substring(0, index);
            }
            return (assemblyName.Substring(0, index) + assemblyName.Substring(startIndex));
        }

        public static string GetNonVersionedAssemblyQualifiedName(Type type)
        {
            return (type.FullName + ", " + GetNonVersionedAssemblyName(type.Assembly));
        }

    }
}

