//-----------------------------------------------------------------------
// <copyright file="Tools.cs" company="shinriyo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace CellTool
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    /// <summary>
    /// Data.
    /// </summary>
    public class Data
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String IconImage { get; set; }
        public ICommand OnClick { get; set; }
    }

    /// <summary>
    /// Group.
    /// </summary>
    public class Group : ObservableCollection<Data>
    {
        public string Title { get; private set; }
        public Group(string title)
        {
            Title = title;
        }
    }
}

namespace Poomsae
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CrossPlatformToolSample.Services;
    using CsvHelper;
    using Realms;
    using Xamarin.Forms;

    /// <summary>
    /// メソッド拡張.
    /// </summary>
    public static class RealmExtension
    {
        public static T FirstOrNull<T>(this IEnumerable<T> values) where T : class
        {
            return values.DefaultIfEmpty(null).FirstOrDefault();
        }
    }

    /// <summary>
    /// Tools.
    /// </summary>
    public static class Tools
    {
        private static int id = 0;

        /// <summary>
        /// DB初期化やCSVをWebからロード.
        /// </summary>
        /// <returns>The load CSV.</returns>
        public static async Task<bool> Initialization()
        {
            // 設定初期化.
            Tools.InitializeDB();

            try
            {
                string csvUrl = string.Empty;
                Uri webUri = null;
                string csvString = string.Empty;
                string urlBaseFormat = "https://raw.githubusercontent.com/shinriyo/xamarin_poomsae/master/dbCSV/{0}.csv";

                // Throw, // 꺾기.
                csvUrl = string.Format(urlBaseFormat, "throw");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Throw, csvString);

                // Down, // 넘기기.
                csvUrl = string.Format(urlBaseFormat, "down");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Down, csvString);

                // Stamp, // 딛기.

                // 跳び系ファイル.
                csvUrl = string.Format(urlBaseFormat, "jump");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Jump, csvString);

                // 受け系ファイル.
                csvUrl = string.Format(urlBaseFormat, "guard");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Guard, csvString);

                // 押し系ファイル.
                csvUrl = string.Format(urlBaseFormat, "push");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Push, csvString);

                // Back, // 빼기.

                // 構え系ファイル.
                csvUrl = string.Format(urlBaseFormat, "stance");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Stance, csvString);

                // Grab, // 잡기.

                // Prepare, // 준비자세.
                csvUrl = string.Format(urlBaseFormat, "prepare");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Kick, csvString);

                // パンチ系ファイル.
                csvUrl = string.Format(urlBaseFormat, "punch");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Punch, csvString);

                // Attack, // 찌르기.
                csvUrl = string.Format(urlBaseFormat, "attack");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Attack, csvString);

                // Cut, // 찍기.
                csvUrl = string.Format(urlBaseFormat, "cut");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadPoomsaeCSV((int)ArtModel.ArtType.Cut, csvString);

                // キック系ファイル.
                csvUrl = string.Format(urlBaseFormat, "kick");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Kick, csvString);

                // 手刀/肘系ファァイル.
                csvUrl = string.Format(urlBaseFormat, "elbow");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadArtsCSV((int)ArtModel.ArtType.Elbow, csvString);

                // Dodge, // 피하기.
                csvUrl = string.Format(urlBaseFormat, "dodge");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadPoomsaeCSV((int)ArtModel.ArtType.Dodge, csvString);

                // Special, // 특수품.
                // Part // 사용부위.

                // プンセ系は別idなので.
                id = 0;

                // 級プンセファイル.
                csvUrl = string.Format(urlBaseFormat, "poomsae_kyu");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadPoomsaeCSV((int)PoomsaeModel.KyuOrDan.Kyu, csvString);

                // 段プンセファイル.
                csvUrl = string.Format(urlBaseFormat, "poomsae_dan");
                webUri = new Uri(csvUrl);
                csvString = await GetWebPageAsync(webUri);
                if (string.IsNullOrEmpty(csvString))
                {
                    return false;
                }

                Tools.LoadPoomsaeCSV((int)PoomsaeModel.KyuOrDan.Dan, csvString);

                webUri = null;
                csvUrl = string.Empty;
                csvString = string.Empty;

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("例外メッセージ: {0} ", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Gets the web page async.
        /// </summary>
        /// <returns>The web page async.</returns>
        /// <param name="uri">URI.</param>
        static async Task<string> GetWebPageAsync(Uri uri)
        {
            Debug.WriteLine("{0}のダウンロード開始...", uri);

            using (HttpClient client = new HttpClient())
            {
                // ユーザーエージェント文字列をセット（オプション）
                client.DefaultRequestHeaders.Add(
                    "User-Agent",
                    "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko");

                // 受け入れ言語をセット（オプション）
                client.DefaultRequestHeaders.Add("Accept-Language", "ja-JP");

                // タイムアウトをセット（オプション）
                client.Timeout = TimeSpan.FromSeconds(10.0);

                try
                {
                    // Webページを取得するのは、事実上この1行だけ
                    return await client.GetStringAsync(uri);
                }
                catch (HttpRequestException e)
                {
                    // 404エラーや、名前解決失敗など
                    Debug.WriteLine("\n例外発生!");
                    // InnerExceptionも含めて、再帰的に例外メッセージを表示する
                    Exception ex = e;
                    while (ex != null)
                    {
                        Debug.WriteLine("例外メッセージ: {0} ", ex.Message);
                        ex = ex.InnerException;
                    }
                }
                catch (TaskCanceledException e)
                {
                    // タスクがキャンセルされたとき（一般的にタイムアウト）
                    Debug.WriteLine("\nタイムアウト!");
                    Debug.WriteLine("例外メッセージ: {0} ", e.Message);
                }
                return null;
            }
        }

        /// <summary>
        /// 技のCSVをロード.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="csvString">csvからとった文字.</param>
        private static void LoadArtsCSV(int type, string csvString)
        {
            // 結果を取得.
            var csv = new CsvReader(new StringReader(csvString));
            var now = DateTimeOffset.Now;

            var realm = Realm.GetInstance(App.realmFile);
            using (var transaction = realm.BeginWrite())
            {
                while (csv.Read())
                {
                    var kyu = csv.GetField<int>(0);
                    var name = csv.GetField<string>(1);
                    var desc = csv.GetField<string>(2);
                    var detail = csv.GetField<string>(3);
                    var picture = csv.GetField<string>(4);
                    Debug.WriteLine("Kyu:{0}, Name:{1}, Desc:{2}, " +
                                                "Detail:{3}, Picture:{4} ",
                                                kyu, name, desc, detail, picture);

                    var artModel = new ArtModel
                    {
                        Id = id.ToString(),
                        Type = type,
                        Kyu = kyu,
                        Name = name,
                        Desc = desc,
                        Detail = detail,
                        Picture = picture,
                        Updated = now,
                        Created = now
                    };

                    //realm.Manage<ArtModel>(artModel);
                    realm.Add<ArtModel>(artModel);
                    //realm.Manage(artModel);
                    id++;
                }

                transaction.Commit();
                GC.Collect();
            }
        }

        /// <summary>
        /// プンセCSVファイルのロード.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="csvString">csvからとった文字.</param>
        public static void LoadPoomsaeCSV(int type, string csvString)
        {
            var csv = new CsvReader(new StringReader(csvString));

            var realm = Realm.GetInstance(App.realmFile);
            using (var transaction = realm.BeginWrite())
            {
                while (csv.Read())
                {
                    var kyu = csv.GetField<int>(0);
                    var name = csv.GetField<string>(1);
                    var hangl = csv.GetField<string>(2);
                    var meaning = csv.GetField<string>(3);
                    var order = csv.GetField<string>(4);
                    var detail = csv.GetField<string>(5);
                    var newArts = csv.GetField<string>(6);
                    var picture = csv.GetField<string>(7);
                    var youTubeUrl = csv.GetField<string>(8);
                    Debug.WriteLine("Kyu:{0}, Name:{1}, Hangl:{2}, " +
                                    "Meaning:{3}, Order:{4}, Detail:{5}, " +
                                    "NewArts:{6}, Picture:{7}, YouTubeURL:{8}",
                                    kyu, name, hangl, meaning, order, detail,
                                    newArts, picture, youTubeUrl);

                    var poomsaeModel = new PoomsaeModel
                    {
                        Id = id.ToString(),
                        Type = type,
                        Kyu = kyu,
                        Name = name,
                        Hangl = hangl,
                        Meaning = meaning,
                        NewArts = newArts,
                        Order = order,
                        Detail = detail,
                        Picture = picture,
                        YouTubeURL = youTubeUrl
                    };

                    //realm.Manage<PoomsaeModel>(poomsaeModel);
                    realm.Add<PoomsaeModel>(poomsaeModel);
                    //realm.Manage(poomsaeModel);
                    id++;
                }

                transaction.Commit();
                GC.Collect();
            }
        }

        /// <summary>
        /// Initializes the db.
        /// </summary>
        /// <returns>The db.</returns>
        public static void InitializeDB()
        {
            var ds = DependencyService.Get<ICrossPlatformToolService>();
            var documentsPath = ds.GetSpecialFolderPath();
            var path = Path.Combine(documentsPath, App.realmFile);
            Debug.WriteLine("realmのpath: {0}", path);

            if (ds.FileExists(path))
            {
                Debug.WriteLine("存在するので消す.");
                ds.DeleteFile(path);

                // 関連ファイルも消す.
                ds.DeleteFile(path + ".lock");
            }
            else
            {
                Debug.WriteLine("存在しない.");
            }

            var realm = Realm.GetInstance(App.realmFile);

            // トランザクションを開始してオブジェクトを削除します.
            //using (var trans = realm.BeginWrite())
            //{
            //    realm.RemoveAll();
            //    trans.Commit();
            //}

            // ローカライズ.
            var now = DateTimeOffset.Now;

            // 設定.
            var setting = new SettingModel()
            {
                Id = "0",
                version = App.version,
                Updated = now,
                Created = now
            };

            using (var transaction = realm.BeginWrite())
            {
                //realm.Manage<SettingModel>(setting);
                realm.Add<SettingModel>(setting);
                //realm.Manage(setting);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Device.OnPlatform(20, 0, 0)の代わりに使う.
        /// </summary>
        /// <returns>The platform padding size.</returns>
        public static int GetPlatformPaddingSize()
        {
            int paddingSize = 0;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                paddingSize = 20;
                break;
                case Device.Android:
                case Device.WinPhone:
                case Device.Windows:
                paddingSize = 0;
                break;
            }

            return paddingSize;
        }
    }
}