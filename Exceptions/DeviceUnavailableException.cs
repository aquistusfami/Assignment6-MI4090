/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

/// <summary>
/// Lớp ngoại lệ thiết bị không ở trạng thái sẵn sàng được mượn
/// </summary>
public class DeviceUnavailableException : BorrowingException 
{
  public string DeviceId { get; }
  public DeviceStatus CurrentStatus { get; }

  public DeviceUnavailableException(string id, DeviceStatus currStatus) 
  : base($"<!> Thiết bị mã {id} đang không ở trạng thái Available")
  {
    DeviceId = id;
    CurrentStatus = currStatus;
  }
}
