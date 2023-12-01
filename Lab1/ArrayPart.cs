
namespace Lab1
{
    public class ArrayPart
    {
		private float[] arr;

		public float[] GetArr() { return arr; }

		public ArrayPart(int length)
		{
			if (length <= 0)
			{
				throw new ArgumentOutOfRangeException(length.ToString());
			}

			Random rand = new Random();

			arr = new float[length];
			for (int i = 0; i < arr.Length; i++)
			{
				//[begin; end) -> NextDouble() * (end - begin) + begin
				arr[i] = (float)rand.NextDouble() * 200 - 100;
			}
		}
		override
		public String ToString()
		{
			String str = "";
			for (int i = 0; i < arr.Length; i++)
			{
				str+=arr[i] + " ";
			}
			return str;
		}

		public int NumberOfMaxAbsElement()
		{
			int counter = 0;
			float maxValue = -100;
			for (int i = 0; i < arr.Length; i++)
			{
				if (Math.Abs(arr[i]) > maxValue)
				{
					maxValue = Math.Abs(arr[i]);
					counter = i;
				}
			}
			return counter;
		}



		public int NumberOfFirstPositiveElement()
		{
			int i = 0;
			while (arr[i] <= 0 && i < arr.Length) 
				i++;
			if (i == arr.Length && arr[i]<=0)//те не нашли ни одного и вышли по 2ому условию
				return -1; 
			return i;
		}


		public float SumOfElementsAfterFirstPositive()
		{
			int j = NumberOfFirstPositiveElement();
			if (j == -1) throw new Exception("Нет положительных элементов в массиве");

			float sum = 0;

			for (int i = j + 1; i < arr.Length; i++)
			{
				sum += arr[i];
			}
			return sum;
		}

		public void ArrayConversion(int a, int b)
		{
			float tmp;
			bool change = false;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				change = false;
				for (int k = 0; k < arr.Length - i - 1; k++)
				{
					if ((arr[k] < a || arr[k] > b) //текущий элемент не попадает в промежуток и должен переместиться назад
													&& (arr[k + 1] >= a && arr[k + 1] <= b))//а следующий при этом попадает в промежуток и должен переместиться в начало
					{
						tmp = arr[k];
						arr[k] = arr[k + 1];
						arr[k + 1] = tmp;
						change=true;
					}
				}
				if (!change) break;
				
			}

		}
	}
}
