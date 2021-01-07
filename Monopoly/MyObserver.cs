using System;

public class MyObserver : Observer
{
  public MyObserver(string message)
  {
    this.message = message;
  }

  public override void update()
  {
    Console.WriteLine(message);
  }

  private string message;
}