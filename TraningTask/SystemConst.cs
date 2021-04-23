using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraningTask
{
    class SystemConst
    {
        public const string sLSFileFilter = "CSVファイル(*.CSV)|*.CSV| すべてのファイル(*.*)|*.*";

        public const int ResultCode_Success = 0;
        public const int ResultCode_Err = 1;

        public enum XmlResultCode
        {
            NoFileErr = -1,  // ファイルなし
            ReadErr = -2,  // 読込失敗
            NoItemErr = -3,  // 項目なし
            NoSetErr = -4,  // 値なし
            NewLineErr = -5,  // 改行あり
            IllegalErr = -6,  // 禁則文字あり
            NumericErr = -7,  // 数値以外あり
            ValueErr = -8,  // 値不正
            ItemCountErr = -9,  // 更新元テーブルと更新先テーブルの項目数不一致
        }
    }
}
