using System.ComponentModel.DataAnnotations;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            try
            {
                Console.WriteLine("// --------------- //     Первая часть     // --------------- " + '\n');
                var array = new ArrayPart(N);
                Console.WriteLine("Начальный массив:");
                Console.WriteLine(array);
                Console.WriteLine('\n'+ $"1. Номер макcимального по модулю элемента массива - {array.NumberOfMaxAbsElement()}");
                Console.WriteLine($"2. Сумма элементов, расположенных после первого положительного {array.SumOfElementsAfterFirstPositive()}");
                int a = -20;
                int b = 45;
                array.ArrayConversion(a, b);
                Console.WriteLine('\n' + $"Преобразованный массив (сначала все элементы, целая часть которых в интервале [{a}, {b}], а потом — все остальные):");
                Console.WriteLine(array);

                Console.WriteLine('\n'+ "// --------------- //     Вторая часть     // --------------- " + '\n');
                int r = 4;
                int c = 6;
                var matrix = new MatrixPart(r, c);
                Console.WriteLine(matrix);
                matrix.DeleteNullCols();
                matrix.DeleteNullRows();
                Console.WriteLine("Преобразованная матрица");
                Console.WriteLine(matrix);
                Console.WriteLine($"Номер первой из строк, содержащих хотя бы один положительный элемент - {matrix.NumOfRowWithPositiveElement()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

		}
    }
}
