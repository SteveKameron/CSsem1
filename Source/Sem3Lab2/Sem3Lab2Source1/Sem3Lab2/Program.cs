class Program
{
    static void Main()
    {
        Pupil pupil1 = new ExcelentPupil();
        Pupil pupil2 = new GoodPupil();
        Pupil pupil3 = new BadPupil();
        Pupil pupil4 = new BadPupil();

        ClassRoom room1 = new ClassRoom(pupil1,pupil2,pupil3,pupil4);
        room1.Print();
    }
}



class ClassRoom
{
    private Pupil[] pupils;
    
    public ClassRoom(params Pupil[] pupils)
    {
        this.pupils = pupils;
    }

    public void Print()
    {
        foreach (Pupil pupil in pupils)
        {
            if (pupil != null)
            {
                pupil.Read();
                pupil.Study();
                pupil.Write();
                pupil.Relax();
            }
        }
    }
}


//Наследуемый класс Плохого ученика
class BadPupil : Pupil
{
    public override void Study() { Console.WriteLine("BadPupil Study"); }
    public override void Read() { Console.WriteLine("BadPupil Read"); }
    public override void Write() { Console.WriteLine("BadPupil Write"); }
    public override void Relax() { Console.WriteLine("BadPupil Relax"); }

}


//Наследуемый класс Хорошего ученика
class GoodPupil : Pupil
{
    public override void Study() { Console.WriteLine("GoodPupil Study"); }
    public override void Read() { Console.WriteLine("GoodPupil Read"); }
    public override void Write() { Console.WriteLine("GoodPupil Write"); }
    public override void Relax() { Console.WriteLine("GoodPupil Relax"); }

}

//Наследуемый класс Идеального ученика
class ExcelentPupil : Pupil
{
    public override void Study() { Console.WriteLine("ExcelentPupil Study"); }
    public override void Read() { Console.WriteLine("ExcelentPupil Read"); }
    public override void Write() { Console.WriteLine("ExcelentPupil Write"); }
    public override void Relax() { Console.WriteLine("ExcelentPupil Relax"); }

}

//Базовый класс
class Pupil
{
    public virtual void Study() { Console.WriteLine("Study"); }
    public virtual void Read() { Console.WriteLine("Read"); }
    public virtual void Write() { Console.WriteLine("Write"); }
    public virtual void Relax() { Console.WriteLine("Relax"); }

}