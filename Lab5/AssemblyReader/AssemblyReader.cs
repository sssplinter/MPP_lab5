using System;
using System.Linq;
using System.Reflection;
using Core;
using Lab5;

namespace AssemblyReader
{
    public static class AssemblyReader
    {
        public static AssemblyInfo GetAssemblyInfo(string assemblyFile)
        {
            Assembly a = Assembly.LoadFrom(assemblyFile);
            AssemblyInfo assemblyInfo = new AssemblyInfo(a.GetName().Name);

            a.GetTypes().Select(t => t.Namespace).Distinct().Where(n => n != null).ToList().ForEach(s =>
            {
                NamespaceInfo namespaceInfo = new NamespaceInfo(s);
                assemblyInfo.Namespaces.Add(namespaceInfo);
                a.GetTypes().Where(t => t.IsClass && t.Namespace == s).ToList().ForEach(
                    c =>
                    {
                        ClassInfo classInfo = new ClassInfo(c.ToString());
                        namespaceInfo.Classes.Add(classInfo);

                        c.GetFields().ToList().ForEach(f =>
                            classInfo.Members.First(m => m.Name == "Fields").Values.Add(f.Name));

                        c.GetProperties().ToList().ForEach(p =>
                            classInfo.Members.First(m => m.Name == "Properties").Values.Add(p.Name));

                        c.GetMethods().ToList()
                            .ForEach(m =>
                                classInfo.Members.First(mi => mi.Name == "Methods").Values.Add(m.Name));
                    });
            });

            return assemblyInfo;
        }

        public static AssemblyInfo GetAttributeAssemblyInfo(string assemblyFile)
        {
            Assembly a = Assembly.LoadFrom(assemblyFile);
            AssemblyInfo assemblyInfo = new AssemblyInfo(a.GetName().Name);
            a.GetTypes().Select(t => t.Namespace).Distinct().Where(n => n != null).ToList().ForEach(s =>
            {
                NamespaceInfo namespaceInfo = new NamespaceInfo(s);
                assemblyInfo.Namespaces.Add(namespaceInfo);
                a.GetTypes().Where(t => t.IsClass && t.Namespace == s)
                    .ToList().ForEach(
                        c =>
                        {
                            if (c.IsDefined(typeof(ExportClassAttribute), false))
                            {
                                Console.WriteLine(c.ToString());

                                ClassInfo classInfo = new ClassInfo(c.ToString());
                                namespaceInfo.Classes.Add(classInfo);
                            }
                        });
            });

            return assemblyInfo;
        }
    }
}