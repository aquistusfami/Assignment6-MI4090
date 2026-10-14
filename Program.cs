namespace Assignment6_MI4090;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ACRemote ac1 = new ACRemote("AC01", "Điều khiển Daikin", 2022, 200_000m, DeviceStatus.Borrowed);
            Console.WriteLine(ac1);
        }
        catch (DeviceUnavailableException ex) 
        {
            Console.WriteLine($"<Error>: {ex.Message}");
        }
    }
}
