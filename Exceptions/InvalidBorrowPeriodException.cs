/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

/// <summary>
/// Lớp ngoại lệ ngày mượn không hợp lý
/// </summary>
public class InvalidBorrowPeriodException : BorrowingException
{
  public string DeviceId { get; }
  public int BorrowDays { get; }
  public int MaxBorrowDays { get; }

  public InvalidBorrowPeriodException(string id, int borrowDays, int maxBorrowDays) 
  : base($"<!> Thiết bị mã {id} có thời gian mượn {borrowDays} ngày không hợp lệ. Giới hạn mượn là {maxBorrowDays} ngày.")
  {
    DeviceId = id;
    BorrowDays = borrowDays;
    MaxBorrowDays = maxBorrowDays;
  }
}
