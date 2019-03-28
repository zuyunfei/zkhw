using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zkhwClient.bean
{
    class diabetes_follow_recordBean
    {
        //姓名
        public string name { get; set; }
        //电子档案编码
        public string aichive_no { get; set; }
        //身份证号
        public string id_number { get; set; }
        //访问日期
        public string visit_date { get; set; }
        //访问类型
        public string visit_type { get; set; }
        //症状
        public string symptom { get; set; }
        //症状其他
        public string symptom_other { get; set; }
        //血压高压
        public string blood_pressure_high { get; set; }
        //血压低压
        public string blood_pressure_low { get; set; }
        //目前体重
        public string weight_now { get; set; }
        //下次体重
        public string weight_next { get; set; }
        //目前体质指数
        public string bmi_now { get; set; }
        //下次体质指数
        public string bmi_next { get; set; }
        //足背动脉搏动
        public string dorsal_artery { get; set; }
        //other
        public string other { get; set; }
        //现在每天吸烟量
        public string smoke_now { get; set; }
        //下次随访每天吸烟目标
        public string smoke_next { get; set; }
        //现在每天饮酒量
        public string drink_now { get; set; }
        //下次随访每天饮酒目标量
        public string drink_next { get; set; }
        //目前每周运动次数
        public string sports_num_now { get; set; }
        //目前每次运动时长
        public string sports_time_now { get; set; }
        //下次每周运动次数目标
        public string sports_num_next { get; set; }
        //下次每次运动时长目标
        public string sports_time_next { get; set; }
        //目前每天主食量
        public string staple_food_now { get; set; }
        //下次每天主食目标
        public string staple_food_next { get; set; }
        //心理调整
        public string psychological_recovery { get; set; }
        //遵医行为
        public string medical_compliance { get; set; }
        //空腹血糖值
        public string blood_glucose { get; set; }
        //糖化血红蛋白
        public string glycosylated_hemoglobin { get; set; }
        //检查日期
        public string check_date { get; set; }
        //服药依从性
        public string compliance { get; set; }
        //药物不良反应
        public string untoward_effect { get; set; }
        //低血糖反应
        public string reactive_hypoglycemia { get; set; }
        //此次随访分类
        public string follow_type { get; set; }
        //评价与建议
        public string advice { get; set; }
        //胰岛素名称
        public string insulin_name { get; set; }
        //insulin_usage
        public string insulin_usage { get; set; }
        //是否转诊
        public string transfer_treatment { get; set; }
        //转诊原因
        public string transfer_treatment_reason { get; set; }
        //转诊机构和科别
        public string transfer_treatment_department { get; set; }
        //next_visit_date
        public string next_visit_date { get; set; }
        //visit_doctor
        public string visit_doctor { get; set; }
        //create_user
        public string create_user { get; set; }
        //create_name
        public string create_name { get; set; }
        //create_org
        public string create_org { get; set; }
        //create_org_name
        public string create_org_name { get; set; }
        //create_time
        public string create_time { get; set; }
        //update_user
        public string update_user { get; set; }
        //update_name
        public string update_name { get; set; }
        //update_time
        public string update_time { get; set; }
        //upload_status
        public string upload_status { get; set; }
        //upload_time
        public string upload_time { get; set; }
        //upload_result
        public string upload_result { get; set; }

    }
}
