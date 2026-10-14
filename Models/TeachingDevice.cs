/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public enum DeviceStatus 
{
  Active,
  Borrowed,
  UnderMaintenance
}

/// <summary>
/// Lớp trừu tượng TeachingDevice đại diện cho các thiết bị trong phòng học
/// </summary>
public abstract class TeachingDevice 
{
  public string DeviceId { get; private set; }
  public string DeviceName { get; private set; }
  public int UsedYear { get; private set; }
  public decimal Price { get; private set; }
  public DeviceStatus Status { get; private set; }
  
  /// <summary>
  /// Constructor base cho các lớp sau này 
  /// </summary>
  /// <param name="id">Mã thiết bị</param>
  /// <param name="name">Tên thiết bị</param>
  /// <param name="usedYear">Năm đưa vào sử dụng</param>
  /// <param name="price">Giá mua</param>
  /// <param name="status">Trạng thái thiết bị</param>
  public TeachingDevice(string id, string name, int usedYear, decimal price, DeviceStatus status)
  {
    if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mã thiết bị không được trống.", nameof(id));
    if(usedYear > DateTime.Now.Year) throw new ArgumentOutOfRangeException(nameof(usedYear),"Năm đưa vào sử dụng không lớn hơn năm hiện tại (2026).");
    if(price <= 0) throw new ArgumentOutOfRangeException(nameof(price), "Giá mua không được <= 0.");
    this.DeviceId = id;
    this.DeviceName = name;
    this.UsedYear = usedYear;
    this.Price = price;
    this.Status = status;
  }
  /// <summary>
  /// Abstract method bắt các lớp con phải thiết lập
  /// </summary>
  /// <returns>Tiền bảo dưỡng hằng năm của thiết bị</returns>
  public abstract decimal CalculateAnnualMaintenanceCost();

  /// <summary>
  /// Method biểu diễn thông tin Device dạng chuỗi
  /// </summary>
  /// <returns>Thông tin thiết bị</returns>
  public override string ToString()
  {
    return $"(+) Mã thiết bị: {DeviceId}" + Environment.NewLine +
    $"(+) Tên thiết bị: {DeviceName}" + Environment.NewLine +
    $"(+) Năm đưa vào sử dụng: {UsedYear}" + Environment.NewLine +
    $"(+) Giá mua: {Price:N0} VND" + Environment.NewLine +
    $"(+) Trạng thái hoạt động: {Status}";
  }
}
