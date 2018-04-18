using System.Collections.Generic;
using System;
namespace Tamagotchi.Models
{
  public class Tamagotchi
  {
    private string _name;
    private int _food;
    private int _play;
    private int _sleep;
    private static  List<Tamagotchi> _lives = new List<Tamagotchi> {};

    public Tamagotchi (string name, int food, int play, int sleep)
    {
      _name = name;
      _food = food;
      _play = play;
      _sleep = sleep;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetFood();
    {
      return _food;
    }
    public int GetPlay();
    {
      return _play;
    }
    public int GetSleep();
    {
      return _sleep;
    }
    public void SetFood(int food)
    {
      _food = food;
    }
    public void SetPlay(int play)
    {
      _play = play;
    }
    public void SetSleep(int sleep)
    {
      _sleep = sleep;
    }
    public static List<Tamagotchi> GetAll()
    {
      return _lives;
    }
    public void Save()
    {
      _lives.Add(this);
    }
    public static void ClearAll()
    {
      _lives.Clear();
    }
  }  
}
