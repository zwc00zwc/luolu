using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Luolu.Interface;
using Luolu.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Luolu.Common;

namespace Luolu.Service
{
    public class ProductInfoService:ServiceBase, IProductInfo
    {
        public List<ProductInfo> SearchBypage(int currpage, int pagesize)
        {
            int startindex = (currpage - 1) * pagesize;
            int endindex = currpage * pagesize;
            List<ProductInfo> list = new List<ProductInfo>();
            MySqlParameter startparmter = new MySqlParameter("startindex", MySqlDbType.Int32);
            startparmter.Value = startindex;
            MySqlParameter endparmter = new MySqlParameter("endindex", MySqlDbType.Int32);
            endparmter.Value = endindex;
            try
            {
                DataTable dt = Luolu.Common.MySqlHelper.Search(@"SELECT * FROM himall_products WHERE Id LIMIT @startindex,@endindex", new MySqlParameter[] { startparmter, endparmter });
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProductInfo info = new ProductInfo();
                        info.Id = (long)dt.Rows[i]["Id"];
                        info.ProductName = dt.Rows[i]["ProductName"].ToString();
                        info.AuditStatus = (int)dt.Rows[i]["AuditStatus"];
                        info.SaleStatus = (int)dt.Rows[i]["SaleStatus"];
                        info.ShopId = (long)dt.Rows[i]["ShopId"];
                        info.CategoryId = (long)dt.Rows[i]["CategoryId"];
                        info.CategoryPath = dt.Rows[i]["CategoryPath"].ToString();
                        info.BrandId = (long)dt.Rows[i]["BrandId"];
                        info.MinSalePrice = (decimal)dt.Rows[i]["MinSalePrice"];
                        info.SaleCounts = (long)dt.Rows[i]["SaleCounts"];
                        info.AddedDate = (DateTime)dt.Rows[i]["AddedDate"];
                        info.FreightTemplateId = (long)dt.Rows[i]["FreightTemplateId"];
                        list.Add(info);
                    }
                }
            }
            catch (Exception ex)
            {
                //Utility.writelog("MySQL获取数据出错" + ex.ToString());
            }
            return list;
        }


        public int Searchcount()
        {
            int num = 0;
            try
            {
                DataTable dt = Luolu.Common.MySqlHelper.Search(@"select count(*) as cou from himall_products");
                if (dt.Rows.Count == 1)
                {
                    num = int.Parse(dt.Rows[0]["cou"].ToString());
                }
            }
            catch (Exception ex)
            {
                //Utility.writelog("MySQL获取条数出错" + ex.ToString());
            }
            return num;
        }
    }
}