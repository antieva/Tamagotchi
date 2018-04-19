using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;

namespace TamagotchiApp.Models
{
  public class Tamagotchi
  {
    private string _name;
    private int _food;
    private int _play;
    private int _sleep;
    private int _id;
    private static int _counter = 0;
    private static Timer tmr = new Timer (Tick, null, 10000, 10000);
    private static int _lastId = 0;
    private static  List<Tamagotchi> _lives = new List<Tamagotchi> {};

    public Tamagotchi (string name, int food, int play, int sleep)
    {
      _name = name;
      _food = food;
      _play = play;
      _sleep = sleep;
      _id = _lastId++;
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
    public void SetId(int id)
    {
      _id = id;
    }
    public void SetFood(int point)
    {
      _food += point;
    }
    public void DecrementFood(int point)
    {
      _food -= 1;
    }
    public void SetPlay(int point)
    {
      _play += point;
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
      int i;
      for (i = 0; i < _lives.Count; i++)
      {
        if (_lives[i]._id == id)
        {
          break;
        }
      }
      if (i != _lives.Count)
      {
        _lives.RemoveAt(i);
      }
    }
    public static Tamagotchi Find(int searchId)
   {
     return _lives.Single(t => t._id == searchId);
   }
   private static void Tick(object _)
   {
     _counter++;
     if (_counter % 3 == 0)
     {
       List<int> idsToDelete = new List<int> {};
       foreach (Tamagotchi life in _lives)
       {
         life.DecrementFood(1);
         if (life._food == 0)
         {
           idsToDelete.Add(life._id);
         }
       }
       foreach (int id in idsToDelete)
       {
         ClearLife(id);
       }
     }
   }
  }
}
