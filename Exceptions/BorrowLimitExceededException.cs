/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

/// <summary>
/// Lớp ngoại lệ dẫn xuất Mượn quá số thiết bị được mượn 
/// </summary>
public class BorrowLimitExceededException : BorrowingException
{
    public string BorrowerId { get; }
    public int MaximumDevices { get; }

    public BorrowLimitExceededException(string id, int max) : base($"<!> Người mượn mã {id} đã mượn quá {max} thiết bị cho phép")
    {
        BorrowerId = id;
        MaximumDevices = max;
    }
} 
