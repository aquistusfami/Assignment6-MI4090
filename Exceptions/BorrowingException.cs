/****************/
// 202418988
// Nguyễn Văn Thế
/****************/
using System;

namespace Assignment6_MI4090;

public class BorrowingException : Exception
{
  public BorrowingException(string message) : base(message)
  {

  }

  public BorrowingException(string message, Exception innerException)
  : base(message, innerException)
  {
    
  }
}
