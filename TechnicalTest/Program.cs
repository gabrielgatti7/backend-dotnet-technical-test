// See https://aka.ms/new-console-template for more information
using System.Text;
using TechnicalTest.Question1;
using TechnicalTest.Question2;
using TechnicalTest.Question3;

Console.OutputEncoding = Encoding.UTF8;

// Questão 1: Verificar se uma string é um palíndromo
Console.WriteLine(PalindromeChecker.IsPalindrome("Arara"));
Console.WriteLine(PalindromeChecker.IsPalindrome("Roma me tem amor."));
Console.WriteLine(PalindromeChecker.IsPalindrome("O;$ lobo.;^~ ama ;o bolo."));
Console.WriteLine(PalindromeChecker.IsPalindrome("Isso não é um palíndromo."));

// Questão 2: Gerar sequência de Fibonacci
Console.WriteLine(string.Join(", ", Fibonacci.GenerateSequence(0)));
Console.WriteLine(string.Join(", ", Fibonacci.GenerateSequence(5)));
Console.WriteLine(string.Join(", ", Fibonacci.GenerateSequence(7)));

// Questão 3: Normalizar texto removendo repetições de exclamações e interrogações
Console.WriteLine(TextNormalizer.NormalizeExclamationAndQuestionMark("Como é???????"));
Console.WriteLine(TextNormalizer.NormalizeExclamationAndQuestionMark("Não!!!!!!!!"));
Console.WriteLine(TextNormalizer.NormalizeExclamationAndQuestionMark("O que???!!!!! Não acredito!!!"));