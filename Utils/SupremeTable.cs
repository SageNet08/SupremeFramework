using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SupremeFramework.Utils
{//hello 
    public class SupremeTable
    {
        public void tableConvert(Table table, List<Dictionary<string, string>> tableData)
        {
            foreach (TableRow row in table.Rows)
            {

                var rowData = new Dictionary<string, string>();
                
                foreach (var header in table.Header)
                {
                    rowData[header] = row[header];
                }

                tableData.Add(rowData);

            }

        }
    }
}
