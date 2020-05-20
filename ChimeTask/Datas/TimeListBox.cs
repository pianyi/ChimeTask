using Microsoft.SqlServer.Server;
using System;

namespace chimeTask.Datas
{
    /// <summary>
    /// ListBoxに表示するデータを設定します。
    /// </summary>
    public class TimeListBox
    {
        /// <summary>
        /// 時:分 のフォーマット
        /// </summary>
        public const String FormatHHMM = "{0:00}:{1:00}";

        /// <summary>
        /// 時間を取得・設定します。
        /// </summary>
        public int Hour
        {
            get;
            set;
        }

        /// <summary>
        /// 分を取得・設定します。
        /// </summary>
        public int Minute
        {
            get;
            set;
        }

        /// <summary>
        /// 実行済みかどうかを判断します。
        /// </summary>
        public Boolean Executed
        {
            get;
            set;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TimeListBox()
        {
            Hour = 0;
            Minute = 0;
            Executed = false;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="hour">時間</param>
        /// <param name="minute">分</param>
        public TimeListBox(int hour, int minute)
            : base()
        {
            Hour = hour;
            Minute = minute;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="time">時:分 フォーマットの文字列</param>
        public TimeListBox(String time)
            : base()
        {
            if (time != null)
            {
                String[] tmp = time.Split(':');
                Hour = int.Parse(tmp[0]);
                Minute = int.Parse(tmp[1]);
            }
        }

        /// <summary>
        /// 文字列を取得します
        /// </summary>
        /// <returns>表示文字列</returns>
        public override String ToString()
        {
            return String.Format(FormatHHMM, Hour, Minute);
        }
    }
}
