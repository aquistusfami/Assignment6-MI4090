/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class DeviceAlreadyReturnedException : BorrowingException 
{
  public string DeviceId { get; }
  public DeviceStatus CurrentStatus { get; }

  public DeviceAlreadyReturnedException(string id, DeviceStatus currStatus) 
  : base($"<!> Thiết bị mã {id} đã được trả và đang ở trạng thái {currStatus}")
  {
    DeviceId = id;
    CurrentStatus = currStatus;
  }
}
