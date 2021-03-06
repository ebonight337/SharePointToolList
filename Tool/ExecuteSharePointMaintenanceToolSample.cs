using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Configuration;

namespace SharePointMaintenanceToolSample {
    class Program {
        #region メイン関数
        static void Main(string[] args) {
            
            Console.WriteLine("== 処理を開始しました ==   " + DateTime.Now.ToLongTimeString());

            MainAsync(args).Wait();

            Console.WriteLine("== 処理を完了しました ==   " + DateTime.Now.ToLongTimeString());
        }
        #endregion

        private static async Task MainAsync(string[] args) {
            // パラメータ
            string sitePath = args[0];
            string mailAddress = args[1];
            string password = args[2];

            string listname = args[3];
            string template = args[4];
            string listurl = args[5];


            using (var service = new SharePointDataService(sitePath, mailAddress, password)) {
                // リスト作成
                await service.CreateListAsync(listname, template, listurl);

            }

        }
    }
}
