/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class TeachingAssistant : IBorrower 
{
  public string BorrowId { get; }
  public string FullName { get; }

  public TeachingAssistant (string id, string name)
  {
    this.BorrowId = id;
    this.FullName = name;
  }
  
  public int GetMaximumDevices()
  {
    return 2;
  }
}
