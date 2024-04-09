
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Common;
using DAL;
using LSEXT;
using LSSERVICEPROVIDERLib;

namespace AshChoise
{


    [ComVisible(true)]
    [ProgId("AshChoiseCls.AshChoisecls")]
    public class AshChoiseCls : IWorkflowChoice
    {
        private INautilusServiceProvider sp;



        bool IWorkflowChoice.Execute(ref LSExtensionParameters Parameters)
        {
       
            sp = Parameters["SERVICE_PROVIDER"];
            var ntlsCon = Utils.GetNtlsCon(sp);
            Utils.CreateConstring(ntlsCon);
            foreach (var lsExtensionParameter in Parameters)
            {
                var r=lsExtensionParameter;
                var aa = r.Name;
            }
            var records = Parameters["RECORDS"];
            var samplesIDs = new List<string>();

            int x = 0;
           var a= records.Fields[x++].Value;
           a = records.Fields[x++].Value;
           a = records.Fields[x++].Value;
           a = records.Fields[x++].Value;
           a = records.Fields[x++].Value;
           a = records.Fields[x++].Value;
           a = records.Fields[x++].Value;
           
            double sampleID = records.Fields["SAMPLE_ID"].Value;

            var dal = new DataLayer();
            dal.Connect();
            var sample=dal.GetSampleByKey((long)sampleID);
            var aliquot = sample.Aliqouts.Where(aliq => aliq.AliquotTemplate.Name == "בדיקת אפר").FirstOrDefault();
            if (aliquot!=null&&aliquot.Status=="C")
            {
                return true;
            }
            return true;
        }
    }
}
    