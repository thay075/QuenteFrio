

Console.Clear();

Console.WriteLine(("---> QUENTE E FRIO <---"));

Console.WriteLine("\nPressione uma tecla para continuar...");
Console.ReadKey();

Console.Clear();

const int numeroTentativas = 7;

Random gerador = new Random();
int numeroGerado = gerador.Next(1, 101);

int i = 0;
int numeroDigitado = 0;
do
{
    try 
    {
    Console.Write("\nAdivinhe o número gerado entre 1 e 100: ");
    numeroDigitado = Convert.ToInt32(Console.ReadLine());
    
    if (numeroDigitado < 0)
    {
        throw new ArgumentException();
    }
    }

    catch(ArgumentException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Não são aceitos números negativos.");
        Console.ResetColor();
        return;
    }   

    catch(OverflowException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Número inválido.");
        Console.ResetColor();
        return;
    }

    catch(FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Número em formato inválido.");
        Console.ResetColor();
        return;
    }

    catch(Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Erro genérico: {ex.Message}");
        Console.WriteLine($"Tipo: {ex.GetType()}");
        Console.ResetColor();
        return;
    }

    int diferecaEntreNumeros = Math.Abs(GerarDiferencaNumeros(numeroGerado, numeroDigitado));
    
     if (numeroDigitado == numeroGerado)
    {
        break;
    }

    if (diferecaEntreNumeros <= 3)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nEstá pelando!!!");
        Console.ResetColor();
    }

    else if (diferecaEntreNumeros <= 10)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nEstá quente!");
        Console.ResetColor();
    }

    else if (diferecaEntreNumeros >= 30)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\nEstá congelando...");
        Console.ResetColor();
    }

    else
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nEstá frio");
        Console.ResetColor();
    }

    
    i++;

    Console.WriteLine($"\nVocê ainda tem {Math.Abs(i - numeroTentativas)} tentativas");

    if (i == numeroTentativas)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nVocê perdeu pois ultrapassou o limite de tentativas");
        Console.ResetColor();
        Console.Write("\nO número correto era");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($" {numeroGerado}");
        Console.ResetColor();
    
        return;
    }
}
while (i <= numeroTentativas);

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("\nVocê acertou!");
Console.ResetColor();

int GerarDiferencaNumeros(int a, int b)
{
    a = numeroGerado;
    b = numeroDigitado;
    return numeroGerado - numeroDigitado;
}