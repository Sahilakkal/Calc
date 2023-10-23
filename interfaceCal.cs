using System;

interface CalInterface
{
    int num1 { get; };
    int num2 { get; };
    string op { get; };

    public int Result(int pnum1, int pnum2, string operator);
}
