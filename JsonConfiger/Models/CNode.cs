using DZY.DotNetUtil.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JsonConfiger.Models
{
    public class CNode : ObservableObject
    {
        #region properties

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

        #region Children

        /// <summary>
        /// The <see cref="Children" /> property's name.
        /// </summary>
        public const string ChildrenPropertyName = "Children";

        private ObservableCollection<CNode> _Children;

        /// <summary>
        /// Children
        /// </summary>
        public ObservableCollection<CNode> Children
        {
            get { return _Children; }

            set
            {
                if (_Children == value) return;

                _Children = value;
                NotifyOfPropertyChange(ChildrenPropertyName);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The <see cref="Properties" /> property's name.
        /// </summary>
        public const string PropertiesPropertyName = "Properties";

        private ObservableCollection<CProperty> _Properties;

        /// <summary>
        /// Properties
        /// </summary>
        public ObservableCollection<CProperty> Properties
        {
            get { return _Properties; }

            set
            {
                if (_Properties == value) return;

                _Properties = value;
                NotifyOfPropertyChange(PropertiesPropertyName);
            }
        }

        #endregion

        #endregion
    }
}
