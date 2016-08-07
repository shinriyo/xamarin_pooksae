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
        public String Picture { get; set; }
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
                var punchUrl = "https://docs.google.com/spreadsheets/d/1PRKvYmOza7H6U7qtgpz-ZmR7JZIwIzQ1ExUthnvrvXc/pub?gid=1793064789&single=true&output=csv";
                int id = 0;
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Punch, httpClient, punchUrl);

                // キック系ファイル.
                var kickUrl = "https://docs.google.com/spreadsheets/d/1Cq5AwGlCaiDrX6tIN2SFn5ERl8bMIoxfRv8u1SQBEd0/pub?gid=405743383&single=true&output=csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Kick, httpClient, kickUrl);

                // チョップ系ファイル.
                var chopUrl = "https://docs.google.com/spreadsheets/d/1Om6NobK24YPRqS1h9DycO3VjmCg6kJpJI1gZNCtwSz8/pub?gid=857550099&single=true&output=csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Chop, httpClient, chopUrl);

                // 受け系ファイル.
                var guardUrl = "https://docs.google.com/spreadsheets/d/15Mm0Wv8H6m0x5oWZ6aKdrZmIaMRPJMOYJTrky-g-6S4/pub?gid=2086855982&single=true&output=csv";
                Tools.LoadArtsCSV(ref id, japan, (int)ArtModel.ArtType.Guard, httpClient, guardUrl);

                // 級プンセファイル.
                var kyuPoomsaeUrl = "https://docs.google.com/spreadsheets/d/17yOM2QBAWozdLA27qOhXePZyV6KxHsD-tsA0A3IkZlo/pub?gid=1480111765&single=true&output=csv";
                Tools.LoadPoomsaeCSV(japan, (int)PoomsaeModel.KyuOrDan.Kyu, httpClient, kyuPoomsaeUrl);

                // 段プンセファイル.
                var danPoomsaeUrl = "https://docs.google.com/spreadsheets/d/1MEN6zNT4ULM67KCAOBMGigt3iojb8PSFU4yLmLTIqvM/pub?gid=1578289894&single=true&output=csv";
                Tools.LoadPoomsaeCSV(japan, (int)PoomsaeModel.KyuOrDan.Dan, httpClient, danPoomsaeUrl);
            }

            // ローディング閉じる.
            DependencyService.Get<ILoadingMessage>().Hide();
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
        /// <returns>PoomsaeModelのリスト.</returns>
        /// <param name="httpClient">Http client.</param>
        /// <param name="url">URL.</param>
        public static void LoadPoomsaeCSV(
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
                    var desc = csv.GetField<string>(2);
                    var detail = csv.GetField<string>(3);
                    var picture = csv.GetField<string>(4);
                    Debug.WriteLine("Kyu:{0}, Name:{1}, Desc:{2}, " +
                                    "Detail:{3}, Picture:{4} ",
                                    kyu, name, desc, detail, picture);

                    var poomsaeModel = new PoomsaeModel
                    {
                        Language = lang,
                        Type = type,
                        Kyu = kyu,
                        Name = name,
                        Desc = desc,
                        Detail = detail,
                        Picture = picture
                    };

                    realm.Manage<PoomsaeModel>(poomsaeModel);
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
