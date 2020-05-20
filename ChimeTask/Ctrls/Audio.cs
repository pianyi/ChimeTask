using chimeTask.Properties;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chimeTask.Ctrls
{
    /// <summary>
    /// 音源コントロールクラス
    /// </summary>
    public class Audio
    {
        /// <summary>
        /// 再生プレイヤー
        /// </summary>
        private WaveOut player = null;

        /// <summary>
        /// 音源ファイルストリーム
        /// </summary>
        private Stream playSteram = null;

        /// <summary>
        /// 再生中フラグ
        /// </summary>
        public Boolean IsPlaying
        {
            get;
            private set;
        } = false;

        /// <summary>
        /// 音楽の動作デリゲート
        /// </summary>
        /// <param name="sender">オーディオクラス</param>
        /// <param name="e">イベントクラス</param>
        public delegate void PlayDelegate(Object sender, EventArgs e);
        /// <summary>
        /// 音楽が開始前に動作します
        /// </summary>
        public event PlayDelegate BeforePlayMusic;
        /// <summary>
        /// 音楽が開始後に動作します
        /// </summary>
        public event PlayDelegate AfterPlayMusic;
        /// <summary>
        /// 音楽が停止後に動作します
        /// </summary>
        public event PlayDelegate AfterStopMusic;

        /// <summary>
        /// データを破棄します。
        /// </summary>
        public void Dispose()
        {
            if (player != null)
            {
                player.Dispose();
                player = null;
            }
        }

        /// <summary>
        /// プレイヤーを初期化します
        /// </summary>
        public void InitPlayer()
        {
            Dispose();

            player = new WaveOut();
            player.Init(new Mp3FileReader(playSteram));
            player.PlaybackStopped += Player_PlaybackStopped;
        }

        /// <summary>
        /// 再生完了時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Player_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// 音楽を再生します
        /// </summary>
        /// <param name="startPosition">音楽の開始位置</param>
        public void Start(int startPosition = 0)
        {
            if(BeforePlayMusic != null)
            {
                BeforePlayMusic(this, new EventArgs());
            }

            IsPlaying = true;
            // 最初から再生
            playSteram.Position = startPosition;
            // 再生
            player.Play();

            if (AfterPlayMusic != null)
            {
                AfterPlayMusic(this, new EventArgs());
            }
        }

        /// <summary>
        /// 音楽を停止します
        /// </summary>
        public void Stop()
        {
            // 再生中
            player.Stop();
            // 最初から再生
            playSteram.Position = 0;
            IsPlaying = false;

            if(AfterStopMusic != null)
            {
                AfterStopMusic(this, new EventArgs());
            }
        }

        /// <summary>
        /// 再生ファイルを変更します。
        /// </summary>
        /// <param name="text"></param>
        public void ChangePlayFile(String path)
        {
            if (playSteram != null)
            {
                playSteram.Close();
                playSteram.Dispose();
            }

            if (path == string.Empty || !File.Exists(path))
            {
                // 初期音源
                playSteram = new MemoryStream(Resources.Japanese_School_Bell02_01);
            }
            else
            {
                // 指定音源を使用する
                playSteram = new FileStream(path, FileMode.Open);
            }

            InitPlayer();
        }
    }
}
