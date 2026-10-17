/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

/// <summary>
/// Lớp ngoại lệ thiết bị không trong phiếu mượn
/// </summary>
public class DeviceNotInSlipException : BorrowingException 
{
  public string DeviceId { get; }

  public DeviceNotInSlipException(string id) 
  : base($"<!> Thiết bị mã {id} không có trong phiếu mượn")
  {
    DeviceId = id;
  }
}
