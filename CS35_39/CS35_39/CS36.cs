using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CS36
{
    class Program36
    {
        public static void Run()
        {
            //Tạo tập hợp chứa các chuỗi
            ObservableCollection<string> obs = new ObservableCollection<string>();

            // Bắt sự kiện thay đổi obs
            obs.CollectionChanged += change;

            obs.Add("1");
            obs.Add("2");
            obs.Add("3");
            obs[2] = "8";

            obs.RemoveAt(1);
            obs.Clear();
        }

        // Phương thức nhận sự kiện
        private static void change(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (String s in e.NewItems)
                        Console.WriteLine($"Add : {s}");
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("Clear");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (String s in e.OldItems)
                        Console.WriteLine($"Remove : {s}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine($"Repaced {e.OldItems[0]} = {e.NewItems[0]} ");
                    break;
            }
        }
    }
}