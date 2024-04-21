if (args.Length > 0)
{
    string path = args[0];
    int columns = args.Length > 1 ? int.Parse(args[1]) : 2;
    char separator = args.Length > 2 ? char.Parse(args[2].Replace("\\t", "\t")) : '\t';
    bool outputToFile = args.Length > 3 && args[3] != "-";
    string outputPath = outputToFile ? args[3] : "-";

    int index = 0;
    string[] lines = File.ReadAllLines(path);
    if (outputToFile)
    {
        //File.Delete(outputPath);
        using StreamWriter outputFile = File.CreateText(outputPath);
        while (index < lines.Length)
        {
            string[] parts = lines.Skip(index).Take(columns).ToArray();
            string line = string.Join(separator, parts);
            index += parts.Length;
            if (outputToFile)
                outputFile.WriteLine(line);
            Console.WriteLine(line);
        }
        return;
    }
    while (index < lines.Length)
    {
        string[] parts = lines.Skip(index).Take(columns).ToArray();
        string line = string.Join(separator, parts);
        index += parts.Length;
        Console.WriteLine(line);
    }
    return;
}

Console.WriteLine("pivot1 <path> [<columns>|2] [<separator>|\\t] [<outputPath>|-]");
