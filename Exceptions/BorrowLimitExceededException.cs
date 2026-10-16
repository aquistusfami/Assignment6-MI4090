/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class BorrowLimitExceededException : BorrowingException
{
    public string BorrowerId { get; }
    public int MaximumDevices { get; }

    public BorrowLimitExceededException(string id, int max) : base($"<!> Người mượn mã {id} đã mượn quá {max} cho phép")
    {
        BorrowerId = id;
        MaximumDevices = max;
    }
} 