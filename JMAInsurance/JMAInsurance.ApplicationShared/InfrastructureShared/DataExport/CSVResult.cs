﻿using System.Collections;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JMAInsurance.ApplicationShared.InfrastructureShared.DataExport
{
    public class CSVResult : FileResult
    {
        private IEnumerable _data;

        public CSVResult(IEnumerable data, string fileName) : base("text/csv") // base("text/csv") for header content type 
        {
            _data = data;
            FileDownloadName = fileName;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);

            foreach (var item in _data)
            {
                var properties = item.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    stringWriter.Write(GetValue(item, prop.Name));
                    stringWriter.Write(", ");
                }
                stringWriter.WriteLine();
            }

            response.Write(builder);
        }

        public static string GetValue(object item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null).ToString() ?? "";
        }
    }
}
