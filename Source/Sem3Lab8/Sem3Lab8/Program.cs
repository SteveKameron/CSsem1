using System.ComponentModel;
using System.Xml.Serialization;
namespace Sem3Lab8
{
    class Program
    {
        static void Main()
        {
            Animal animal = new Animal
            {
                Country = 123,
                HideFromOtherAnimals = 0,
                Name = "Lion",
                WhatAnimal = 52,
                Classification = eClassificationAnimal.Herbivores
            };
            //serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Animal));
            using (FileStream fileStream = new FileStream("1.xml",FileMode.Create))
            {
                serializer.Serialize(fileStream, animal);
                Console.WriteLine("xml generated");
            }
            XmlSerializer serializer_another = new XmlSerializer(typeof(Animal));
            using (FileStream fileStream = new FileStream("1.xml", FileMode.Open))
            {
                Animal deserializator = (Animal)serializer.Deserialize(fileStream);
                Console.WriteLine(deserializator.ToString());
            }

        }
    }













    public class Animal
    {
        public eClassificationAnimal Classification;
        public int Country {  get; set; }
        public int HideFromOtherAnimals {  get; set; }
        public string Name { get; set; }
        public int WhatAnimal { get; set; }
        
        public Animal(){ }
        
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

        public override string ToString()
        {
            return $"Name: {Name}, Classification: {Classification}, HideFromOtherAnimals: {HideFromOtherAnimals}, WhatAnimal: {WhatAnimal}";
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

    public class Cow : Animal
    {
        public Cow()
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
    public class Lion : Animal
    {
        public Lion()
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
    public class Pig : Animal
    {
        public Pig()
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
}