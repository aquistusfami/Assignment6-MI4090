/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class DuplicateDeviceException : BorrowingException
{
    string DeviceId;

    public DuplicateDeviceException(string id) : base("<!> Thiết bị mã {id} đã có trong phiếu mượn")
    {
        DeviceId = id;
    }
}