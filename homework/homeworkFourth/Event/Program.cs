using System;

/*
 使用事件机制，模拟实现一个闹钟功能。
闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。
在闹钟走时时或者响铃时，在控制台显示提示信息。
 */


namespace Event
{
    public delegate void AlarmClockEvent(System.DateTime time);

    public class AlarmClock
    {
        private System.DateTime time;
        public System.DateTime Time
        {
            get { return time; }
            set { time = System.DateTime.Now; }
        } 

        public System.DateTime setAlarmClock(int year, int month, int day, int hour, int minute, int second)
        {
            return System.DateTime.Parse($"{year}-{month}-{day} {hour}:{minute}:{second}");
        }

        public event  AlarmClockEvent alarmClockEvent = null;
        public void run(System.DateTime alarmTime)
        {
            while( alarmClockEvent != null )
            {                



                Thread.Sleep(1000);
                TimeSpan ts = System.DateTime.Now - alarmTime;

                alarmClockEvent(alarmTime);

                if (ts.Seconds >= 0 && ts.Seconds <= 1)
                {
                    break; // 退出循环
                }


            }
        }


    }


    internal class Program
    {
        static void Tick(System.DateTime alarmTime)
        {
            Console.WriteLine($"滴答滴答，现在是时间为{System.DateTime.Now}");

        }

        //static void Alarm(System.DateTime alarmTime)
        //{
        //    if (System.DateTime.Now == alarmTime)
        //    {
        //        Console.WriteLine($"闹钟到啦，设定的时间{alarmTime}到啦");
        //    }
        //}


        static void Alarm(System.DateTime alarmTime)
        {
            TimeSpan ts = System.DateTime.Now - alarmTime;
            if (ts.Seconds >= 0 && ts.Seconds <= 1)
            {
                Console.WriteLine($"闹钟到啦，设定的时间{alarmTime}到啦");
            }
        }



        static void Main(string[] args)
        {
            AlarmClock alarmClock = new AlarmClock();

            System.DateTime alarmTime = alarmClock.setAlarmClock(2023, 3, 19, 22, 4, 50);
            Console.WriteLine($"闹钟时间为：{alarmTime}");

            alarmClock.alarmClockEvent += Tick;
            alarmClock.alarmClockEvent += Alarm;

            alarmClock.run(alarmTime);





        }
    }
}