class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите ключ доступа: ");
        string Key = Console.ReadLine();
        DocumentWorker worker;
         
        switch (Key)
        {
            case "pro":
                worker = new ProDocumentWorker();
            break;
            case "exp":
                worker = new ExpertDocumentWorker();
                break;
            default:
                worker = new DocumentWorker();
                break;
        }
        //при неправильном введении ключа доступ == бесплатный, это приемлемо?
        worker.OpenDocument();
        worker.EditDocument();
        worker.SaveDocument();
    }
}

class DocumentWorker
{

    public virtual void OpenDocument() 
    {
        Console.WriteLine("Документ открыт");
    }

    public virtual void EditDocument()
    {
        Console.WriteLine("Редактирование документа доступно в версии Pro");
    }

    public virtual void SaveDocument()
    {
        Console.WriteLine("Сохранение документа доступно в версии Pro");
    }

}

class ProDocumentWorker : DocumentWorker
{
    public override void EditDocument()
    {
        Console.WriteLine("Документ отредактирован");
    }

    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert");
    }


}

class ExpertDocumentWorker : DocumentWorker
{
    public override void EditDocument()
    {
        Console.WriteLine("Документ отредактирован");
    }
    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в новом формате");
    }
}