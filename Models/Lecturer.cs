/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class Lecturer : IBorrower 
{
  public string BorrowId { get; }
  public string FullName { get; }

  public Lecturer (string id, string name)
  {
    this.BorrowId = id;
    this.FullName = name;
  }

  public int GetMaximumDevices()
  {
    return 3;
  }
}
