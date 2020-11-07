using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Io;
using InMemory.Models.Video;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace InMemory.Helpers {
    public class HtmlHelper {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; set; }
        public HtmlHelper (Microsoft.Extensions.Configuration.IConfiguration configuration) {
            Configuration = configuration;
        }

        /// <summary>
        /// 根據 selectors 取回所有符合的html select結果
        /// </summary>
        /// <param name="selectors">regexp</param>
        /// <returns></returns>
        public async Task<List<string>> select (string selectors,int index) {
            HttpClient httpClient = new HttpClient ();
            //查詢網址
            var url = Configuration.GetSection ("YoutubeQuery").Get<string> ();

            //網址加入變數
            url = $"{url}conor+maynard";
            var responseMessage = await httpClient.GetAsync (url);

            //檢查回應的伺服器狀態StatusCode是否是200 OK
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK) {
                //取得response內容
                string responseResult = responseMessage.Content.ReadAsStringAsync ().Result;

                //預設參數
                var config = AngleSharp.Configuration.Default.WithDefaultLoader (new LoaderOptions { IsResourceLoadingEnabled = true });

                //
                var context = BrowsingContext.New (config);

                //取得 respoonse html
                var document = await context.OpenAsync (res => res.Content (responseResult));

                Regex rx = new Regex (selectors,
                    RegexOptions.Compiled | RegexOptions.IgnoreCase);

                var tmp = new List<string>();
                 var res = new List<string>();
                //  var script = document.QuerySelectorAll("script")[index].InnerHtml;
                foreach (Match m in rx.Matches (document.ToHtml())) {
                    tmp.Add("{"+$"{m.ToString()}"+"}");
                }
                for(var i = 0;i<tmp.Count();i+=4){
                    res.Add(tmp[i]);
                }
                return res;
            }

            return new List<string>();
        }

        /// <summary>
        /// 取得URL(appsetting) HTML
        /// </summary>
        /// <returns></returns>
        public async Task<object> html () {
            HttpClient httpClient = new HttpClient ();
            //查詢網址
            var url = Configuration.GetSection ("YoutubeQuery").Get<string> ();
            //網址加入變數
            url = $"{url}conor+maynard";
            var responseMessage = await httpClient.GetAsync (url);

            //檢查回應的伺服器狀態StatusCode是否是200 OK
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK) {
                //取得response內容
                string responseResult = responseMessage.Content.ReadAsStringAsync ().Result;

                //預設參數
                var config = AngleSharp.Configuration.Default.WithDefaultLoader (new LoaderOptions { IsResourceLoadingEnabled = true });

                //
                var context = BrowsingContext.New (config);

                var parser = new HtmlParser ();

                var html = await parser.ParseDocumentAsync (responseResult);

                //取得 respoonse html
                // var document = await context.OpenAsync (res => res.Content (html));

                return html.ToHtml ();
            }

            return "";
        }

        /// <summary>
        /// 跟去 appsetting URL+seletos 取得 select 結果
        /// </summary>
        /// <param name="query">youtube 輸入查詢內容</param>
        /// <returns></returns>
        public async Task<string> getDatas (string query) {
            HttpClient httpClient = new HttpClient ();
            //查詢網址
            var url = Configuration.GetSection ("YoutubeQuery").Get<string> ();

            //網址加入變數
            url = $"{url}{query}";
            var responseMessage = await httpClient.GetAsync (url);

            //檢查回應的伺服器狀態StatusCode是否是200 OK
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK) {
                //取得response內容
                string responseResult = responseMessage.Content.ReadAsStringAsync ().Result;

                //預設參數
                var config = AngleSharp.Configuration.Default.WithDefaultLoader (new LoaderOptions { IsResourceLoadingEnabled = true });

                //
                var context = BrowsingContext.New (config);

                //取得 respoonse html
                var document = await context.OpenAsync (res => res.Content (responseResult));

                Regex rx = new Regex ("\"videoId\":\"[^\"]*\"",
                    RegexOptions.Compiled | RegexOptions.IgnoreCase);

                var tmp = new List<string>();
                 var res = new List<object>();
                //  var script = document.QuerySelectorAll("script")[index].InnerHtml;
                foreach (Match m in rx.Matches (document.ToHtml())) {
                    tmp.Add("{"+$"{m.ToString()}"+"}");
                }
                for(var i = 0;i<tmp.Count();i+=4){
                    res.Add(tmp[i]);
                }
                return JsonConvert.SerializeObject(res);
            }

            return "";
        }

        // /// <summary>
        // /// 跟去 appsetting URL+seletos 取得 select 結果
        // /// </summary>
        // /// <param name="query">youtube 輸入查詢內容</param>
        // /// <returns></returns>
        // public async Task<string> getDatas (string query) {
        //     HttpClient httpClient = new HttpClient ();
        //     //查詢網址
        //     var url = Configuration.GetSection ("YoutubeQuery").Get<string> ();

        //     //網址加入變數
        //     url = $"{url}{query}";

        //     // 轉成grid的欄位(rawdata key)
        //     string[] cols = Configuration.GetSection ("Col").Get<string> ().Split (",");

        //     // 轉成grid的欄位中文名稱
        //     // string[] chCols = Configuration.GetSection ("ChCol").Get<string> ().Split(",");

        //     // 如何取得資料 Exp(jquery seletor) Index(第幾個)
        //     HtmlSelector[] selectors = Configuration.GetSection ("Selector").Get<HtmlSelector[]> ();

        //     // 字串編輯器
        //     // StringBuilder stringBuilder = new StringBuilder ();

        //     //發送請求
        //     var responseMessage = await httpClient.GetAsync (url);

        //     //檢查回應的伺服器狀態StatusCode是否是200 OK
        //     if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK) {
        //         //取得response內容
        //         string responseResult = responseMessage.Content.ReadAsStringAsync ().Result;

        //         //預設參數
        //         var config = AngleSharp.Configuration.Default;

        //         //
        //         var context = BrowsingContext.New (config);

        //         //取得 respoonse html
        //         var document = await context.OpenAsync (res => res.Content (responseResult));
        //         Dictionary<string, List<string>> row = new Dictionary<string, List<string>> ();

        //         // 根據欄位順序，欄位名稱 塞入值
        //         for (var i = 0; i < cols.Count (); i++) {
        //             row[cols[i]] = document.QuerySelectorAll (selectors[i].Exp)?.Select (x => x.InnerHtml).ToList ();
        //         }

        //         // 根據欄位順序，中文欄位名稱 塞入值
        //         // for (var j = 0; j < cols.Count (); j++) {
        //         //     row[chCols[j]] = document.QuerySelectorAll (selectors[j].Exp) [selectors[j].Index].InnerHtml;
        //         // }

        //         return JsonConvert.SerializeObject (row, Formatting.Indented);
        //     }

        //     return "";
        // }
    }
}