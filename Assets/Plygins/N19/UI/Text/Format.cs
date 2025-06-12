﻿using System;

namespace N19
{
    public static class Format
    {
        /// <summary>
        /// Форматирование времени
        /// </summary>
        /// <param name="time">Значение в секундах</param>
        /// <param name="format">
        /// <br>format по умолчанию равен false</br>
        /// <br>format = true: time = 120 => 2, time = 68 => 1:08</br>
        /// <br>format = false: time = 120 => 2:00, time = 68 => 1:08</br>
        /// </param>
        /// <param name="milliseconds">
        /// <br>По умолчанию равен false</br>
        /// <br>Если равно true, то будут учитыватся только секунды и миллисекунды</br>
        /// </param>
        /// <param name="enableSuffix">
        /// <br>format по умолчанию равен false</br>
        /// <br>Если равно true, то будет в конце добавлятся суффиксное обозначение времени</br>
        /// </param>
        /// <returns>Возвращает отформатированное время</returns>
        public static string Time(float time, bool format = false, bool milliseconds = false, bool enableSuffix = false)
        {
            TimeSpan span = TimeSpan.FromSeconds(time);
            string formattedTime = default;

            if ((span.Hours == 0 && !milliseconds) || span.Hours == 0 && milliseconds && span.Minutes > 0)
                formattedTime = Minutes(span, format);
            else if (span.Hours == 0 && milliseconds && span.Minutes < 1)
                formattedTime = Mililseconds(span, format);
            else
                formattedTime = Hour(span, format);

            return enableSuffix ? formattedTime + TimeSuffixDesignation.GetSuffix(time) : formattedTime;
        }


        private static string Mililseconds(TimeSpan time, bool format = false)
        {
            if (time.Seconds < 10)
            {
                if (time.Seconds == 0 && format)
                    return time.ToString(@"ss").Replace("0", string.Empty);
                else
                    return time.ToString(@"s\.ff");
            }
            else
            {
                if (time.Milliseconds == 0 && format)
                    return time.ToString(@"ss");
                else
                    return time.ToString(@"ss\.ff");
            }
        }

        private static string Minutes(TimeSpan time, bool format = false)
        {
            if (time.Minutes < 10)
            {
                if (time.Seconds == 0 && format)
                    return time.ToString(@"mm").Replace("0", string.Empty);
                else
                    return time.ToString(@"m\:ss");
            }
            else
            {
                if (time.Seconds == 0 && format)
                    return time.ToString(@"mm");
                else
                    return time.ToString(@"mm\:ss");
            }
        }

        private static string Hour(TimeSpan time, bool format = false)
        {
            if (time.Hours < 10)
            {
                if (time.Minutes == 0 && format)
                    return time.ToString(@"hh").Replace("0", string.Empty);
                else
                    return time.ToString(@"h\:mm");
            }
            else
            {
                if (time.Minutes == 0 && format)
                    return time.ToString(@"hh");
                else
                    return time.ToString(@"hh\:mm");
            }

        }
    }
}