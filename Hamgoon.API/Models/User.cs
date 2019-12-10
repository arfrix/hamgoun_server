namespace Hamgoon.API.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImgUrl { get; set; }
        public long Hamegyry { get; set; }
        public long Hamrahy { get; set; }

        public bool PhoneVerifed { get; set; }
        public int SMSCode { get; set; }
        public bool EmailVerifed { get; set; }
        public int EmailCode { get; set; }

        public string StickerUrl1 { get; set; }
        public string StickerUrl2 { get; set; }
        public string StickerUrl3 { get; set; }
        public string StickerUrl4 { get; set; }
        public string StickerUrl5 { get; set; }

        //bio
        public string Edu_highSchool { get; set; }
        public string Edu_univercity { get; set; }
        public string Edu_subject { get; set; }
        public string Work_job { get; set; }
        public string Work_company { get; set; }
        public string Location_motherTown { get; set; }
        public string Location_livingCountry { get; set; }
        public string Location_livingTown { get; set; }
        public string Languge_motherTongue { get; set; }
        public string Languge_dialect { get; set; }
        public string Languge_secondLangName { get; set; }
        public string Languge_thirdLangName { get; set; }
        public string Languge_forthLangName { get; set; }
        public string Relation { get; set; }
        public string Sport_name { get; set; }
        public string Sport_teamName { get; set; }
        public string Sport_playerName { get; set; }
        public string Movie_category1Name { get; set; }
        public string Movie_category2Name { get; set; }
        public string Book_category1Name { get; set; }
        public string Book_category2Name { get; set; }
        public string Music_category1Name { get; set; }
        public string Music_category2Name { get; set; }
        
        
        public string Skill_mainSkillName{ get; set; }
        public string Skill_secondSkillName { get; set; }
        public string Teach_mainTeachName { get; set; }
        public string Teach_secondTeachName { get; set; }

    }
}
