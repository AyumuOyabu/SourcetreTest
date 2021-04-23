using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


namespace TraningTask
{
    class Common
    {
        public Common()
        {
        }

        //プログラム実行チェック
        [System.STAThread()]
        public bool CheckRunSystem(Mutex mutex)
        {
            bool bolCheckRunSystem = true;

            try
            {
                //Mutexのシグナルを受信できるかどうか判断
                if(mutex.WaitOne(0,false))
                {
                    bolCheckRunSystem = true;
                }
                else
                {
                    bolCheckRunSystem = false;
                }
            }
            catch (Exception)
            {
                bolCheckRunSystem = false;
            }
            return bolCheckRunSystem;
        }
        //環境ファイル読み込み
        public int ReadConfigFile(ref string strErrkey,ref string strExpMessage)
        {
            int iResult = SystemConst.ResultCode_Success;

            try
            {
                if (File.Exists(SystemParam.strConfFilPath))
                {
                    SystemParam.ComfigFile = XML.XMLControl.ReadFile<XML.ConfigFile>(SystemParam.strConfFilPath);
                    //ファイルが無かったらエラー
                    if (SystemParam.ComfigFile == null)
                    {
                        iResult = (int)SystemConst.XmlResultCode.ReadErr;
                        return iResult;
                    }
                    else
                    {
                        //「DNS」設定値
                        strErrkey = "DNS";
                        iResult = this.CheckNullEmpty(SystemParam.ComfigFile.DSN);
                        if (iResult != SystemConst.ResultCode_Success)
                        {
                            return iResult;
                        }
                        if (this.CheckNewLine(SystemParam.ComfigFile.DSN))
                        {
                            iResult = (int)SystemConst.XmlResultCode.NewLineErr;
                            return iResult;
                        }
                        if (CheckIllegalCh(SystemParam.ComfigFile.DSN) == false)
                        {
                            iResult = (int)SystemConst.XmlResultCode.IllegalErr;
                            return iResult;
                        }
                    }
                }
                else
                {
                    iResult = (int)SystemConst.XmlResultCode.NoFileErr;
                    return iResult;
                }
            }
            catch(Exception ex)
            {
                strExpMessage = ex.Message;
                iResult = (int)SystemConst.XmlResultCode.ReadErr;
                return iResult;
            }
 
            return iResult;
        }
       

        //Nullか空白かをチェック
        public int CheckNullEmpty(string strVal)
        {
            int iResult = SystemConst.ResultCode_Success;
            try
            {
                if(strVal == null)
                {
                    iResult = (int)SystemConst.XmlResultCode.NoItemErr;
                }
                else
                {
                    if(string.IsNullOrEmpty(strVal))
                    {
                        iResult = (int)SystemConst.XmlResultCode.NoItemErr;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return iResult;
        }

        //改行の有無をチェックする
        public bool CheckNewLine(string strVal)
        {
            bool bolResult = true;
            try
            {
                if(strVal.IndexOf("\\r") != -1 || strVal.IndexOf("\\n") != -1)
                {
                    bolResult = false;
                }
            }
            catch(Exception)
            {
                throw;
            }
            return bolResult;
        }
        //禁則文字をチェックする
        public bool CheckIllegalCh(string strVal, string strErrkey = null)
        {
            bool bolResult = true;

            try
            {
                for(int i = 0; i < strVal.Length; i++)
                {
                    char checkCh = strVal[i];
                    if(SystemParam.illegalChars.Contains(checkCh) == true)
                    {
                        bolResult = false;
                        break;
                    }
                }
                return bolResult;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
