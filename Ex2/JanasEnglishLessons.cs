using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace PreAssessmentCenter.Ex2
{
    public class JanasEnglishLessons
    {
        private readonly ITestOutputHelper _output;

        public JanasEnglishLessons(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test()
        {
            /*
    
            EXAMPLE 2:
    
            Jana is a professional English teacher which offers private lessons to her pupils
            and is annoyed about having to manually plan her week schedule.

            Please help her automating this.
    
            => Write a function which takes a `IReadOnlyDictionary<string, PreferredTime>` (see below) and 
            produces a schedule like the following (text format):

            Example for Week1: 
    
              Tue 12:00-13:00 (Isabel)
              Wed 11:00-12:00 (July)
              Wed 12:15-13:15 (Rupert)
              Wed 16:30-17:30 (Patrick)
              Thu 11:00-12:00 (Ulrich)


            !! Note that Jana likes to have a break of 15 minutes between her lessons, be nice and fulfill her wish. !!

            => Code this in a test driven way (use also more examples, like `Week2`, or additional ones). Also think
               about edge / error cases.



            BONUS: You could make her even happier if you optimize her schedule by grouping the lessons together (and
            still respect the pupils' time constraints and the 15 minutes break). For example in `Week1` to start later 
            at Wed, avoiding the gap:

              Wed 14:00-15:00 (July)
              Wed 15:15-16:15 (Rupert)
              Wed 16:30-17:30 (Patrick)
    
            */

            _output.WriteLine("Week 1:");
            GetSchedule(Week1);

            _output.WriteLine("Week 2:");
            IReadOnlyDictionary<string, PreferredTime> week2 = (IReadOnlyDictionary<string, PreferredTime>)Week2;
            GetSchedule(week2);
        }

        public string[] GetSchedule(IReadOnlyDictionary<string, PreferredTime> week)
        {
            string[] schedule = new string[5];

            var sweek = week.OrderBy(key => key.Value.Weekday).ThenBy(key => key.Value.Start.Hour);
            int i = 0;

            foreach (KeyValuePair<string, PreferredTime> kvp in sweek)
            {
                string startHour = kvp.Value.Start.Hour.ToString();
                string endHour = kvp.Value.End.Hour.ToString();
                string startMin = kvp.Value.Start.Min.ToString();
                string endMin = kvp.Value.End.Min.ToString();
                string weekDay = kvp.Value.Weekday.ToString().Substring(0, 3);

                string name = "(" + kvp.Key + ")";
                if (kvp.Value.Start.Hour < 10)
                {
                    startHour += "0";
                }

                if (kvp.Value.End.Hour < 10)
                {
                    endHour += "0";
                }

                if (kvp.Value.Start.Min < 10)
                {
                    startMin += "0";
                }

                if (kvp.Value.End.Min < 10)
                {
                    endMin += "0";
                }

                string timeFrom = startHour + ":" + startMin;
                string timeTo = endHour + ":" + endMin;

                schedule[i] = weekDay + " " + timeFrom + "-" + timeTo + " " + name;

                _output.WriteLine(schedule[i]);
                i++;
            }
            _output.WriteLine("");
            return schedule;

        }

        public IReadOnlyDictionary<string, PreferredTime> Week1 =
            new Dictionary<string, PreferredTime>
            {
                {
                    "July",
                    new PreferredTime(Weekday.Wed, new TimeOfDay(11, 00), new TimeOfDay(12, 00))
                },
                {
                    "Patrick",
                    new PreferredTime(Weekday.Wed, new TimeOfDay(16, 30), new TimeOfDay(17, 30))
                },
                {
                    "Rupert",
                    new PreferredTime(Weekday.Wed, new TimeOfDay(12, 15), new TimeOfDay(13, 15))
                },
                {
                    "Isabel",
                    new PreferredTime(Weekday.Tue, new TimeOfDay(12, 00), new TimeOfDay(13, 00))
                },
                {
                    "Ulrich",
                    new PreferredTime(Weekday.Thu, new TimeOfDay(11, 00), new TimeOfDay(12, 00))
                },
            };

        public IDictionary<string, PreferredTime> Week2 =
            new Dictionary<string, PreferredTime>
            {
                {
                    "Andreas",
                    new PreferredTime(Weekday.Thu, new TimeOfDay(16, 00), new TimeOfDay(20, 00))
                },
                {
                    "Isabel",
                    new PreferredTime(Weekday.Mon, new TimeOfDay(15, 30), new TimeOfDay(20, 00))
                },
                {
                    "July",
                    new PreferredTime(Weekday.Thu, new TimeOfDay(8, 00), new TimeOfDay(12, 00))
                },
                {
                    "Patrick",
                    new PreferredTime(Weekday.Thu, new TimeOfDay(8, 30), new TimeOfDay(11, 00))
                },
                {
                    "Ulrich",
                    new PreferredTime(Weekday.Thu, new TimeOfDay(15, 00), new TimeOfDay(21, 00))
                },
            };

        public class PreferredTime
        {
            public Weekday Weekday { get; }
            public TimeOfDay Start { get; }
            public TimeOfDay End { get; }

            public PreferredTime(Weekday weekday, TimeOfDay start, TimeOfDay end)
            {
                Weekday = weekday;
                Start = start;
                End = end;
            }
        }

        public class TimeOfDay
        {
            public int Hour { get; }
            public int Min { get; }

            public TimeOfDay(int hour, int min)
            {
                Hour = hour;
                Min = min;
            }
        }

        public enum Weekday
        {
            Mon,
            Tue,
            Wed,
            Thu,
            Fri,
        }
    }
}