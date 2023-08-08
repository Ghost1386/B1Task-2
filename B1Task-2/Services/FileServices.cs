using System.Collections.Generic;
using System.Linq;
using B1Task_2.Models;
using IronXL;

namespace B1Task_2.Services;

public class FileServices
{
    private const string LicenseKey = "IRONSUITE.EGOR555.NOVIK.GMAIL.COM.26710-84D7F76A87-ADXDYWC-BU5IVGKEEQRE-DNGW6QBIXZL4-VV4QGYXAQRF7-44COULPHHSHJ-QWMZZGH4TPHO-5Z46UDEAQU6I-34P7KA-TKJARXLM3AKKUA-DEPLOYMENT.TRIAL-XBIB5Y.TRIAL.EXPIRES.06.SEP.2023";
    public List<BaseClassModel> ReadFromFile(string excelFilePath, int initialLine, int endLine)
    {
        if (IsLicensed())
        {
            var workBook = WorkBook.Load(excelFilePath);
            var workSheet = workBook.WorkSheets.First();
        
            var listBaseClassModel = new List<BaseClassModel>();
        
            for (var i = initialLine; i <= endLine; i++)
            {
                var list = new List<string?>();
            
                foreach (var cell in workSheet[$"A{i}:G{i}"])
                {
                    list.Add(cell.Text);
                }
            
                var baseClassModel = new BaseClassModel
                {
                    Bc = list[0],
                    OpeningBalanceAssets = double.Parse(list[1]!),
                    OpeningBalancePassive = double.Parse(list[2]!),
                    TurnoversAssets = double.Parse(list[3]!),
                    TurnoversPassive = double.Parse(list[4]!),
                    OutgoingBalanceAssets = double.Parse(list[5]!),
                    OutgoingBalancePassive = double.Parse(list[6]!),
                };
        
                listBaseClassModel.Add(baseClassModel);
            }

            return listBaseClassModel;
        }

        return new List<BaseClassModel>();
    }

    private static bool IsLicensed()
    {
        License.LicenseKey = LicenseKey;
            
        return License.IsLicensed;
    }
}