/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

/// <summary>
/// Lớp phiếu mượn thiết bị
/// </summary>
public class BorrowingSlip
{
    public string SlipId { get; }
    public IBorrower Borrower { get; }
    public ClassRoom TeachingRoom { get; }
    public DateTime BorrowedDate { get; }
    private readonly List<BorrowItem> items = new List<BorrowItem>();
    public IReadOnlyList<BorrowItem> Items => items.AsReadOnly();
    
    /// <summary>
    /// Khởi tạo phiếu mượn với các thông tin cần thiết
    /// </summary>
    /// <param name="id"></param>
    /// <param name="borrower"></param>
    /// <param name="room"></param>
    /// <param name="date"></param>
    public BorrowingSlip(string id, IBorrower borrower, ClassRoom room, DateTime date)
    {
        if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException("<!> Mã phiếu mượn không được trống!", nameof(id));
        if(borrower == null) throw new ArgumentNullException(nameof(borrower), "<!> Người mượn không được để trống!");
        if(room == null) throw new ArgumentNullException(nameof(room), "<!> Phòng học không được để trống!");
        this.SlipId = id;
        this.Borrower = borrower;
        this.TeachingRoom = room;
        this.BorrowedDate = date;
    }

    /// <summary>
    /// Thêm thiết bị vào phiếu mượn
    /// </summary>
    /// <param name="device"></param>
    /// <param name="borrowDays"></param>
    public void AddDevice(TeachingDevice device, int borrowDays)
    {
        ValidateBorrowing(device, borrowDays);

        var item = new BorrowItem(device, BorrowedDate, BorrowedDate.AddDays(borrowDays));

        device.MarkAsBorrowed();
        items.Add(item);
    }
    
    /// <summary>
    /// Trả thiết bị
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="returnedDate"></param>
    public void ReturnDevice(string deviceId, DateTime returnedDate)
    {
        ValidateReturned(deviceId, returnedDate);

        foreach(var item in items)
        {
            if (item.Device.DeviceId == deviceId)
            {
                item.Return(returnedDate);
            }
        }
    }

    /// <summary>
    /// Tính tổng phí phạt trả thiết bị muộn 
    /// </summary>
    /// <returns></returns>
    public decimal CalculateTotalLateFee()
    {
        decimal totalLateFee = 0.0m;
        foreach (var item in items)
        {
            if (item.ReturnedDate == null)
            {
                continue;
            }
            double totalLateDays = Math.Ceiling((item.ReturnedDate - item.DueDate).Value.TotalDays);
            if (totalLateDays > 0)
            {
                totalLateFee += 20_000m*(decimal)totalLateDays;
            }
        }
        return totalLateFee;
    }

    /// <summary>
    /// Phương thức kiểm soát đầu vào của AddDevice
    /// </summary>
    /// <param name="device"></param>
    /// <param name="borrowDays"></param>
    public void ValidateBorrowing(TeachingDevice device, int borrowDays)
    {
        if (device == null) throw new ArgumentNullException(nameof(device), "<!> Thiết bị không được để trống!");
        if (borrowDays != 1) throw new InvalidBorrowPeriodException(device.DeviceId, borrowDays, 1);
        foreach (var item in Items)
        {
            if (item.Device.DeviceId == device.DeviceId)
                throw new DuplicateDeviceException(device.DeviceId);
        }
        if (Items.Count >= Borrower.GetMaximumDevices()) throw new BorrowLimitExceededException(Borrower.BorrowerId, Borrower.GetMaximumDevices());
        if (device.Status != DeviceStatus.Available) throw new DeviceUnavailableException(device.DeviceId, device.Status);
    }

    /// <summary>
    /// Phương thức kiểm soát đầu vào của ReturnDevice
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="returnedDate"></param>
    public void ValidateReturned(string deviceId, DateTime returnedDate)
    {
        if (string.IsNullOrWhiteSpace(deviceId)) throw new ArgumentException("<!> Mã thiết bị không được trống");
        var item = items.Find(x => x.Device.DeviceId == deviceId);

        if (item == null) throw new DeviceNotInSlipException(deviceId);
        if (item.ReturnedDate != null) throw new DeviceAlreadyReturnedException(deviceId, item.Device.Status);
        if (returnedDate < item.BorrowedDate) throw new ArgumentOutOfRangeException(nameof(returnedDate), "<!> Ngày trả không được trước ngày mượn");
    }
}
