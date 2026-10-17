/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

/// <summary>
/// Lớp trợ giảng thực thi IBorrower
/// </summary>
public class TeachingAssistant : IBorrower 
{
  public string BorrowerId { get; }
  public string FullName { get; }

  public TeachingAssistant (string id, string name)
  {
    this.BorrowerId = id;
    this.FullName = name;
  }
  
  public int GetMaximumDevices()
  {
    return 2;
  }
}
