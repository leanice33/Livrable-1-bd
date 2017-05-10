using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrDuDragon.Models;
using Oracle.DataAccess.Client;
using System.Data;


namespace OrDuDragon.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string Enoncer { get; set; }

        public string Reponce1 { get; set; }
        public string Reponce2 { get; set; }
        public string Reponce3 { get; set; }
        public string Reponce4 { get; set; }

        public bool Reponse1Bonne { get; set; }
        public bool Reponse2Bonne { get; set; }
        public bool Reponse3Bonne { get; set; }
        public bool Reponse4Bonne { get; set; }
        public string Dificulter { get; set; }
        public string flag { get; set; }

        public string question1_ran { get; set; }
        public string question2_ran { get; set; }
        public string question3_ran { get; set; }
        public string question4_ran { get; set; }
        public string question5_ran { get; set; }
        public Question() { }

        



    }
    public class Questions
    {
        private List<Question> List = new List<Question>();
    }
     
    

    


}