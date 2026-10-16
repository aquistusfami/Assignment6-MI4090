/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class BorrowingSlip
{
    public string SlipId { get; }
    public IBorrower Borrower { get; }
    public ClassRoom TeachingRoom { get; }
    public DateTime BorrowedDate { get; }
    private readonly List<BorrowItem> items = new List<BorrowItem>();
    public IReadOnlyList<BorrowItem> Items => items;

    public BorrowingSlip(string id, IBorrower borrower, ClassRoom room, DateTime date, IReadOnlyList<BorrowItem> items)
    {
        if(string.IsNullOrWhiteSpace(id)) throw new ArgumentException("<!> Mã phiếu mượn không được trống!", nameof(id));
        if(borrower == null) throw new ArgumentNullException(nameof(borrower), "<!> Người mượn không được để trống!");
        if(room == null) throw new ArgumentNullException(nameof(room), "<!> Phòng học không được để trống!");
        this.SlipId = id;
        this.Borrower = borrower;
        this.TeachingRoom = room;
        this.BorrowedDate = date;
        this.items = new List<BorrowItem>(items);
    }

    public void AddDevice(TeachingDevice device, int borrowDays)
    {
        ValidateBorrowing(device, borrowDays);

        var item = new BorrowItem(device, BorrowedDate, BorrowedDate.AddDays(borrowDays));

        device.MarkAsBorrowed();
        items.Add(item);
    }

    public void ReturnDevice(string deviceId, DateTime returnedDate)
    {
        ValidateReturned(deviceId, returnedDate);

        foreach(var item in items)
        {
            if (item.Device.DeviceId == deviceId)
            {
                item.Return(returnedDate);
                item.Device.MarkAsAvailable();
            }
        }
    }

    // public decimal CalculateTotalLateFee()
    // {
        
    // }

    public void ValidateBorrowing(TeachingDevice device, int borrowDays)
    {
        if (device == null) throw new ArgumentNullException(nameof(device), "<!> Thiết bị không được để trống!");
        if (borrowDays <= 0) throw new InvalidBorrowPeriodException(device.DeviceId, borrowDays, 1);
        foreach (var item in Items)
        {
            if (item.Device.DeviceId == device.DeviceId)
                throw new DuplicateDeviceException(device.DeviceId);
        }
        if (Items.Count >= Borrower.GetMaximumDevices()) throw new BorrowLimitExceededException(Borrower.BorrowerId, Borrower.GetMaximumDevices());
        if (device.Status != DeviceStatus.Available) throw new DeviceUnavailableException(device.DeviceId, device.Status);
    }

    public void ValidateReturned(string deviceId, DateTime returnedDate)
    {
        if (string.IsNullOrWhiteSpace(deviceId)) throw new ArgumentException("<!> Mã thiết bị không được trống");
        foreach (var item in items)
        {
            if (item.Device.DeviceId != deviceId) throw new DeviceNotInSlipException(deviceId);
            if (item.Device.DeviceId == deviceId && item.Device.Status == DeviceStatus.Available)
            throw new DeviceAlreadyReturnedException(deviceId, DeviceStatus.Available);
        }
        if (returnedDate < BorrowedDate) throw new ArgumentOutOfRangeException(nameof(returnedDate), "<!> Ngày trả cần phải trước ngày mượn");
    }
}