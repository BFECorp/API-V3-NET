using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    /// <summary>
    /// 地址
    /// </summary>
    public class BaseAddress
    {
        protected static readonly String DEFAULT_VALUE = String.Empty;

        public BaseAddress()
        {
            Contact = DEFAULT_VALUE;
            Street1 = DEFAULT_VALUE;
            Street2 = DEFAULT_VALUE;
            City = DEFAULT_VALUE;
            Province = DEFAULT_VALUE;
            PostCode = DEFAULT_VALUE;
            Country = DEFAULT_VALUE;
            Email = DEFAULT_VALUE;
            Phone = DEFAULT_VALUE;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }


        private string _street1 = DEFAULT_VALUE;
        /// <summary>
        /// 街道1
        /// </summary>
        public string Street1
        {
            get { return _street1; }
            set
            {
                _street1 = value;
            }
        }

        private string _street2 = DEFAULT_VALUE;
        /// <summary>
        /// 街道2
        /// </summary>
        public string Street2
        {
            get { return _street2; }
            set
            {
                _street2 = value;
            }
        }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 省/州
        /// </summary>
        public string Province { get; set; }

        private string _country = DEFAULT_VALUE;
        /// <summary>
        /// 国家
        /// </summary>
        public string Country
        {
            get { return _country; }
            set
            {
                //var val = _country;
                value = value.Trim();
                _country = value;
            }
        }

        private static bool IsAliasName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length == 2;
        }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 验证地址
        /// </summary>
        /// <param name="address"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static StringBuilder ValidAddress(BaseAddress address, string prefix, int? warehouseId = null)
        {
            StringBuilder sbResult = new StringBuilder();

            if (String.IsNullOrEmpty(address.Contact))
            {
                sbResult.AppendLine(string.Format("{0}Contact不能为空", prefix));
            }
            else if (address.Contact.Length > 50)
            {
                sbResult.AppendLine(string.Format("{0}Contact 长度超过50", prefix));
            }

            if (String.IsNullOrEmpty(address.Street1))
            {
                sbResult.AppendLine(string.Format("{0}Street1不能为空", prefix));
            }
            else if (address.Street1.Length > 100)
            {
                sbResult.AppendLine(string.Format("{0}Street1 长度超过100", prefix));
            }

            if (address.Street2.Length > 100)
            {
                sbResult.AppendLine(string.Format("{0}Street2 长度超过100", prefix));
            }

            if (String.IsNullOrEmpty(address.City))
            {
                sbResult.AppendLine(string.Format("{0}City不能为空", prefix));
            }
            else if (address.City.Length > 50)
            {
                sbResult.AppendLine(string.Format("{0}City 长度超过50", prefix));
            }

            if (warehouseId == null || (warehouseId.HasValue && warehouseId.Value == 343))
            {
                if (String.IsNullOrEmpty(address.Province))
                {
                    sbResult.AppendLine(string.Format("{0}Province不能为空", prefix));
                }
                else if (address.Province.Length > 100)
                {
                    sbResult.AppendLine(string.Format("{0}Province 长度超过100", prefix));
                }
            }

            if (String.IsNullOrEmpty(address.Country))
            {
                sbResult.AppendLine(string.Format("{0}Country不能为空", prefix));
            }
            else if (address.Country.Length > 50)
            {
                sbResult.AppendLine(string.Format("{0}Country 长度超50", prefix));
            }

            if (String.IsNullOrEmpty(address.PostCode))
            {
                sbResult.AppendLine(string.Format("{0}PostCode不能为空.", prefix));
            }
            else if (address.PostCode.Length > 20)
            {
                sbResult.AppendLine(string.Format("{0}PostCode 长度超过20", prefix));
            }

            if (address.Email.Length > 100)
            {
                sbResult.AppendLine(string.Format("{0}Email 长度超过100", prefix));
            }

            if (address.Phone.Length > 20)
            {
                sbResult.AppendLine(string.Format("{0}Phone 长度超过20", prefix));
            }

            return sbResult;
        }

        
        /// <summary>
        /// 验证地址
        /// </summary>
        /// <param name="address"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static StringBuilder ValidAddress(ShipToAddress address, string prefix, bool checkProvince = false)
        {
            StringBuilder sbResult = null;
            if (checkProvince)
            {
                sbResult = ValidAddress(address as BaseAddress, prefix);
            }
            else
            {
                sbResult = ValidAddress(address as BaseAddress, prefix, 0);
            }
            return sbResult;
        }
    }

    public class ShipToAddress : BaseAddress
    {

    }


}
