using Xunit;
using System;
using Lab1;
using System.Diagnostics;

namespace TestLab1;

public class ArrayPartTest
{
    [Theory]
    [InlineData(0, -10)]
    public void IsWrongLengthArrayCreatingFailed(int a, int b)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ArrayPart(a));
        Assert.Throws<ArgumentOutOfRangeException>(() => new ArrayPart(b));
    }


    [Fact]
    public void IsNumberOfMaxAbsElemenTrue()
    {
        int N = 10;
        var array = new ArrayPart(N);
        for(int i = 0; i < N; i++)
        {
            Trace.Write(array.GetArr()[i]+ " ");
        }
        Trace.WriteLine('\n');
        
        bool isRightAnswer=true;
        float intendedAnswer = array.GetArr()[array.NumberOfMaxAbsElement()];
        Trace.WriteLine(intendedAnswer);
        for (int i = 0; i <N; i++)
        {
            if (Math.Abs(array.GetArr()[i]) > Math.Abs(intendedAnswer) && i!= array.NumberOfMaxAbsElement())
            {
                isRightAnswer=false;
            }
        }
        Assert.True(isRightAnswer);
    }

    [Fact]
    public void IsArrayContainsPositives()
    {
        Debug.WriteLine("�������� �����");
        int N = 10;
        var array = new ArrayPart(N);
        Assert.Contains(array.GetArr(), p => p > 0);
    }

    [Theory]
    [InlineData(-20, 45)]
    public void IsOrderValid(int a, int b)
    {
        int N = 10;
        var array = new ArrayPart(N);
        array.ArrayConversion(a, b);
        var arr = array.GetArr();
        bool isRightAnswer = true;
        int i = 0;
        while (arr[i] >= a && arr[i] <= b && i < N)
            i++;//���������� ��� ����������
        while (i < N)
        {
            if (arr[i] >= a && arr[i] <= b)//�� ������� �������� �� � ����� ����� �������. ��� �� ��, ������� ����� ������������
                isRightAnswer = false;
            break;
        }
        Assert.True(isRightAnswer);
    }

    [Theory]
    [InlineData(-45, 60)]
    public void IsOrderValidBigArray(int a, int b)
    {
        int N = 100;
        var array = new ArrayPart(N);
        array.ArrayConversion(a, b);
        var arr = array.GetArr();
        bool isRightAnswer = true;
        int i = 0;
        while (arr[i] >= a && arr[i] <= b && i < N)
            i++;//���������� ��� ����������
        while (i < N)
        {
            if (arr[i] >= a && arr[i] <= b)//�� ������� �������� �� � ����� ����� �������. ��� �� ��, ������� ����� ������������
                isRightAnswer = false;
            break;
        }
        Assert.True(isRightAnswer);
    }
}