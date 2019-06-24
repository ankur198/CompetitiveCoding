using System;
using System.Collections.Generic;
using System.Text;

namespace Date_Time
{
    public class MyDateTime
    {
        public List<int> RemainingDigits { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }

        public bool isAddable(string number)
        {
            var tRem = new List<int>(RemainingDigits.ToArray());

            var s = number;
            foreach (var item in s.ToCharArray())
            {
                var n = int.Parse(item.ToString());
                if (!tRem.Contains(n))
                {
                    return false;
                }
                else
                {
                    tRem.Remove(n);
                }
            }
            return true;
        }

        public void Remove(string number)
        {
            foreach (var item in number.ToCharArray())
            {
                RemainingDigits.Remove(int.Parse(item.ToString()));
            }
        }

        public MyDateTime MakeCopy()
        {
            var newDate = new MyDateTime() { Date = Date, Hour = Hour, Minute = Minute, Month = Month };
            newDate.RemainingDigits = new List<int>(RemainingDigits.ToArray());
            return newDate;
        }
    }


    public class builder
    {
        public List<MyDateTime> selectedDates = new List<MyDateTime>();
        public readonly int[] allDigits;

        public builder(int[] digits)
        {
            allDigits = digits;
        }

        public void start()
        {
            addMonth(new MyDateTime() { RemainingDigits = new List<int>(allDigits) });
        }

        void addMonth(MyDateTime parent)
        {
            var maxMonth = 12;
            for (int i = 0; i < maxMonth; i++)
            {
                var currentMonth = (maxMonth - i).ToString("D2");
                if (parent.isAddable(currentMonth) && selectedDates.Count < 1)
                {
                    var child = parent.MakeCopy();
                    child.Month = currentMonth;
                    child.Remove(currentMonth);
                    addDate(child);
                }
            }
        }

        private void addDate(MyDateTime parent)
        {
            var maxDate = 31;
            var smallMonths = new List<int>(new int[] { 4, 6, 9, 11 });
            if (parent.Month == "02")
            {
                maxDate = 28;
            }
            else if (smallMonths.Contains(int.Parse(parent.Month)))
            {
                maxDate = 30;
            }

            for (int i = 0; i < maxDate; i++)
            {
                var currentDate = (maxDate - i).ToString("D2");
                if (parent.isAddable(currentDate) && selectedDates.Count < 1)
                {
                    var child = parent.MakeCopy();
                    child.Date = currentDate;
                    child.Remove(currentDate);
                    addHour(child);
                }
            }
        }

        private void addHour(MyDateTime parent)
        {
            var maxHour = 23;
            for (int i = 0; i < maxHour; i++)
            {
                var currentHour = (maxHour - i).ToString("D2");
                if (parent.isAddable(currentHour) && selectedDates.Count < 1)
                {
                    var child = parent.MakeCopy();
                    child.Hour = currentHour;
                    child.Remove(currentHour);
                    addMinute(child);
                }
            }
        }

        private void addMinute(MyDateTime parent)
        {
            var maxMin = 59;
            for (int i = 0; i < maxMin; i++)
            {
                var currentMin = (maxMin - i).ToString("D2");

                if (parent.isAddable(currentMin) && selectedDates.Count < 1)
                {
                    var child = parent.MakeCopy();
                    child.Minute = currentMin;
                    child.Remove(currentMin);
                    selectedDates.Add(child);
                }
            }
        }
    }
}
