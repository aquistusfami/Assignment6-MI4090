/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class InvalidBorrowPeriodException : BorrowingException
{
  public string DeviceId { get; }
  public int fromPeriod { get; }
  public int toPeriod { get; }

  public InvalidBorrowPeriodException(string id, int start, int end) 
  : base($"<!> Thiết bị mã {id} cần có thời gian mượn hợp lệ. {start} , {end} đang là số âm.")
  {
    DeviceId = id;
    fromPeriod = start;
    toPeriod = end;
  }
}
