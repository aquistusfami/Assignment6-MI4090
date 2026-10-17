/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

/// <summary>
/// Lớp micro dẫn xuất từ TeachingDevice
/// </summary>
public class Micro : TeachingDevice
{
  public Micro(string id, string name, int usedYear, decimal price, DeviceStatus status) : base(id,name,usedYear,price,status)
  {

  }

  public override decimal CalculateAnnualMaintenanceCost()
  {
    return 0.5m*Price;
  }
}
