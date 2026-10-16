namespace Assignment6_MI4090;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Lecturer lt1 = new Lecturer("LT01", "Nguyễn Văn Thế");
            Console.WriteLine($"[Console] Tạo thành công giảng viên {lt1.FullName}!");
            ProjectorRemote pr1 = new ProjectorRemote("PR01", "Điều khiển máy chiếu Casio", 2022, 500_000m, DeviceStatus.Available);
            Console.WriteLine($"[Console] Tạo thành công {pr1.DeviceName}!");
            ACRemote acr1 = new ACRemote("ACR01", "Điều khiển điều hòa Daikin", 2024, 350_000m, DeviceStatus.Available);
            Console.WriteLine($"[Console] Tạo thành công {acr1.DeviceName}!");
            Micro mic1 = new Micro("MIC01", "Micro không dây hãng Unknown", 2022, 700_000m, DeviceStatus.Available);
            Console.WriteLine($"[Console] Tạo thành công {mic1.DeviceName}!");
            ClassRoom cr1 = new ClassRoom("CR007", "D5-102", 3);
            List<BorrowItem> items = new List<BorrowItem>();
            BorrowingSlip bs1 = new BorrowingSlip("BS001", lt1, cr1, DateTime.Parse("2026-10-10"), items);
            Console.WriteLine($"[Console] Tạo thành công phiếu mượn {bs1.SlipId} cho phòng học {cr1.ClassRoomName} bởi giảng viên {lt1.FullName}!");
            bs1.AddDevice(pr1, 1);
            Console.WriteLine($"[Console] Thêm thành công {pr1.DeviceName}, thời gian mượn 1 ngày!");
            bs1.AddDevice(mic1, 1);
            Console.WriteLine($"[Console] Thêm thành công {mic1.DeviceName}, thời gian mượn 1 ngày!");
            bs1.AddDevice(acr1, 1);
            Console.WriteLine($"[Console] Thêm thành công {acr1.DeviceName}, thời gian mượn 1 ngày!");

            bs1.ReturnDevice("PR01", DateTime.Parse("2026-10-11"));
            bs1.ReturnDevice("MIC01", DateTime.Parse("2026-10-13"));
            Console.WriteLine($"---------------------------------------");
            Console.WriteLine($"Các thiết bị trả muộn, chưa trả của phòng {cr1.ClassRoomName} bởi gv {lt1.FullName}");
            foreach (var item in bs1.Items)
            {
                if (item.ReturnedDate == null)
                {
                    Console.WriteLine($"(!) Thiết bị {item.Device.DeviceName} - mã {item.Device.DeviceId} chưa được trả");
                    continue;
                }
                if (item.ReturnedDate.Value > item.DueDate)
                {
                    int lateDays = (item.ReturnedDate.Value - item.DueDate).Days;
                    Console.WriteLine($"(!) Thiết bị {item.Device.DeviceName} - mã: {item.Device.DeviceId} - trả muộn {lateDays} ngày");
                }
            }   
        }
        catch (Exception ex)
        {
            Console.WriteLine($"<Console> Lỗi: {ex}");
        }
        finally
        {
            Console.WriteLine();
            Console.WriteLine($"=> [Console] Hoàn thành luồng thành công!");
        }
    }
}
