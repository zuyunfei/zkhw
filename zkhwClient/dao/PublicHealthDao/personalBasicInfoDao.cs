using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace zkhwClient.dao
{
    class personalBasicInfoDao
    {
        public DataTable queryPersonalBasicInfo(string name, string id_number, string aichive_no)
        {
            DataSet ds = new DataSet();
            string sql = "select id,name,id_number,create_name,create_time,doctor_name,synchro_result from resident_base_info where 1=1";
            if (name != "") { sql += " and name like '%" + name + "%'"; }
            if (id_number != "") { sql += " and id_number like '%" + id_number + "%'"; }
            if (aichive_no != "") { sql += " and aichive_no like '%" + aichive_no + "%'"; }
            ds = DbHelperMySQL.Query(sql);
            return ds.Tables[0];
        }

        public bool deletePersonalBasicInfo(string id)
        {
            int rt = 0;
            string sql = "delete from resident_base_info where id='" + id + "';delete from resident_diseases  where resident_base_info_id = '" + id + "';";
            rt = DbHelperMySQL.ExecuteSql(sql);
            return rt == 0 ? false : true;
        }
        //public bool aUfuv_hypertension(bean.fuv_hypertensionBean hm, string id, DataTable goodsList)
        //{
        //    //int ret = 0;
        //    //String sql = "";
        //    //String sql0 = "";
        //    //if (id == "")
        //    //{
        //    //    id = Result.GetNewId();
        //    //    sql = @"insert into resident_base_info (id,archive_no,pb_archive,name,sex,birthday,id_number,address,nation,IssuingAgencies,CardPic,company,phone,link_name,link_phone,resident_type,register_address,residence_address,blood_group,blood_rh,education,profession,marital_status,pay_type,pay_other,drug_allergy,allergy_other,exposure,disease_other,is_hypertension,is_diabetes,is_psychosis,is_tuberculosis,is_heredity,heredity_name,is_deformity,deformity_name,is_poor,kitchen,fuel,other_fuel,drink,other_drink,toilet,poultry,medical_code,photo_code,aichive_org,doctor_name,is_signing,is_synchro,synchro_result,synchro_time,create_user,create_name,create_time,create_org,create_org_name,update_user,update_name,update_time) values ";
        //    //    sql += @" ('" + id + "','" + hm.aichive_no + "', '" + hm.pb_archive + "', '" + hm.name + "', '" + hm.sex + "', '" + hm.birthday + "', '" + hm.id_number + "', '" + hm.address + "', '" + hm.nation + "', '" + hm.IssuingAgencies + "', '" + hm.CardPic + "','" + hm.company + "', '" + hm.phone + "', '" + hm.link_name + "', '" + hm.link_phone + "', '" + hm.resident_type + "', '" + hm.register_address + "', '" + hm.blood_group + "', '" + hm.blood_rh + "', '" + hm.education + "', '" + hm.profession + "','" + hm.marital_status + "', '" + hm.pay_type + "', '" + hm.pay_other + "', '" + hm.drug_allergy + "', '" + hm.allergy_other + "', '" + hm.exposure + "', '" + hm.disease_other + "', '" + hm.is_hypertension + "', '" + hm.is_diabetes + "', '" + hm.is_psychosis + "','" + hm.is_tuberculosis + "', '" + hm.is_heredity + "', '" + hm.heredity_name + "', '" + hm.is_deformity + "', '" + hm.deformity_name + "', '" + hm.is_poor + "', '" + hm.kitchen + "', '" + hm.fuel + "', '" + hm.other_fuel + "', '" + hm.drink + "','" + hm.other_drink + "', '" + hm.toilet + "', '" + hm.poultry + "', '" + hm.medical_code + "', '" + hm.photo_code + "', '" + hm.aichive_org + "', '" + hm.doctor_name + "', '" + hm.is_signing + "', '" + hm.is_synchro + "', '" + hm.synchro_result + "', '" + hm.synchro_time + "', '" + hm.create_user + "','" + hm.create_name + "', '" + hm.create_time + "', '" + hm.create_org + "', '" + hm.create_org_name + "', '" + hm.update_user + "', '" + hm.update_name + "', '" + hm.update_time + "')";
        //    //}
        //    //else
        //    //{
        //    //    sql = @"update fuv_hypertension set aichive_no ='" + hm.aichive_no + "',Cardcode='" + hm.Cardcode + "',Codebar='" + hm.Codebar + "',SocialSecuritycode='" + hm.SocialSecuritycode + "',patientName='" + hm.patientName + "',patientAge='" + hm.patientAge + "',dataSate='" + hm.dataSate + "',hypertension_code='" + hm.hypertension_code + "',visit_date='" + hm.visit_date + "',visit_type='" + hm.visit_type + "',symptom='" + hm.symptom + "',other_symptom='" + hm.other_symptom + "',sbp='" + hm.sbp + "',dbp='" + hm.dbp + "',weight='" + hm.weight + "',target_weight='" + hm.target_weight + "',bmi='" + hm.bmi + "',target_bmi='" + hm.target_bmi + "',heart_rate='" + hm.heart_rate + "',other_sign= '" + hm.other_sign + "',smoken='" + hm.smoken + "',target_somken='" + hm.target_somken + "',wine= '" + hm.wine + "',target_wine= '" + hm.target_wine + "',sport_week='" + hm.sport_week + "',sport_once='" + hm.sport_once + "',target_sport_week= '" + hm.target_sport_week + "',target_sport_once='" + hm.target_sport_once + "',salt_intake='" + hm.salt_intake + "',target_salt_intake='" + hm.target_salt_intake + "',mind_adjust='" + hm.mind_adjust + "',doctor_obey= '" + hm.doctor_obey + "',assist_examine='" + hm.assist_examine + "',drug_obey='" + hm.drug_obey + "',untoward_effect='" + hm.untoward_effect + "',untoward_effect_drug='" + hm.untoward_effect_drug + "',visit_class='" + hm.visit_class + "',referral_code='" + hm.referral_code + "',next_visit_date='" + hm.next_visit_date + "',visit_doctor='" + hm.visit_doctor + "',advice='" + hm.advice + "',create_name='" + hm.create_name + "',create_time='" + hm.create_time + "',update_name='" + hm.update_name + "',update_time='" + hm.update_time + "',transfer_organ='" + hm.transfer_organ + "',transfer_reason='" + hm.transfer_reason + "' where id = '" + id + "'";

        //    //}
        //    //ret = DbHelperMySQL.ExecuteSql(sql);
        //    //return ret == 0 ? false : true;
        //}
        public DataTable queryPersonalBasicInfo0(string id)
        {
            DataSet ds = new DataSet();
            string sql = "select * from resident_base_info where id = '" + id + "'";
            ds = DbHelperMySQL.Query(sql);
            return ds.Tables[0];
        }
        public DataTable queryResident_diseases(string resident_base_info_id)
        {
            DataSet ds = new DataSet();
            string sql = "select id,resident_base_info_id,disease_name,disease_date from resident_diseases where resident_base_info_id = '" + resident_base_info_id + "'";
            ds = DbHelperMySQL.Query(sql);
            return ds.Tables[0];
        }
        public DataTable queryOperation_record(string resident_base_info_id)
        {
            DataSet ds = new DataSet();
            string sql = "select id,resident_base_info_id,operation_name,operation_time from operation_record where resident_base_info_id = '" + resident_base_info_id + "'";
            ds = DbHelperMySQL.Query(sql);
            return ds.Tables[0];
        }
        

    }
}

