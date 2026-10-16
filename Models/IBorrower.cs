/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public interface IBorrower 
{
  public string BorrowerId { get; }
  public string FullName { get; }

  public int GetMaximumDevices();
}
