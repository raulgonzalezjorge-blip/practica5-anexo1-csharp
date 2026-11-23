internal static class Program
{
    private static void Main()
    {
        int[]? numeros = null;
        var salir = false;

        while (!salir)
        {
            Console.WriteLine();
            Console.WriteLine("=== MENÚ DE ARRAYS ===");
            Console.WriteLine("1. Crear o reemplazar el array");
            Console.WriteLine("2. Mostrar el array");
            Console.WriteLine("3. Calcular suma y media");
            Console.WriteLine("4. Mostrar mínimo y máximo");
            Console.WriteLine("5. Buscar un número");
            Console.WriteLine("6. Ordenar de menor a mayor");
            Console.WriteLine("7. Invertir el array");
            Console.WriteLine("8. Calcular la mediana");
            Console.WriteLine("9. Calcular la desviación típica");
            Console.WriteLine("10. Binarizar el array");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    numeros = CrearArray();
                    break;
                case "2":
                    EjecutarSiExiste(numeros, MostrarArray);
                    break;
                case "3":
                    EjecutarSiExiste(numeros, MostrarEstadisticas);
                    break;
                case "4":
                    EjecutarSiExiste(numeros, MostrarMinimoYMaximo);
                    break;
                case "5":
                    EjecutarSiExiste(numeros, BuscarNumero);
                    break;
                case "6":
                    EjecutarSiExiste(numeros, OrdenarArray);
                    break;
                case "7":
                    EjecutarSiExiste(numeros, InvertirArray);
                    break;
                case "8":
                    EjecutarSiExiste(numeros, MostrarMediana);
                    break;
                case "9":
                    EjecutarSiExiste(numeros, MostrarDesviacionTipica);
                    break;
                case "10":
                    EjecutarSiExiste(numeros, Binarizar);
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Programa finalizado.");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
    }

    private static int[] CrearArray()
    {
        int cantidad;
        do
        {
            cantidad = LeerEntero("¿Cuántos elementos tendrá el array? ");
            if (cantidad <= 0)
            {
                Console.WriteLine("El array debe tener al menos un elemento.");
            }
        } while (cantidad <= 0);

        var numeros = new int[cantidad];
        for (var i = 0; i < numeros.Length; i++)
        {
            numeros[i] = LeerEntero($"Introduce el elemento en la posición {i}: ");
        }

        Console.WriteLine("Array creado correctamente.");
        return numeros;
    }

    private static int LeerEntero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out var numero))
            {
                return numero;
            }

            Console.WriteLine("Entrada no válida. Introduce un número entero.");
        }
    }

    private static void EjecutarSiExiste(int[]? numeros, Action<int[]> accion)
    {
        if (numeros is null)
        {
            Console.WriteLine("Primero debes crear un array (opción 1).");
            return;
        }

        accion(numeros);
    }

    private static void MostrarArray(int[] numeros)
    {
        Console.WriteLine($"Array: [{string.Join(", ", numeros)}]");
    }

    private static void MostrarEstadisticas(int[] numeros)
    {
        long suma = 0;
        foreach (var numero in numeros)
        {
            suma += numero;
        }

        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Media: {(double)suma / numeros.Length:F2}");
    }

    private static void MostrarMinimoYMaximo(int[] numeros)
    {
        var minimo = numeros[0];
        var maximo = numeros[0];

        foreach (var numero in numeros)
        {
            if (numero < minimo)
            {
                minimo = numero;
            }

            if (numero > maximo)
            {
                maximo = numero;
            }
        }

        Console.WriteLine($"Mínimo: {minimo}");
        Console.WriteLine($"Máximo: {maximo}");
    }

    private static void BuscarNumero(int[] numeros)
    {
        var buscado = LeerEntero("Número que quieres buscar: ");
        var posiciones = new List<int>();

        for (var i = 0; i < numeros.Length; i++)
        {
            if (numeros[i] == buscado)
            {
                posiciones.Add(i);
            }
        }

        if (posiciones.Count == 0)
        {
            Console.WriteLine($"El número {buscado} no está en el array.");
            return;
        }

        Console.WriteLine($"El número {buscado} aparece en las posiciones: {string.Join(", ", posiciones)}.");
    }

    private static void OrdenarArray(int[] numeros)
    {
        System.Array.Sort(numeros);
        Console.WriteLine("Array ordenado de menor a mayor.");
        MostrarArray(numeros);
    }

    private static void InvertirArray(int[] numeros)
    {
        System.Array.Reverse(numeros);
        Console.WriteLine("Array invertido.");
        MostrarArray(numeros);
    }

    private static void MostrarMediana(int[] numeros)
    {
        // Se ordena una copia para no cambiar el array del usuario.
        var ordenados = (int[])numeros.Clone();
        System.Array.Sort(ordenados);
        var mitad = ordenados.Length / 2;
        var mediana = ordenados.Length % 2 == 0
            ? (ordenados[mitad - 1] + ordenados[mitad]) / 2.0
            : ordenados[mitad];

        Console.WriteLine($"Mediana: {mediana:F2}");
    }

    private static void MostrarDesviacionTipica(int[] numeros)
    {
        // Desviación típica poblacional: se divide entre el número de elementos.
        var media = numeros.Average();
        var sumaCuadrados = numeros.Sum(numero => (numero - media) * (numero - media));
        var desviacion = Math.Sqrt(sumaCuadrados / numeros.Length);

        Console.WriteLine($"Desviación típica: {desviacion:F2}");
    }

    private static void Binarizar(int[] numeros)
    {
        var n = LeerEntero("Número n para binarizar: ");
        var binario = new int[numeros.Length];
        for (var i = 0; i < numeros.Length; i++)
        {
            binario[i] = numeros[i] < n ? 0 : 1;
        }

        Console.WriteLine($"Array binarizado con n = {n}: [{string.Join(", ", binario)}]");
    }
}
