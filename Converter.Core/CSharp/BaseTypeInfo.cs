namespace Converter.Core.CSharp
{
    public class BaseTypeInfo
    {
        public BaseTypeInfo(string name)
        {
            if(name != "Object")
              this.Name = name;
        }

        public BaseTypeInfo(string name, BaseType type) : this(name)
        {
            this.DeclarationType = type;
        }


        public BaseType DeclarationType { get; set; }
        public string DecType
        {
            get
            {
                switch (DeclarationType)
                {
                    case BaseType.Class: return "class";
                    case BaseType.Interface: return "interface";
                    default: return "undefined";
                }
            }
        }

        public string Name { get; set; }
    }

    public enum BaseType
    {
        Class,
        Interface,
        Null
    }
}
