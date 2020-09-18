using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhanMem_QuanlySpa
{
    public class DinhDangAll
    {
        private static DinhDangAll instance;

        public static DinhDangAll Instance
        {
            get { if (instance == null) instance = new DinhDangAll(); return DinhDangAll.instance; }
            private set { DinhDangAll.instance = value; }
        }
        private DinhDangAll() { }

        public bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public bool isNumberPhone(string numberphone)
        {
            string strRegex = @"^\d{10}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(numberphone))
                return true;
            else
                return false;
        }


        public bool isCMND(string numberphone)
        {
            string strRegex = @"^\d{9}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(numberphone))
                return true;
            else
                return false;
        }
    }
}
