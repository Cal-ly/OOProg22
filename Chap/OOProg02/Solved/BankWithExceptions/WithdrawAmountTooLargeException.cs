﻿
/// <summary>
/// This exception is to be thrown in case it is attempted 
/// to withdraw an amount larger than the current balance
/// </summary>
class WithdrawAmountTooLargeException : Exception
{
    public WithdrawAmountTooLargeException()
    {
    }

    public WithdrawAmountTooLargeException(string message)
        : base(message)
    {
    }
}