using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab5
{
    public class AssemblyInfo
    {
        public string Name { get; }
        public ObservableCollection<NamespaceInfo> Namespaces { get; set; }

        public AssemblyInfo(string name)
        {
            Name = name;
            Namespaces = new ObservableCollection<NamespaceInfo>();
        }

        public void PrintPublicItems()
        {
            Namespaces.OrderBy(n => n).ToList().ForEach(n => n.Classes.ToList().ForEach(c
                => c.Members.ToList().ForEach(m => m.Values.OrderBy(v => v).ToList().ForEach(v =>
                    Console.WriteLine(n.Name + "." + c.Name + "." + m.Name + "." + v)))));
        }

        public void PrintPublicClasses()
        {
            Namespaces.OrderBy(n => n).ToList().ForEach(n => n.Classes.ToList().ForEach(c
                => c.Members.ToList().ForEach(m => Console.WriteLine(n.Name + "." + c.Name))));
        }
    }

    public class NamespaceInfo
    {
        public string Name { get; }
        public ObservableCollection<ClassInfo> Classes { get; set; }

        public NamespaceInfo(string name)
        {
            Name = name;
            Classes = new ObservableCollection<ClassInfo>();
        }
    }

    public class ClassInfo
    {
        public string Name { get; }

        public ObservableCollection<MemberInfo> Members { get; set; }

        public ClassInfo(string name)
        {
            Name = name;
            Members = new ObservableCollection<MemberInfo>
            {
                new MemberInfo("Fields"), new MemberInfo("Properties"), new MemberInfo("Methods")
            };
        }
    }

    public class MemberInfo
    {
        public string Name { get; }

        public ObservableCollection<string> Values { get; set; }

        public MemberInfo(string name)
        {
            Name = name;
            Values = new ObservableCollection<string>();
        }
    }
}