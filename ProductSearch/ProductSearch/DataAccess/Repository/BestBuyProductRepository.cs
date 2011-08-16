using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using ProductSearch.Exceptions;
using ProductSearch.Model;
using ProductSearch.Utility;

/*
 * Parts obtained from Remix.NET
 * http://code.google.com/p/remixdotnet/
 */

namespace ProductSearch.DataAccess.Repository
{
    public class BestBuyProductRepository : IProductSearchRepository
    {
        private static readonly Logger Log = new Logger(typeof(BestBuyProductRepository));
        private const string SearchUrl = "http://api.remix.bestbuy.com/v1/products(name='{0}*')?apiKey=x4p9sbyznrgjnxwdadqz25qe";

        public ProductSearchResult Search(string criteria)
        {
            Log.Debug("Search - Begin.");

            try
            {
                var results = GetProduct(criteria);
                var returnVal = new ProductSearchResult(false, false, results.FirstOrDefault());

                Log.Debug("Search - End.");

                return returnVal;
            }
            catch (DataAccessException e)
            {
                Log.Error("Search - Error.", e);
                return new ProductSearchResult(false, true, null);
            }
        }

        private static string GetOutputFromUrl(string url)
        {
            try
            {
                // Create the web request   
                var request = WebRequest.Create(url) as HttpWebRequest;

                // HACK: Fixes "417 Expectation Failed".
                ServicePointManager.Expect100Continue = false;

                // Get response   
                var response = request.GetResponse() as HttpWebResponse;

                // check return codes
                //200 OK: everything went awesome.
                if (response.StatusCode == HttpStatusCode.OK)
                    return new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8).ReadToEnd();
                else
                {
                    Log.Warn(string.Format("GetOutputFromUrl - Bad HttpStatusCode: {0}", response.StatusCode));
                    return null;
                }
            }
            catch (WebException we)
            {
                throw new DataAccessException("GetOutputFromUrl - Error.", we);
            }
            catch (Exception e)
            {
                throw new DataAccessException("GetOutputFromUrl - Error.", e);
            }
        }
        
        private static IEnumerable<Product> GetProduct(string productName)
        {
            try
            {
                var searchUrl = string.Format(SearchUrl, productName);

                var output = GetOutputFromUrl(searchUrl);

                var p = Utf8XmlSerializer.Deserialize<Products>(output);

                return p;
            }
            catch (Exception e)
            {
                Log.Error("GetProduct - Error.", e);
                throw new DataAccessException("GetProduct - Error.", e);
            }
        }

    }
}
