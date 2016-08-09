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
    using CsvHelper;
    using LoadingMessageSample.Services;
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
        /// <summary>
        /// DB初期化やCSVをWebからロード.
        /// </summary>
        /// <returns>The load CSV.</returns>
        public static void Initialization()
        {
            // ローディング開始.
            DependencyService.Get<ILoadingMessage>().Show("ローディング....");

            // 設定初期化.
            Tools.InitializeDB();

            using (var httpClient = new HttpClient())
            {
                // ローカライズファイル.
                var localizeUrl = "http://vps6-d.kuku.lu/files/20160725-0035_2b21358ee0d5a871860a15789270a433.csv";

                // 取得したいWebページのURI.
                Uri webUri = new Uri(localizeUrl);

                // GetWebPageAsyncメソッドを呼び出す
                Task<string> webTask = httpClient.GetStringAsync(webUri);

                // Mainメソッドではawaitできないので、処理が完了するまで待機する.
                webTask.Wait();

                // 結果を取得.
                var csvString = webTask.Result;

                var csv = new CsvReader(new StringReader(csvString));
                while (csv.Read())
                {
                    var key = csv.GetField<string>(0);
                    var value = csv.GetField<string>(1);
                    Debug.WriteLine("key:{0}, value:{1}", key, value);
                }

                string japan = "ja";

                // パンチ系ファイル.
                var punchUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/punch.csv";
                int id = 0;
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Punch, httpClient, punchUrl);

                // キック系ファイル.
                var kickUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/kick.csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Kick, httpClient, kickUrl);

                // チョップ系ファイル.
                var chopUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/chop.csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Chop, httpClient, chopUrl);

                // 受け系ファイル.
                var guardUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/guard.csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Guard, httpClient, guardUrl);

                // 肘系ファァイル.
                var elbowdUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/elbowd.csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Elbow, httpClient, elbowdUrl);

                // 構え系ファイル.
                var stanceUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/stance.csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Stance, httpClient, stanceUrl);

                // 押し系ファイル.
                var pushUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/push.csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Push, httpClient, pushUrl);

                // 跳び系ファイル.
                var jumpUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/jump.csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Jump, httpClient, jumpUrl);

                int poomsaeId = 0;

                // 級プンセファイル.
                var kyuPoomsaeUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/poomsae_kyu.csv";
                Tools.LoadPoomsaeCSV(ref poomsaeId, japan, (int)PoomsaeModel.KyuOrDan.Kyu, httpClient, kyuPoomsaeUrl);

                // 段プンセファイル.
                var danPoomsaeUrl = "https://raw.githubusercontent.com/shinriyo/xamarin_pooksae/master/dbCSV/ja/poomsae_dan.csv";
                Tools.LoadPoomsaeCSV(ref poomsaeId, japan, (int)PoomsaeModel.KyuOrDan.Dan, httpClient, danPoomsaeUrl);
            }

            // ローディング閉じる.
            DependencyService.Get<ILoadingMessage>().Hide();
        }

        /// <summary>
        /// Gets the web page async.
        /// </summary>
        /// <returns>The web page async.</returns>
        /// <param name="uri">URI.</param>
        static async Task<string> GetWebPageAsync(Uri uri)
        {
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
        /// <param name="id">Id.</param>
        /// <param name="lang">Lang.</param>
        /// <param name="type">Type.</param>
        /// <param name="httpClient">Http client.</param>
        /// <param name="url">URL.</param>
        private static void LoadArtsCSV(
            ref int id,
            string lang, int type, HttpClient httpClient,
            string url)
        {
            // 取得したいWebページのURI.
            Uri webUri = new Uri(url);

            // GetWebPageAsyncメソッドを呼び出す
            Task<string> webTask = httpClient.GetStringAsync(webUri);

            // Mainメソッドではawaitできないので、処理が完了するまで待機する.
            webTask.Wait();

            // 結果を取得.
            var csvString = webTask.Result;
            var csv = new CsvReader(new StringReader(csvString));
            var now = DateTimeOffset.Now;

            var realm = Realm.GetInstance();
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
                        Language = lang,
                        Type = type,
                        Kyu = kyu,
                        Name = name,
                        Desc = desc,
                        Detail = detail,
                        Picture = picture,
                        Updated = now,
                        Created = now
                    };

                    realm.Manage<ArtModel>(artModel);
                    id++;
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// プンセCSVファイルのロード.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="lang">Lang.</param>
        /// <param name="type">Type.</param>
        /// <param name="httpClient">Http client.</param>
        /// <param name="url">URL.</param>
        public static void LoadPoomsaeCSV(
            ref int id,
            string lang, int type, HttpClient httpClient,
            string url
        )
        {
            // 取得したいWebページのURI.
            Uri webUri = new Uri(url);

            // GetWebPageAsyncメソッドを呼び出す
            Task<string> webTask = httpClient.GetStringAsync(webUri);

            // Mainメソッドではawaitできないので、処理が完了するまで待機する.
            webTask.Wait();

            // 結果を取得.
            var csvString = webTask.Result;
            var csv = new CsvReader(new StringReader(csvString));

            var realm = Realm.GetInstance();
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
                    var picture = csv.GetField<string>(6);
                    Debug.WriteLine("Kyu:{0}, Name:{1}, Hangl:{2}, " +
                                    "Meaning:{3}, Order:{4}, Detail:{5}, " +
                                    "Picture:{6}",
                                    kyu, name, hangl, meaning, order, detail,
                                    picture);

                    var poomsaeModel = new PoomsaeModel
                    {
                        Id = id.ToString(),
                        Language = lang,
                        Type = type,
                        Kyu = kyu,
                        Name = name,
                        Hangl = hangl,
                        Meaning = meaning,
                        Order = order,
                        Detail = detail,
                        Picture = picture
                    };

                    realm.Manage<PoomsaeModel>(poomsaeModel);
                    id++;
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// Initializes the db.
        /// </summary>
        /// <returns>The db.</returns>
        public static void InitializeDB()
        {
            var realm = Realm.GetInstance();

            // トランザクションを開始してオブジェクトを削除します.
            using (var trans = realm.BeginWrite())
            {
                realm.RemoveAll();
                trans.Commit();
            }

            // ローカライズ.
            var now = DateTimeOffset.Now;
            var ja = new Localize { Id = "0", Country = "ja", Updated = now, Created = now };
            var enUS = new Localize { Id = "1", Country = "en-US", Updated = now, Created = now };
            var kr = new Localize { Id = "2", Country = "kr", Updated = now, Created = now };
            var vi = new Localize { Id = "3", Country = "vi", Updated = now, Created = now };

            // 設定.
            var setting = new SettingModel()
            {
                Id = "0",
                language = "ja",
                version = App.version,
                Updated = now,
                Created = now
            };

            using (var transaction = realm.BeginWrite())
            {
                realm.Manage<Localize>(ja);
                realm.Manage<Localize>(enUS);
                realm.Manage<Localize>(kr);
                realm.Manage<Localize>(vi);

                realm.Manage<SettingModel>(setting);

                transaction.Commit();
            }
        }
    }
}
