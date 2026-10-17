/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

/// <summary>
/// Lớp thiết bị mượn
/// </summary>
public class BorrowItem
{
  public TeachingDevice Device { get; } 
  public DateTime BorrowedDate { get; } 
  public DateTime DueDate { get; }
  public int FromPeriod { get; set;} 
  public int ToPeriod { get; set; }
  public DateTime? ReturnedDate { get; private set; } 
  public bool IsReturned => ReturnedDate != null;

  /// <summary>
  /// Khởi tạo thiết bị mượn mặc định mượn 1 tiết 
  /// </summary>
  /// <param name="device"></param>
  /// <param name="borrowedDate"></param>
  /// <param name="dueDate"></param>
  public BorrowItem(TeachingDevice device, DateTime borrowedDate, DateTime dueDate) : this(device, borrowedDate, dueDate, 1, 1)
  {
  }

  /// <summary>
  /// Khởi tạo thiết bị mượn nhiều tiết học 
  /// </summary>
  /// <param name="device"></param>
  /// <param name="borrowedDate"></param>
  /// <param name="dueDate"></param>
  /// <param name="start"></param>
  /// <param name="end"></param>
  public BorrowItem(TeachingDevice device, DateTime borrowedDate, DateTime dueDate, int start, int end)
  {
    if (device == null) throw new ArgumentNullException(nameof(device), "Thiết bị không được rỗng.");
    if (dueDate < borrowedDate) throw new ArgumentOutOfRangeException(nameof(dueDate), "<!> Hạn trả thiết bị không hợp lệ [Cần thiết lập sau ngày mượn]");
    if (start <= 0 || end <= 0) throw new ArgumentException("<!> Số tiết mượn phải dương");
    if (start - end > 0) throw new ArgumentException("<!> Tiết mượn không hợp lệ [Cần start <= end]");
    this.Device = device;
    this.BorrowedDate = borrowedDate;
    this.DueDate = dueDate;
    this.FromPeriod = start;
    this.ToPeriod = end;
  }
  
  /// <summary>
  /// Phương thức trả thiết bị
  /// </summary>
  /// <param name="returnedDate">Ngày trả</param>
  public void Return(DateTime returnedDate)
  {
    if(IsReturned) throw new InvalidOperationException("<!> Thiết bị đã được trả");
    if(returnedDate < BorrowedDate) throw new ArgumentOutOfRangeException(nameof(returnedDate),"<!> Thời điểm trả đồ không hợp lệ [Cần trả sau ngày mượn]");
    if (Device.Status != DeviceStatus.Borrowed) throw new InvalidOperationException($"<!> Thiết bị không ở trạng thái đang được mượn.");
    this.Device.MarkAsAvailable();
    this.ReturnedDate = returnedDate;
  } 
}

