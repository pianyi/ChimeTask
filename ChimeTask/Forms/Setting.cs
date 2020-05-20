using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chimeTask.Properties;
using chimeTask.Datas;
using System.Reflection;
using chimeTask.Ctrls;
using Microsoft.Win32;

namespace chimeTask.Forms
{
    /// <summary>
    /// デフォルト音源：
    /// https://otologic.jp/free/se/school_bell01.html
    /// アイコン：
    /// https://www.silhouette-illust.com/illust/32746
    /// </summary>
    public partial class Setting : Form
    {
        /// <summary>
        /// システム終了フラグ
        /// </summary>
        private Boolean canExit = false;

        /// <summary>
        /// 音楽再生クラス
        /// </summary>
        private Audio audio = null;

        /// <summary>
        /// スタートアップの登録・解除に必要な動作を行います
        /// </summary>
        private SettingStartUp startupData = new SettingStartUp();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Setting()
        {
            InitializeComponent();

            notifyIcon.Icon = Resources.chime;
            Icon = Resources.chime;

            audio = new Audio();
            audio.BeforePlayMusic += Audio_BeforePlayMusic;
            audio.AfterStopMusic += Audio_AfterStopMusic;

            SystemEvents.SessionEnding += new SessionEndingEventHandler(SystemEvents_SessionEnding);

            // タスクバーには表示する
            notifyIcon.Visible = true;
        }

        /// <summary>
        /// 音楽再生前に動作します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Audio_BeforePlayMusic(object sender, EventArgs e)
        {
            buttonTestPlay.Text = "停止";
        }

        /// <summary>
        /// 音楽停止後に動作します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Audio_AfterStopMusic(object sender, EventArgs e)
        {
            buttonTestPlay.Text = "再生";
        }

        /// <summary>
        /// ログオフ、シャットダウンしようとしている時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            SystemEnd();
        }


        private void Setting_Shown(object sender, EventArgs e)
        {
            // スタートアップ有無
            if (File.Exists(startupData.ShortcutFilePath))
            {
                buttonStartUp.Text = "スタートアップ解除";
            }
            else
            {
                buttonStartUp.Text = "スタートアップ登録";
            }
        }

