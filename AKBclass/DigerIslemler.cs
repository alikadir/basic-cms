using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Security.Cryptography;


namespace AKBclass
{
    /// <summary>
    /// Dosya işlemleri ve programsal işlemleri için oluşturulmuştur
    /// </summary>
    public class DigerIslemler
    {



       /// <summary>
       /// Size ss = ResimOrantila(int.Parse(TxtOrgWidth.Text), int.Parse(TxtOrgHeight.Text), 300, 225, 800, 600);
       /// if (ss.IsEmpty)
       ///    MessageBox.Show("resminizin orantısında problem var");
       /// </summary>
       /// <param name="OrgW"></param>
       /// <param name="OrgH"></param>
       /// <param name="MinW"></param>
       /// <param name="MinH"></param>
       /// <param name="MaxW"></param>
       /// <param name="MaxH"></param>
       /// <returns></returns>
        public static Size ResimOrantila(int OrgW, int OrgH, int MinW, int MinH, int MaxW, int MaxH)
        {
            bool Azaltma = false;
            bool Arttirma = false;

            Size ss = new Size();
            float ORAN = 0;

            if (OrgW >= MinW || OrgH >= MinH)
            {
                if ((OrgW > 800) || (OrgH > 600))
                {
                    if (OrgW > OrgH)
                    {
                        ORAN = OrgW / (float)(MaxW);
                    }
                    else
                    {
                        ORAN = OrgH / (float)MaxH;
                    }


                    while (true)
                    {


                        if (Arttirma && Azaltma)
                        {
                            ss.Width = 0;
                            ss.Height = 0;
                            return ss;
                        }

                        ss.Width = (int)(OrgW / ORAN);
                        ss.Height = (int)(OrgH / ORAN);

                        if (ss.Width > MinW && ss.Height > MinH)
                        {
                            if (ss.Width < MaxW && ss.Height < MaxH)
                            {
                                return ss;
                            }
                            else
                            {
                                ORAN += 0.1f;
                                Arttirma = true;
                            }
                        }
                        else
                        {
                            ORAN -= 0.1f;
                            Azaltma = true;

                            if (ORAN < 1.0)
                            {
                                ss.Height = 0;
                                ss.Width = 0;
                                return ss;

                            }
                        }


                    }



                }
                else
                {
                    ss.Width = OrgW;
                    ss.Height = OrgH;
                }
            }
            else
            {

                ss.Height = 0;
                ss.Width = 0;
                return ss;
            }


            return ss;
        }

      

