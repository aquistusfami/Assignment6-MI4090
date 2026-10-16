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
  public int FromPeriod { get; set;} 
  public int ToPeriod { get; set; }
  public DateTime? ReturnedDate { get; private set; } 
  public bool IsReturned { get; set; } 

  public BorrowItem(TeachingDevice device, DateTime borrowedDate, DateTime dueDate) : this(device, borrowedDate, dueDate, 1, 1)
  {
  }
  public BorrowItem(TeachingDevice device, DateTime borrowedDate, DateTime dueDate, int start, int end)
  {
    if (device == null) throw new ArgumentNullException(nameof(device), "Thiết bị không được rỗng.");
    if (dueDate < borrowedDate) throw new ArgumentOutOfRangeException(nameof(dueDate), "<!> Hạn trả thiết bị không hợp lệ [Cần thiết lập sau ngày mượn]");
    if (start <= 0 || end <= 0) throw new ArgumentException("<!> Số tiết mượn phải dương");
    if (start - end < 0) throw new ArgumentException("<!> Tiết mượn không hợp lệ [Cần start >= end]");
    this.Device = device;
    this.BorrowedDate = borrowedDate;
    this.DueDate = dueDate;
    this.FromPeriod = start;
    this.ToPeriod = end;
  }

  public void Return(DateTime returnedDate)
  {
    this.ReturnedDate = returnedDate;
    this.IsReturned = true;
  } 
}