        /// <summary>
        /// 画面が閉じる前に動作します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            if (!canExit)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// タスクトレイがダブルクリックされた場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            toolStripMenuItemSetting_Click(sender, e);
        }

        /// <summary>
        /// 設定ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSetting_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            Show();
        }

        /// <summary>
        /// 終了ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            SystemEnd();
        }

        /// <summary>
        /// スタートアップ登録・解除ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonbuttonStartUp_Click(object sender, EventArgs e)
        {
            // スタートアップ有無
            if (!File.Exists(startupData.ShortcutFilePath))
            {
                try
                {
                    startupData.CreateShortCut();
                    // スタートアップフォルダに登録されたか確認
                    if (File.Exists(startupData.ShortcutFilePath))
                    {
                        MessageBox.Show(
                            "スタートアップに登録しました。\n\n" + startupData.ShortcutFilePath,
                            startupData.ApplicationTitle,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        buttonStartUp.Text = "スタートアップ解除";
                    }
                    else
                    {
                        MessageBox.Show(
                            "スタートアップへの登録に失敗しました。\n\n" + startupData.ShortcutFilePath,
                            startupData.ApplicationTitle,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "スタートアップへの登録に失敗しました。\n\n" + ex.Message,
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                try
                {
                    File.Delete(startupData.ShortcutFilePath);
                    buttonStartUp.Text = "スタートアップ登録";
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "スタートアップへの削除に失敗しました。\n\n" + startupData.ShortcutFilePath,
                        startupData.ApplicationTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }
    
        /// <summary>
        /// クリアボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPlayFile.Text = String.Empty;
        }

        /// <summary>
        /// 再生ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTestPlay_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            if (audio.IsPlaying)
            {
                audio.Stop();
            }
            else
            {
                audio.Start();
            }
        }

        /// <summary>
        /// ファイル参照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectPalyFile_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = textBoxPlayFile.Text;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPlayFile.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// 再生ファイルボックスのフォーカス変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPlayFile_Leave(object sender, EventArgs e)
        {
            try {

                TextBox text = sender as TextBox;

                if (text != null)
                {
                    audio.ChangePlayFile(text.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this,
                                "エラー",
                                "指定ファイルの読み込みに失敗しました。",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// テキスト変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPlayFile_TextChanged(object sender, EventArgs e)
        {
            try {

                TextBox text = sender as TextBox;

                if (text != null)
                {
                    audio.ChangePlayFile(text.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this,
                                "エラー",
                                "指定ファイルの読み込みに失敗しました。",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// リストをダブルクリックされた場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxTimer_DoubleClick(object sender, EventArgs e)
        {
            TimeListBox tmp = listBoxTimer.SelectedItem as TimeListBox;

            if (tmp != null)
            {
                numericUpDownHour.Value = tmp.Hour;
                numericUpDownMinute.Value = tmp.Minute;
            }
        }

        /// <summary>
        /// 音を鳴らす時間の追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            String timeString = String.Format("{0:00}:{1:00}",
                                        numericUpDownHour.Value,
                                        numericUpDownMinute.Value);

            TimeListBox time = new TimeListBox(timeString);
            DateTime tmp;

            // データの存在チェック
            TimeListBox data = listBoxTimer.Items.Cast<TimeListBox>().ToList().Find(m => m.ToString() == time.ToString());
            if (DateTime.TryParse(time.ToString(), out tmp) && data == null)
            {
                listBoxTimer.Items.Add(time);
            }
        }

        /// <summary>
        /// 選択された時間を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            for (int i = listBoxTimer.SelectedItems.Count; 0 < i; i--)
            {
                var item = listBoxTimer.SelectedItems[i - 1];
                listBoxTimer.Items.Remove(item);
            }
        }

        /// <summary>
        /// 時間コントロールが選択された場合の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            NumericUpDown ctrl = sender as NumericUpDown;

            if (ctrl != null)
            {
                ctrl.Select(0, ctrl.Value.ToString().Length);
            }
        }

        /// <summary>
        /// 指定秒間隔で動作します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            if (timer != null)
            {
                timer.Stop();
            }

            try
            {
                DateTime now = DateTime.Now;
                String nowString = String.Format(TimeListBox.FormatHHMM, now.Hour, now.Minute);

                foreach (TimeListBox tmp in listBoxTimer.Items)
                {
                    if (nowString == tmp.ToString() && !tmp.Executed)
                    {
                        audio.Stop();
                        audio.Start();
                        tmp.Executed = true;
                    }
                }
            }
            finally
            {
                if (timer != null)
                {
                    timer.Start();
                }
            }
        }

        /// <summary>
        /// 起動時の初期化を行います
        /// </summary>
        public void Initialize()
        {
            textBoxPlayFile.Text = Settings.Default.PlayFilePath;
            foreach (String tmp in Settings.Default.TimeList.Split(','))
            {
                if (tmp != String.Empty)
                {
                    TimeListBox date = new TimeListBox(tmp);
                    listBoxTimer.Items.Add(date);
                }
            }

            timer.Start();

            if (listBoxTimer.Items.Count <= 0)
            {
                Show();
            }
        }

        /// <summary>
        /// システム終了処理
        /// </summary>
        public void SystemEnd()
        {
            // 動作中の者を停止
            timer.Stop();
            audio.Stop();
            audio.Dispose();
            audio = null;

            // 設定情報を保存
            Settings.Default.PlayFilePath = textBoxPlayFile.Text;
            Settings.Default.TimeList = String.Empty;
            foreach (TimeListBox tmp in listBoxTimer.Items)
            {
                Settings.Default.TimeList += tmp.ToString() + ",";
            }

            Settings.Default.Save();

            // 終了時に解除yしておく
            SystemEvents.SessionEnding -= new SessionEndingEventHandler(SystemEvents_SessionEnding);

            // 終了
            canExit = true;
            Close();
            Application.Exit();
        }
    }
}
