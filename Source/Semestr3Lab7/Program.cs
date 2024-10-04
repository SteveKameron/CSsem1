using Sem3Lab7;
using System.Reflection;
using System.Xml.Linq;
class Program
{
    static void Main()
    { 
        var assembly = Assembly.GetAssembly(typeof(Animal));
        var types = assembly.GetTypes().Where(t => t.IsClass && t.Namespace == "Sem3Lab7");
        var xml = new XElement("Classes", types.Select(type => new XElement("Class", new XAttribute("Name", type.Name), new XAttribute("Comment", GetComment(type)), new XElement("Methods", type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Select(m => new XElement("Method", m.Name))))));
        File.WriteAllText("ClassDiagram.xml", xml.ToString());
        Console.WriteLine("xml generated");
    }
    static string GetComment(Type type)
    {
        var attribute = type.GetCustomAttributes(typeof(AttributeCommentforClass), false).FirstOrDefault() as AttributeCommentforClass;
        return attribute?.Comment ?? string.Empty; // "no comment"?
    }
}

namespace Sem3Lab7
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AttributeCommentforClass : Attribute
    {
        public string Comment { get; set; }
        public AttributeCommentforClass(string comment)
        {
            Comment = comment;
        }
    }



    [AttributeCommentforClass("Класс всех животных")]
    public abstract class Animal
    {
        private eClassificationAnimal Classification;

        public int Country
        {
            get => default;
            set
            {
            }
        }

        public int HideFromOtherAnimals
        {
            get => default;
            set
            {
            }
        }

        public int Name
        {
            get => default;
            set
            {
            }
        }

        public int WhatAnimal
        {
            get => default;
            set
            {
            }
        }

        public Animal() { }
        public void Deconstruct()
        {
            throw new System.NotImplementedException();
        }

        public void GetClassificationAnimal()
        {
            throw new System.NotImplementedException();
        }

        public void GetFavouriteFood()
        {
            throw new System.NotImplementedException();
        }

        public void SayHello()
        {
            throw new System.NotImplementedException();
        }
    }

    [AttributeCommentforClass("Класс с представлением коровы")]
    public class Cow : Animal
    {
        public Cow() { }
        public void GetFavouriteFood()
        {
            throw new System.NotImplementedException();
        }

        public void SayHello()
        {
            Console.WriteLine("Hello Cow");
            throw new System.NotImplementedException();
        }
    }
    [AttributeCommentforClass("Класс с представлением льва")]
    public class Lion : Animal
    {
        public Lion() { }
        public void GetFavouriteFood()
        {
            throw new System.NotImplementedException();
        }

        public void SayHello()
        {
            throw new System.NotImplementedException();
        }
    }

    [AttributeCommentforClass("Класс с представлением свиньи")]
    public class Pig : Animal
    {
        public Pig() { }
        public void GetFavouriteFood()
        {
            throw new System.NotImplementedException();
        }

        public void SayHello()
        {
            throw new System.NotImplementedException();
        }
    }

    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum eFavouriteFood
    {
        Meat,
        Plants,
        Everything
    }
}