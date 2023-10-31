using hw1;

LexemParser parser = new LexemParser();
ReversePolishBuilder builder = new ReversePolishBuilder();
ReversePolishEvaluation evaluation = new ReversePolishEvaluation();

while (true)
{
    Console.Write("Введите выражение: ");
    string? input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        return 0;
    }

    List<string> lexems;
    try
    {
        lexems = parser.parse_line(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }

    List<string> polished;
    try
    {
        polished = builder.parse_to_polish(ref lexems);
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }

    try
    {
        Console.WriteLine($"Результат - {evaluation.apply_polish(ref polished)}");
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
