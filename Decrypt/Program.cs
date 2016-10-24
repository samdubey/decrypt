using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt
{
    class Program
    {
        static int Main(string[] args)
        {
            LicRead myLicRead = new LicRead();
            string str2 = Cript.Decrypt("U+CjI6H+gSlE1RzPT6L5hHsG/yIcvln+Libma8nOKzr/fWlb8THf9pNoxvsKphn0Gq4AG2jFmYmxn6zJVImziMslFne9QpQeV0GQ4DOKjENwbF38qZ8PQ3vgM83Qdftk+crE7+pPAEg7/5y/+W/GarUImLisLng+LUza2VTR3LjabxllZxwZODHX1ElwNDWwN0gc6wvXK3rpamzAB97N5YQQFZz20K8Pqs21PGIR0q6oOxAfKlFRLJnaE6ddd1BDyPWcX/Hp9NzwxjmjGTHDB6ROKp+npHJQ0nUocn0t6WRNMk7JbuDqZzvITlTkZacjRRfRoQtE72ggQcEYMog3dw==", "szlenkierow");
            Console.WriteLine(str2);
            if (str2 == "ErrorWodszyfrowaniu")
            {
                return -1;
            }
            else if (str2.IndexOf("ravignan") < 0)
            {
                return -1;
            }
            else
            {
                string plainKey = str2.Substring(0, str2.IndexOf("ravignan"));
                string signedHashAsStr = str2.Substring(str2.IndexOf("ravignan") + 8);
                if (!Cript.VerifySignature(plainKey, signedHashAsStr))
                {
                    return -1;
                }
                else
                {
                    string[] strArray1 = new string[1]
            {
              string.Empty
            };
                    string[] strArray2 = plainKey.Split(new char[1]
            {
              '|'
            });
                    if (strArray2.Length != 6)
                    {

                        return -1;
                    }
                    else
                    {
                        Console.WriteLine("Licence No:" + strArray2[0]);
                        Console.WriteLine("LicCompName:" + strArray2[1]);
                        int month = Convert.ToInt32(strArray2[2].Substring(0, 2));
                        int day = Convert.ToInt32(strArray2[2].Substring(2, 2));
                        int year = Convert.ToInt32(strArray2[2].Substring(4, 4));
                        try
                        {
                            myLicRead.LicExpDate = new DateTime(year, month, day);
                            Console.WriteLine("Expiry Date:" + new DateTime(year, month, day));
                        }
                        catch
                        {
                            myLicRead.LicExpDate = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
                            Console.WriteLine("Expiry Date:" + DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)));
                        }
                        TimeSpan timeSpan = new TimeSpan(0, 1, 0);
                        try
                        {
                            timeSpan = myLicRead.LicExpDate.Subtract(DateTime.Now);
                        }
                        catch
                        {
                        }
                        myLicRead.LicDaysLeft = timeSpan.Days;
                        myLicRead.LicType = strArray2[3];
                        if (strArray2[4].IndexOf("_") < 1)
                            strArray2[4] = strArray2[4] + "_0";
                        string[] strArray3 = strArray2[4].Split(new char[1]
              {
                '_'
              });
                        myLicRead.LicLogUsers = Convert.ToInt32(strArray3[0]);
                        myLicRead.LicReadUsers = Convert.ToInt32(strArray3[1]);
                        myLicRead.LicVersion = 2;
                        if (Convert.ToInt32(strArray2[5].Substring(8, 1)) > 2)
                            myLicRead.LicVersion = Convert.ToInt32(strArray2[5].Substring(8, 1));
                        myLicRead.LicSystem = 2;
                        myLicRead.LicEdition = 0;
                        if (myLicRead.LicVersion == 3)
                        {
                            myLicRead.LicSystem = Convert.ToInt32(strArray2[5].Substring(9, 1));
                            myLicRead.LicEdition = Convert.ToInt32(strArray2[5].Substring(10, 1));
                            myLicRead.LicIsServer = 0;
                        }
                        if (myLicRead.LicVersion == 4)
                        {
                            myLicRead.LicSystem = Convert.ToInt32(strArray2[5].Substring(9, 1));
                            myLicRead.LicEdition = Convert.ToInt32(strArray2[5].Substring(10, 1));
                            myLicRead.LicIsServer = Convert.ToInt32(strArray2[5].Substring(11, 1));
                            //if (myLicRead.LicType == "T" && !GlobCnst.isEdFREE)
                            //{
                            //    if (GlobCnst.isEdLIGHT)
                            //        myLicRead.LicEdition = 1;
                            //    if (GlobCnst.isEdSTD)
                            //        myLicRead.LicEdition = 2;
                            //    if (GlobCnst.isEdPRO)
                            //        myLicRead.LicEdition = 3;
                            //    if (GlobCnst.isEdSRV)
                            //        myLicRead.LicIsServer = 1;
                            //}
                        }
                        return 1;
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
