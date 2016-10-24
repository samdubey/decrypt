using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt
{
    public class LicRead
    {
        private int _ErrorCode;
        private string _LicenseString;
        private string _LicenseNo;
        private int _LicLogUsers;
        private int _LicReadUsers;
        private string _LicCompName;
        private string _LicType;
        private DateTime _LicExpDate;
        private int _LicDaysLeft;
        private int _LicVersion;
        private int _LicSystem;
        private int _LicEdition;
        private int _LicIsServer;

        public int ErrorCode
        {
            get
            {
                return this._ErrorCode;
            }
            set
            {
                this._ErrorCode = value;
            }
        }

        public string LicenseString
        {
            get
            {
                return this._LicenseString;
            }
            set
            {
                this._LicenseString = value;
            }
        }

        public string LicenseNo
        {
            get
            {
                return this._LicenseNo;
            }
            set
            {
                this._LicenseNo = value;
            }
        }

        public int LicLogUsers
        {
            get
            {
                return this._LicLogUsers;
            }
            set
            {
                this._LicLogUsers = value;
            }
        }

        public int LicReadUsers
        {
            get
            {
                return this._LicReadUsers;
            }
            set
            {
                this._LicReadUsers = value;
            }
        }

        public string LicCompName
        {
            get
            {
                return this._LicCompName;
            }
            set
            {
                this._LicCompName = value;
            }
        }

        public string LicType
        {
            get
            {
                return this._LicType;
            }
            set
            {
                this._LicType = value;
            }
        }

        public int LicDaysLeft
        {
            get
            {
                return this._LicDaysLeft;
            }
            set
            {
                this._LicDaysLeft = value;
            }
        }

        public DateTime LicExpDate
        {
            get
            {
                return this._LicExpDate;
            }
            set
            {
                this._LicExpDate = value;
            }
        }

        public int LicVersion
        {
            get
            {
                return this._LicVersion;
            }
            set
            {
                this._LicVersion = value;
            }
        }

        public int LicSystem
        {
            get
            {
                return this._LicSystem;
            }
            set
            {
                this._LicSystem = value;
            }
        }

        public int LicEdition
        {
            get
            {
                return this._LicEdition;
            }
            set
            {
                this._LicEdition = value;
            }
        }

        public int LicIsServer
        {
            get
            {
                return this._LicIsServer;
            }
            set
            {
                this._LicIsServer = value;
            }
        }

        public LicRead()
        {
            this._ErrorCode = 0;
            this._LicenseString = "";
            this._LicenseNo = "";
            this._LicLogUsers = 0;
            this._LicReadUsers = 0;
            this._LicCompName = "";
            this._LicType = "";
            this._LicDaysLeft = 0;
            this._LicExpDate = DateTime.Now;
            this._LicVersion = 0;
            this._LicSystem = 0;
            this._LicEdition = 0;
            this._LicIsServer = 0;
        }
    }
}
