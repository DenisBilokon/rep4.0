namespace Program;

public class ApplicationLicense
{
    public enum AccessLevels : int
    {
        Free = 1,
        Trial = 2,
        Pro = 3
    }

    private string? _key;
    private Nullable<int> _accessLevel;

    public int AccessLevel
    {
        get
        {
            var accessLevel = _accessLevel;

            if (!accessLevel.HasValue)
            {
                accessLevel = _accessLevel = ReadKey();
            }

            return (int)accessLevel;
        }
    }

    public ApplicationLicense(string? key)
    {
        _key = key;
    }

    private int ReadKey()
    {
        switch (_key)
        {
            case "pro":
                return (int)AccessLevels.Pro;
            case "trial":
                return (int)AccessLevels.Trial;
            default:
                return (int)AccessLevels.Free;
        }
    }

    public void PrintLicense()
    {
        switch (AccessLevel)
        {
            case (int)AccessLevels.Free:
                Console.WriteLine("Безкоштовна версiя");
                break;
            case (int)AccessLevels.Trial:
                Console.WriteLine("Пробна версiя");
                break;
            case (int)AccessLevels.Pro:
                Console.WriteLine("Про версiя");
                break;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введiть лiцензiйний ключ: ");
        var key = Console.ReadLine();

        var license = new ApplicationLicense(key);

        if (license.AccessLevel >= (int)ApplicationLicense.AccessLevels.Pro)
        {
            Console.WriteLine("Функцiя Pro доступна");
        }

        if (license.AccessLevel >= (int)ApplicationLicense.AccessLevels.Trial)
        {
            Console.WriteLine("Функцiя Пробна доступна");
        }

        if (license.AccessLevel >= (int)ApplicationLicense.AccessLevels.Free)
        {
            Console.WriteLine("Безкоштовна Функцiя  доступна");
        }
    }
}