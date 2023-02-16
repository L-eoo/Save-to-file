using SaveMe;

string filePath = Path.GetTempPath()+"info.txt";
List<Person> people = new List<Person>();
List<string> lines = new List<string>();
Console.WriteLine(Directory.GetCurrentDirectory());
Console.ReadLine();
if (!File.Exists(filePath))
{
    File.Create(filePath).Close();
}

lines = File.ReadAllLines(filePath).ToList();
foreach (string line in lines)
{
    string[] info = line.Split(',');

    Person newPerson = new Person(info[0], info[1], int.Parse(info[2]));
    people.Add(newPerson);
}

while (true) 
{
    lines = File.ReadAllLines(filePath).ToList();
    Console.Clear();
    
    Console.WriteLine("------------------------");
    if (people.Count == 0) Console.WriteLine("The list is empty! :(");
    else
    {
        for (int i = 0; i < people.Count; i++)
        {
            Console.WriteLine($"{i+1}. {people[i].FirstName} {people[i].LastName}: {people[i].PhoneNumber}");
        }
    }



    Console.WriteLine("------------------------\n\n1. Add info\n2. Delete info\n3. Close");
    switch (Console.ReadLine())
    {
        case "1":
            Add();
            break;
        case "2":
            Delete();
            break;
        case "3":
            System.Environment.Exit(0);
            break;
        default:
            break;
    }

}
void Add()
{
    Console.Clear();
    Console.WriteLine("What is your first name?");
    string firstName = Console.ReadLine();
    Console.WriteLine("What is your last name?");
    string lastName = Console.ReadLine();
    Console.WriteLine("What is your phone number?");
    string phoneNumber = Console.ReadLine();
    if (int.TryParse(phoneNumber, out int number))
    {
        Person newPerson = new Person(firstName, lastName, number);
        people.Add(newPerson);
    }
    else
    {
        Console.WriteLine("Invalid phone number");
        Console.ReadKey();
    }

    List<string> output = new List<string>();
    foreach (Person person in people)
    {
        output.Add($"{person.FirstName},{person.LastName},{person.PhoneNumber}");
    }

    File.WriteAllLines(filePath, output);
}

void Delete()
{
    if (people.Count == 0)
    {
        Console.WriteLine("The list is empty!");
        Console.ReadKey();
        return;
    }
    Console.Clear();
    Console.WriteLine("------------------------");
    for (int i = 0; i < people.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {people[i].FirstName} {people[i].LastName}: {people[i].PhoneNumber}");
    }
    Console.WriteLine($"------------------------\n\nWhat line do you want to delete (1-{people.Count})");
    string lineNum = Console.ReadLine();
    if (int.TryParse(lineNum, out int ln)) 
    {
        if (ln > 0 && ln <= people.Count)
        {
            ln--;
            people.RemoveAt(ln);
            File.WriteAllLines(filePath, lines);
            return;
        }
    }
    Console.WriteLine("Invalid list number");
    Console.ReadKey();
}