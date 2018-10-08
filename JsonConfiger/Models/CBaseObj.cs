using DZY.DotNetUtil.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonConfiger.Models
{
    public class CBaseObj : ObservableObject
    {
        #region Name

        /// <summary>
        /// The <see cref="Name" /> property's name.
        /// </summary>
        public const string NamePropertyName = "Name";

        private string _Name;

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _Name; }

            set
            {
                if (_Name == value) return;

                _Name = value;
                NotifyOfPropertyChange(NamePropertyName);
            }
        }

        #endregion

        #region Lan

        /// <summary>
        /// The <see cref="Lan" /> property's name.
        /// </summary>
        public const string LanPropertyName = "Lan";

        private string _Lan;

        /// <summary>
        /// Lan
        /// </summary>
        public string Lan
        {
            get { return _Lan; }

            set
            {
                if (_Lan == value) return;

                _Lan = value;
                NotifyOfPropertyChange(LanPropertyName);
            }
        }

        #endregion

        #region LanKey

        /// <summary>
        /// The <see cref="LanKey" /> property's name.
        /// </summary>
        public const string LanKeyPropertyName = "LanKey";

        private string _LanKey;

        /// <summary>
        /// 多语言切换用的key
        /// </summary>
        public string LanKey
        {
            get { return _LanKey; }

            set
            {
                if (_LanKey == value) return;

                _LanKey = value;
                NotifyOfPropertyChange(LanKeyPropertyName);
            }
        }

        #endregion

        #region UID

        /// <summary>
        /// The <see cref="UID" /> property's name.
        /// </summary>
        public const string UIDPropertyName = "UID";

        private string _UID;

        /// <summary>
        /// UID
        /// </summary>
        public string UID
        {
            get { return _UID; }

            set
            {
                if (_UID == value) return;

                _UID = value;
                NotifyOfPropertyChange(UIDPropertyName);
            }
        }

        #endregion
    }
}
