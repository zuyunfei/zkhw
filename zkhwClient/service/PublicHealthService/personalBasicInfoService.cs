using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace zkhwClient.service
{
    class personalBasicInfoService
    {
        dao.personalBasicInfoDao hPD = new dao.personalBasicInfoDao();
        public DataTable queryPersonalBasicInfo(string name, string id_number, string aichive_no)
        {
            return hPD.queryPersonalBasicInfo(name, id_number, aichive_no);
        }
        public bool deletePersonalBasicInfo(string id)
        {
            return hPD.deletePersonalBasicInfo(id);
        }
        //public bool aUfuv_hypertension(bean.fuv_hypertensionBean hm, string id, DataTable goodsList)
        //{
        //    return hPD.aUfuv_hypertension(hm, id, goodsList);
        //}
        public DataTable queryPersonalBasicInfo0(string id)
        {
            return hPD.queryPersonalBasicInfo0(id);
        }
        public DataTable queryResident_diseases(string resident_base_info_id)
        {
            return hPD.queryResident_diseases(resident_base_info_id);
        }
        public DataTable queryOperation_record(string resident_base_info_id)
        {
            return hPD.queryOperation_record(resident_base_info_id);
        }
        public DataTable queryTraumatism_record(string resident_base_info_id)
        {
            return hPD.queryTraumatism_record(resident_base_info_id);
        }
        

    }
}
