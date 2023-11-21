using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class MatrixPart
    {
        private int[,] matrix;
        private int rows;
        private int cols;

        public MatrixPart(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректные размеры матрицы");
            }
            this.rows = rows;
            this.cols = cols;
            matrix = new int[rows, cols];
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //[begin; end) -> NextDouble() * (end - begin) + begin
                    matrix[i, j] = rand.Next(-100, 100)*rand.Next(0,2);
                }
            }
        }
        public int[,] GetMatrix()
        {
            return matrix;
        }
        override
        public String ToString()
        {
            String str = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    str += String.Format("{0,4}" , matrix[i, j]);
                }
                str += '\n';
            }
            return str;
        }
        //Уплотнить заданную матрицу, удаляя из нее строки и столбцы, заполненные нулями

        //Удаление нулевых строк
        public void DeleteNullRows()
        {
            bool isNull;

            for (int i = 0; i < rows; i++)
            {
                isNull = true;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isNull = false;
                    }
                }
                if (isNull)
                {
                    MatrixResizeRows(i);
                    rows--;
                    i--;
                }
                    
            }
        }
        public void MatrixResizeRows(int rowNum)
        {
            int[,] tmp = new int[rows - 1, cols];
            for (int i = 0; i < rowNum; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    tmp[i,j] = matrix[i,j];
                }
                
            }
            for (int i = rowNum; i < rows-1; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tmp[i, j] = matrix[i+1, j];
                }
            }
            matrix = tmp;
        }

        //удаление нулевых столбцов
        public void DeleteNullCols()
        {
            bool isNull;

            for (int i = 0; i < cols; i++)
            {
                isNull = true;
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[j, i] != 0)
                    {
                        isNull = false;
                        break;
                    }
                }
                if (isNull)
                {
                    MatrixResizeCols(i);
                    cols--;
                    i--;
                }
                    
            }
        }

        public void MatrixResizeCols(int colNum)
        {
            int[,] tmp = new int[rows, cols-1];
            for (int j = 0; j < colNum; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    tmp[i, j] = matrix[i, j];
                }

            }
            for (int j = colNum; j < cols - 1; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    tmp[i, j] = matrix[i, j+1];
                }
            }
            matrix = tmp;
        }

        //Найти номер первой из строк, содержащих хотя бы один положительный элемент
        public int NumOfRowWithPositiveElement()
        {
            int num = -1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        num = i;
                        break;
                    }
                }
                if (num != -1) break;
            }
            return num;
        }

    }
}
