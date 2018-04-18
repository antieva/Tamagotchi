using System.Collections.Generic;
using System;
namespace TamagotchiApp.Models
{
  public class Tamagotchi
  {
    private string _name;
    private int _food;
    private int _play;
    private int _sleep;
    private int _id;
    private static  List<Tamagotchi> _lives = new List<Tamagotchi> {};

    public Tamagotchi (string name, int food, int play, int sleep)
    {
      _name = name;
      _food = food;
      _play = play;
      _sleep = sleep;
      _id = _lives.Count + 1;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetFood()
    {
      return _food;
    }
    public int GetPlay()
    {
      return _play;
    }
    public int GetSleep()
    {
      return _sleep;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetFood(int point)
    {
      _food +=point;
    }
    public void SetPlay(int point)
    {
      _play +=point;
    }
    public void SetSleep(int point)
    {
      _sleep += point;
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
    public static void ClearLife(int id)
    {
      _lives.RemoveAt(id);
    }
    public static Tamagotchi Find(int searchId)
   {
     return _lives[searchId-1];
   }
  }
}
