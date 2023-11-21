using System;
using Xunit;
using Lab1;

namespace TestLab1
{
    public class MatrixPartUnitTest
    {
        [Theory]
        [InlineData(0, 5, 7, -10)]
        public void IsWrongLengthArrayCreatingFailed(int r1, int c1, int r2, int c2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MatrixPart(r1,c1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new MatrixPart(r2,c2));
        }

        [Fact]
        public void IsRightDeleting()
        {
            int r = 4;
            int c = 6;
            var matrix = new MatrixPart(r, c);
            matrix.DeleteNullRows();
            matrix.DeleteNullCols();
            bool isNull=true;
            //после преобразованиея не должны остаться нулевые строки или столбцы
            for (int i = 0; i < r; i++)//поиск нулевых строк
            {
                isNull = true;
                for (int j = 0; j < c; j++)
                {
                    if (matrix.GetMatrix()[i, j] != 0)
                    {
                        isNull = false;
                        break;
                    }
                }

            }
            for (int i = 0; i < c; i++)//поиск нулевых столбцов
            {
                isNull = true;
                for (int j = 0; j < r; j++)
                {
                    if (matrix.GetMatrix()[j, i] != 0)
                    {
                        isNull = false;
                        break;
                    }
                }
            }
            Assert.True(!isNull);
        }

        [Fact]
        public void IsRightDeletinBigMatrix()
        {
            int r = 100;
            int c = 100;
            var matrix = new MatrixPart(r, c);
            matrix.DeleteNullRows();
            matrix.DeleteNullCols();
            bool isNull = true;
            //после преобразованиея не должны остаться нулевые строки или столбцы
            for (int i = 0; i < r; i++)//поиск нулевых строк
            {
                isNull = true;
                for (int j = 0; j < c; j++)
                {
                    if (matrix.GetMatrix()[i, j] != 0)
                    {
                        isNull = false;
                        break;
                    }
                }

            }
            for (int i = 0; i < c; i++)//поиск нулевых столбцов
            {
                isNull = true;
                for (int j = 0; j < r; j++)
                {
                    if (matrix.GetMatrix()[j, i] != 0)
                    {
                        isNull = false;
                        break;
                    }
                }
            }
            Assert.True(!isNull);
        }
    }
}
