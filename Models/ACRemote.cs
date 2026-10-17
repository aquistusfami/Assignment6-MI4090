/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;
/// <summary>
/// Lớp điều khiển điều hòa kế thừa TeachingDevice
/// </summary>
public class ACRemote : TeachingDevice
{
  public ACRemote(string id, string name, int usedYear, decimal price, DeviceStatus status) : base(id,name,usedYear,price,status)
  {

  }

  public override decimal CalculateAnnualMaintenanceCost()
  {
    return 0.4m*Price;
  }
}
