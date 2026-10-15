/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class BorrowItem
{
  public TeachingDevice Device { get; } 
  public DateTime BorrowedDate { get; } 
  public DateTime DueDate { get; }
  public int fromPeriod { get; set;} 
  public int toPeriod { get; set; }
  public DateTime? ReturnedDate { get; private set; } 
  public bool IsReturned { get; set; } 

  public BorrowItem(TeachingDevice device, DateTime borrowedDate, DateTime dueDate, int start, int end)
  {
    if (device == null) throw new ArgumentNullException(nameof(device), "Thiết bị không được rỗng.");
    if (dueDate < borrowedDate) throw new ArgumentOutOfRangeException(nameof(dueDate), "<!> Hạn trả thiết bị không hợp lệ [Cần thiết lập sau ngày mượn]");
    if (start < 0 || end < 0) throw new InvalidBorrowPeriodException(device.DeviceId, start, end);
    if (start - end < 0) throw new ArgumentException("<!> Tiết mượn không hợp lệ [Cần start > end]");
    this.Device = device;
    this.BorrowedDate = borrowedDate;
    this.DueDate = dueDate;
    this.fromPeriod = start;
    this.toPeriod = end;
  }

  public void Return(DateTime returnedDate)
  {
    if(returnedDate < BorrowedDate) throw new ArgumentOutOfRangeException(nameof(returnedDate),"<!> Thời điểm trả đồ không hợp lệ [Cần trả sau ngày mượn]");
    if(IsReturned) throw new InvalidOperationException("<!> Thiết bị đã được trả");
    this.ReturnedDate = returnedDate;
    this.IsReturned = true;
  } 
}

