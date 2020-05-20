using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chimeTask.Ctrls
{
    /// <summary>
    /// スタートアップにショートカットを作成・削除を制御します
    /// </summary>
    public class SettingStartUp
    {
        /// <summary>
        /// スタートアップに出力するショートカット名
        /// </summary>
        public String ShortcutFilePath
        {
            get;
            private set;
        } = String.Empty;

        /// <summary>
        /// アプリケーションタイトル
        /// </summary>
        public String ApplicationTitle{
            get;
            private set;
        } = String.Empty;

        /// <summary>
        /// 実行ファイルパス
        /// </summary>
        private readonly String ExeFile;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SettingStartUp()
        {
            // プロジェクト＞プロパティ＞アセンブリ情報　で指定した「タイトル」を取得
            var assembly = Assembly.GetExecutingAssembly();
            var attribute = Attribute.GetCustomAttribute(
              assembly,
              typeof(AssemblyTitleAttribute)
            ) as AssemblyTitleAttribute;
            ApplicationTitle = attribute.Title;

            // 自身のexeファイル名を取得
            ExeFile = Path.GetFileName(Application.ExecutablePath);

            // ショートカットのリンク名
            String sMnu = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            ShortcutFilePath = sMnu + Path.DirectorySeparatorChar + ApplicationTitle + ".lnk";
        }

        /// <summary>
        /// スタートアップショートカットを作成します。
        /// </summary>
        public void CreateShortCut()
        {
            // WSHスクリプト名
            String jsFile = Directory.GetParent(Application.ExecutablePath) + "\\addStartup.js";

            // WSHファイル作成
            using (StreamWriter w = new StreamWriter(
                jsFile, false, System.Text.Encoding.GetEncoding("shift_jis")))
            {
                w.WriteLine("ws = WScript.CreateObject('WScript.Shell');");
                w.WriteLine("ln = ws.SpecialFolders('Startup') + '\\\\' + '" + ApplicationTitle + ".lnk';");
                w.WriteLine("sc = ws.CreateShortcut(ln);");
                w.WriteLine("sc.TargetPath = ws.CurrentDirectory + '\\\\" + ExeFile + "';");
                w.WriteLine("sc.Save();");
            }

            // addStartup.jsを実行し、スタートアップにショートカット作成
            if (File.Exists(jsFile))
            {
                ProcessStartInfo psi = (new ProcessStartInfo());
                psi.FileName = "cscript";
                psi.Arguments = @"//e:jscript " + jsFile;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process p = Process.Start(psi);

                p.WaitForExit(10000); // 終了まで待つ(最大10秒)
                File.Delete(jsFile);
            }
        }
    }
}
