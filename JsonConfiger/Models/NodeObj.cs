using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JsonConfiger.Models
{
    public class NodeObj : ObservableObject
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

        #region Children

        /// <summary>
        /// The <see cref="Children" /> property's name.
        /// </summary>
        public const string ChildrenPropertyName = "Children";

        private ObservableCollection<NodeObj> _Children;

        /// <summary>
        /// Children
        /// </summary>
        public ObservableCollection<NodeObj> Children
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

        #endregion


    }
}