        private static String FormHtmlGetir(string url, System.Collections.Specialized.NameValueCollection data)
        {
            
            string formID = "PostForm";

           
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"POST\">");
            foreach (string key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key + "\" value=\"" + data[key] + "\">");
            }
            strForm.Append("</form>");

            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." + formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            
            return strForm.ToString() + strScript.ToString();
        }
        /// <summary>
        /// Post metoduyla sayfayı redirect eden fonksiyon
        /// </summary>
        public static void SayfayiPostla(Page page, string Url, System.Collections.Specialized.NameValueCollection data)
        {
           
            string strForm = FormHtmlGetir(Url, data);
            page.Controls.Add(new LiteralControl(strForm));
        }

        public static string MD5Dondur(string deger)
        {


            byte[] ByteData = Encoding.ASCII.GetBytes(deger);
            //MD5 nesnesi oluşturalım.   
            MD5 oMd5 = MD5.Create();
            //Hash değerini hesaplayalım.   
            byte[] HashData = oMd5.ComputeHash(ByteData);

            //byte dizisini hex formatına çevirelim   
            StringBuilder oSb = new StringBuilder();
            for (int x = 0; x < HashData.Length; x++)
            {
                //hexadecimal string değeri   
                oSb.Append(HashData[x].ToString("x2"));
            }
            return oSb.ToString().ToUpper();


        }

        public static string Benzersiz()
        {
            long sayim = 1;
            foreach (byte eleman in Guid.NewGuid().ToByteArray())
            {
                sayim *= ((int)eleman + 1);
            }
            return (string.Format("{0:x}", sayim - DateTime.Now.Ticks)) + DateTime.Now.Millisecond.ToString();
        }
        public static string MesajVer(string Mesaj)
        {
            
            string mesajj;
            mesajj = @"<script language='javascript' >alert('" + Mesaj + "');</script>";
            return mesajj;
        }
        public static void MesajVerNew(string Mesaj)
        {
            ((System.Web.UI.Page)HttpContext.Current.Handler).RegisterStartupScript("mesajjAKB", @"<script language='javascript' >alert('" + Mesaj + "');</script>");
            
        }
        public static void BaslangicJavaScript(string Script)
        {
            ((System.Web.UI.Page)HttpContext.Current.Handler).RegisterStartupScript("ScriptAKB", @"<script language='javascript' >" + Script + "</script>");

        }
        public static string Donustur(string YaziID, string Baslik)
        {
            string Temp = "";
            //Bu kısımda çeşitli replace işlemleri yapacağız çünkü adres çubuğunda
            //geçerli olmayan karakterler karşımıza çıkacaktır Ör: ğşü# vs...
            //ve url'yi daha anlamlı hale getirmek için bunları replace etmeliyiz...
            Temp = Baslik.ToLower();
            Temp = Temp.Replace("-", "");  Temp = Temp.Replace(" ", "_");
            Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
            Temp = Temp.Replace("ö", "o"); Temp = Temp.Replace("?", ""); 
            Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ü", "u");
            Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("/", ""); 
            Temp = Temp.Replace("\"", ""); Temp = Temp.Replace(")", ""); 
            Temp = Temp.Replace("(", "");  Temp = Temp.Replace("}", "");
            Temp = Temp.Replace("{", "");  Temp = Temp.Replace("&", "");
            Temp = Temp.Replace("%", "");  Temp = Temp.Replace(".", "_");
            Temp = Temp.Replace("+", "");  Temp = Temp.Replace(",", "");
            Temp = Temp.Replace("'", "");  Temp = Temp.Replace(":", "");

            return "-" + YaziID + "-" + Temp;
        }
        public static string Donustur(string YaziID, string Baslik,string Uzanti)
        {
            string Temp = "";
            //Bu kısımda çeşitli replace işlemleri yapacağız çünkü adres çubuğunda
            //geçerli olmayan karakterler karşımıza çıkacaktır Ör: ğşü# vs...
            //ve url'yi daha anlamlı hale getirmek için bunları replace etmeliyiz...
            Temp = Baslik.ToLower();
            Temp = Temp.Replace("-", ""); Temp = Temp.Replace(" ", "_");
            Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
            Temp = Temp.Replace("ö", "o"); Temp = Temp.Replace("?", "");
            Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ü", "u");
            Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("/", "");
            Temp = Temp.Replace("\"", ""); Temp = Temp.Replace(")", "");
            Temp = Temp.Replace("(", ""); Temp = Temp.Replace("}", "");
            Temp = Temp.Replace("{", ""); Temp = Temp.Replace("&", "");
            Temp = Temp.Replace("%", ""); Temp = Temp.Replace(".", "_");
            Temp = Temp.Replace("+", ""); Temp = Temp.Replace(",", "");
            Temp = Temp.Replace("'", ""); Temp = Temp.Replace(":", "");

            return "-" + YaziID + "-" + Temp + Uzanti;
        }
    
        /// <summary>
        /// arama sonucu INT -1 dönerse özel karekter içermiyodur 
        /// </summary>
        /// <param name="Yazi"></param>
        /// <returns></returns>
        public static int OzelKarekterKontrol(string Yazi)
        {
            int DonenDeger = -1;
            Yazi = Yazi.ToLower();
            if (Yazi.IndexOf(@"-") != -1 || Yazi.IndexOf(@"ç") != -1 ||
                Yazi.IndexOf(@"ı") != -1 || Yazi.IndexOf(@"\") != -1 ||
                Yazi.IndexOf(@"ş") != -1 || Yazi.IndexOf(@"{") != -1 ||
                Yazi.IndexOf(@"(") != -1 || Yazi.IndexOf(@"+") != -1 ||
                Yazi.IndexOf(@"%") != -1 || Yazi.IndexOf(@" ") != -1 ||
                Yazi.IndexOf(@"?") != -1 || Yazi.IndexOf(@"ü") != -1 ||
                Yazi.IndexOf(@"ö") != -1 || Yazi.IndexOf(@")") != -1 ||
                Yazi.IndexOf(@"/") != -1 || Yazi.IndexOf(@"&") != -1 ||
                Yazi.IndexOf(@"}") != -1 || Yazi.IndexOf(@",") != -1 ||
                Yazi.IndexOf(@"ğ") != -1 ||
                Yazi.IndexOf(@"'") != -1 || Yazi.IndexOf(@"=") != -1 ||
                Yazi.IndexOf(@"<") != -1 || Yazi.IndexOf(">") != -1)
                DonenDeger = 0;
            //Yazi.IndexOf(@".") != -1 ||
            return DonenDeger;

        }
        /// <summary>
        /// arama sonucu INT -1 dönerse özel karekter içermiyodur 
        /// izin verilen karekterlerin arasında boşluk bırakmadan yazın +*,%&  gibi
        /// </summary>
        /// <param name="Yazi"></param>
        /// <returns></returns>
        public static int OzelKarekterKontrol(string Yazi,string IzinVerilenKarekterler)
        {
         
            // http://www.ceviz.net/c-list-nesnesi_a1250.html   list anlatımı
         
            int DonenDeger = -1;
            List<string> Karekterler = new List<string>() 
            {
                @"-",
                @"ı",
                @"İ",
                @"ş",
                @"Ş",
                @"(",
                @"%",
                @"?",
                @"ö",
                @"Ö",
                @"/",
                @"}",
                @"ğ",
                @"Ğ",
                @"'",
                @"<",
                @"ç",
                @"Ç",
                @"\",
                @"{",
                @"+",
                @" ",
                @"ü",
                @"Ü",
                @")",
                @"&",
                @",",
                @".",
                @"=",
                @">",
                @"*",
                @"$",
                @";",
                @"|",
                @"!",
                @"_",
                @"[",
                @"]",
                "\"",
                @"@"
            
            };
         if (!string.IsNullOrEmpty(IzinVerilenKarekterler))
            for (int i = 0; i < Karekterler.Count; i++)
                for (int j = 0; j < IzinVerilenKarekterler.Length; j++)
                    if (Karekterler[i] == (IzinVerilenKarekterler.Substring(j, 1)))
                    {
                        Karekterler.RemoveAt(i);
                        break;
                    }


         for (int i = 0; i < Karekterler.Count; i++)
             if (Yazi.IndexOf(Karekterler[i]) != -1)
             {
                 DonenDeger = 0;
                 break;
             }
            return DonenDeger;

        }

        public enum HtmlTemizleSecenek
        {
            TumHtmlTaglariniTemizle = 1,
            SadeceOzelKarekterleri = 2
        }
        public static string HTMLtemizle(string Html, HtmlTemizleSecenek nasil)
        {

            if (nasil == HtmlTemizleSecenek.TumHtmlTaglariniTemizle)
            {
                int Bas = 0, Bit = 0, Sart = 1;

                while (1 == Sart)
                {
                    try
                    {
                        Bas = 0;
                        Bas = Html.IndexOf("<", Bas);
                        Bit = Html.IndexOf(">", Bas);
                        Html = Html.Remove(Bas, Bit - Bas + 1);

                    }
                    catch { Sart = 2; }


                }
            }
            else
            {
                Html = Html.Replace("'", "");
                Html = Html.Replace("-", "");
                Html = Html.Replace("%", "");

                // yeni eklendi ----
                Html = Html.Replace("<", "");
                Html = Html.Replace(">", "");


            }
            return Html;

        }

        public static void HataYaz(string Yer, string Hata, string LogDosyasıYolu)
        {
            try
            {
                StreamWriter sw = new StreamWriter("~HataLog.txt", true);

                sw.WriteLine(DateTime.Now.ToString() + "  -  " + Yer);

                sw.WriteLine("Hata Ayrıntısı ;");
                sw.WriteLine(Hata);
                sw.WriteLine();
                sw.WriteLine("------------------------");
                sw.WriteLine();

                sw.Close();
            }
            catch { }
        
        }

        /// <summary>
        /// INT ise 1 , STRING ise -1 Dönecek
        /// </summary>
        /// <param name="Yazi"></param>
        /// <returns></returns>
        public static int IntMiStringMi(string Yazi)
        {
            int DonenDeger = 0;
            try
            {
                DonenDeger = Convert.ToInt32(Yazi);
                DonenDeger = 1;
            }
            catch
            {
                DonenDeger = -1;
            }
            return DonenDeger;

        }
    
        public enum ButtonJavaTipi
        {
            MsgBox=1,
            SoruMsgBox=2
        }
        /// <summary>
        /// 
        ///Classlar.DigerIslemler.ButtonJavaEkle(ref Button63, Classlar.DigerIslemler.ButtonJavaTipi.SoruMsgBox, "Naber Len \\nIbiş");
        /// </summary>
        /// <param name="C"></param>
        /// <param name="T"></param>
        /// <param name="MesajMetni"></param>
        public static void ButtonJavaEkle(ref Button C, ButtonJavaTipi T,string MesajMetni)
        {
            switch (T)
            { 
                case ButtonJavaTipi.MsgBox:
                    C.Attributes.Add("OnClick", "javascript:alert('" + MesajMetni + "');");
                    break;
                case ButtonJavaTipi.SoruMsgBox:
                    C.Attributes.Add("OnClick", "javascript:return confirm('" + MesajMetni + "');");
                    break;
            
            }
        
        }
        public enum TxBoxJavaTipi
        {
            KarekterUzunlugu = 1,
            SadeceInteger = 2
        }
        /// <summary>
        /// Classlar.DigerIslemler.TxBoxJavaEkle(ref TextBox23, Classlar.DigerIslemler.TxBoxJavaTipi.KarekterUzunlugu, ref Label9, "32");
        /// </summary>
        /// <param name="C"></param>
        /// <param name="T"></param>
        /// <param name="JavaFunctionGomebilecegimHerhangiBirLabel"></param>
        /// <param name="KarekterUzunlugu"></param>
        public static void TxBoxJavaEkle(ref TextBox C, TxBoxJavaTipi T, ref Label JavaFunctionGomebilecegimHerhangiBirLabel,string KarekterUzunlugu)
        {
            
            switch (T)
            {
                case TxBoxJavaTipi.KarekterUzunlugu:
                    C.Attributes.Add("onkeypress", "javascript:return checksize(this, " + KarekterUzunlugu + ")");
                    break;
                case TxBoxJavaTipi.SadeceInteger:
                    C.Attributes.Add("onkeyup", "javascript:return IntMi(this);");
                    break;

            }
            
            JavaFunctionGomebilecegimHerhangiBirLabel.Text += "" +
"        <script type=\"text/javascript\">" +
"             function checksize(obj, max)" +
"              { " +
"               return obj.value.length < max; " +
"              } " +
"             function IntMi(obj)" +
"              { " +
"                if(isNaN(obj.value))" +
"                 { " +
"                   obj.value = '';  " +
"                   return false;  " +
"                 }" +
"                 return true;" +
"              }   " +
"          </script>";

        }
        /// <summary>
        /// KucukYil,BuyukYil int türünden veri alacak,
        /// KucukYil -1 girersen 1940 dan başlar 
        /// BuyukYil Yılına -1 girersen 2040 da biter 
        /// her ikisine de -1 girersen 2040 - 1940 a kadar yıl dolar
        /// IlkDeger de gözükecek ilk değeri String olarak giriniz
        /// </summary>
        /// <param name="C"></param>
        /// <param name="BuYildanEski"></param>
        public static void YilDoldur(ref DropDownList C,int KucukYil,int BuyukYil,string IlkDeger)
        {
            C.Items.Clear();
            
           C.Items.Add(new ListItem(IlkDeger,"0"));

           for (int i = (BuyukYil == -1 ? 2040 : BuyukYil); i > (KucukYil == -1 ? 1940 : KucukYil-1); i--)
           {
               C.Items.Add(new ListItem(i.ToString(), i.ToString()));
           }
            
        }
        public static void AyDoldur(ref DropDownList C)
        {
            C.Items.Clear();
            ListItem[] li = new ListItem[] 
        {
new ListItem("Ay","0"),
new ListItem("Ocak","01"),
new ListItem("Şubat","02"),
new ListItem("Mart","03"),
new ListItem("Nisan","04"),
new ListItem("Mayıs","05"),
new ListItem("Haziran","06"),
new ListItem("Temmuz","07"),
new ListItem("Ağustos","08"),
new ListItem("Eylül","09"),
new ListItem("Ekim","10"),
new ListItem("Kasım","11"),
new ListItem("Aralık","12"),
        };

            C.Items.AddRange(li);

        }
        public static void AyDoldur(ref DropDownList C,string IlkDeger)
        {
            C.Items.Clear();
            ListItem[] li = new ListItem[] 
        {
new ListItem(IlkDeger,"0"),
new ListItem("Ocak","01"),
new ListItem("Şubat","02"),
new ListItem("Mart","03"),
new ListItem("Nisan","04"),
new ListItem("Mayıs","05"),
new ListItem("Haziran","06"),
new ListItem("Temmuz","07"),
new ListItem("Ağustos","08"),
new ListItem("Eylül","09"),
new ListItem("Ekim","10"),
new ListItem("Kasım","11"),
new ListItem("Aralık","12"),
        };

            C.Items.AddRange(li);

        }
        public static void GunDoldur(ref DropDownList C, string IlkDeger)
        {
            C.Items.Clear();
            ListItem[] li = new ListItem[] 
        {
new ListItem(IlkDeger,"0"),
new ListItem("1","01"),
new ListItem("2","02"),
new ListItem("3","03"),
new ListItem("4","04"),
new ListItem("5","05"),
new ListItem("6","06"),
new ListItem("7","07"),
new ListItem("8","08"),
new ListItem("9","09"),
new ListItem("10","10"),
new ListItem("11","11"),
new ListItem("12","12"),
new ListItem("13","13"),
new ListItem("14","14"),
new ListItem("15","15"),
new ListItem("16","16"),
new ListItem("17","17"),
new ListItem("18","18"),
new ListItem("19","19"),
new ListItem("20","20"),
new ListItem("21","21"),
new ListItem("22","22"),
new ListItem("23","23"),
new ListItem("24","24"),
new ListItem("25","25"),
new ListItem("26","26"),
new ListItem("27","27"),
new ListItem("28","28"),
new ListItem("29","29"),
new ListItem("30","30"),
new ListItem("31","31"),

        };

            C.Items.AddRange(li);

        }
        private static bool ColumnEqual(object A, object B)
        {
            if (A == DBNull.Value && B == DBNull.Value)
                return true;
            if (A == DBNull.Value || B == DBNull.Value)
                return false;
            return (A.Equals(B));
        }
        /// <summary>
        /// Datatable nin içindeki verileri distinct (tekrarsız) halde başka bi tabloya atmak için kullanılır 
        ///
        /// </summary>
        /// <param name="SourceTable"></param>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        public static DataTable SelectDistinct(DataTable KaynakTablo, string DistinctYapilacakColumnName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(DistinctYapilacakColumnName, KaynakTablo.Columns[DistinctYapilacakColumnName].DataType);

            object LastValue = null;
            foreach (DataRow dr in KaynakTablo.Select("", DistinctYapilacakColumnName))
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[DistinctYapilacakColumnName])))
                {
                    LastValue = dr[DistinctYapilacakColumnName];
                    dt.Rows.Add(new object[] { LastValue });
                }
            }
            return dt;
        }
    }
}
