using Autentification.Controllers;
using OrDuDragon.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.ManagedDataAccess.Client;



// TODO :: handle error page create a new view for that
namespace OrDuDragon.Controllers
{
    public class QuestionsController : Controller
    {

        public DataSet ListeQuestion = new DataSet();
        [AuthorisationRequired]
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //[AuthorisationRequired]
        //public ActionResult Create()
        //{
        //    Question question = new Question();
        //    return View(question);
        //}

        //[HttpPost]
        //[AuthorisationRequired]
        //public ActionResult Create(Question question)
        //{
        //    User user = (User)Session["User"];

        //    try
        //    {
        //        //   PROCEDURE INSERTQUESTION(PENONCER IN QUESTION.ENONCER%TYPE,PDIFFICULTER IN QUESTION.DIFFICULTER%TYPE);

        //        // Ajout de la question
        //        OracleCommand oraclCommandAjoutQuestion = new OracleCommand("GESTIONQUESTION", user.connexion);
        //        oraclCommandAjoutQuestion.CommandText = "GESTIONQUESTION.INSERTQUESTION";
        //        oraclCommandAjoutQuestion.CommandType = CommandType.StoredProcedure;

        //        OracleParameter orapamnumEnoncer = new OracleParameter("PENONCER", OracleDbType.Varchar2, 100);
        //        orapamnumEnoncer.Direction = ParameterDirection.Input;
        //        orapamnumEnoncer.Value = question.Enoncer;
        //        oraclCommandAjoutQuestion.Parameters.Add(orapamnumEnoncer);

        //        OracleParameter orapamDificulter = new OracleParameter("PDIFFICULTER", OracleDbType.Int32);
        //        orapamDificulter.Direction = ParameterDirection.Input;
        //        orapamDificulter.Value = question.Dificulter;
        //        oraclCommandAjoutQuestion.Parameters.Add(orapamDificulter);

        //        oraclCommandAjoutQuestion.ExecuteNonQuery();

        //        // ########################################################################################################################################

        //        //  PROCEDURE INESRTREPONSE(PENONCER IN REPONSE.ENONCERREPONSE%TYPE,PBONNE IN REPONSE.ESTBONNE%TYPE,PNUMQUESTION IN REPONSE.NUMQUESTION%TYPE);

        //        // Ajout des choix de réponce
        //        OracleCommand oraclCommandAjoutReponce1 = new OracleCommand("GESTIONQUESTION", user.connexion);
        //        oraclCommandAjoutReponce1.CommandText = "GESTIONQUESTION.INESRTREPONSE";
        //        oraclCommandAjoutReponce1.CommandType = CommandType.StoredProcedure;

        //        OracleParameter orapamnumEnoncerRep = new OracleParameter("PENONCER", OracleDbType.Int32);
        //        orapamnumEnoncer.Direction = ParameterDirection.Input;
        //        orapamnumEnoncer.Value = question.Enoncer;
        //        oraclCommandAjoutQuestion.Parameters.Add(orapamnumEnoncerRep);

        //        //OracleParameter orapamnumEstbonne1 = new OracleParameter("PBONNE", OracleDbType.Varchar2, 100);
        //        //orapamnumEstbonne1.Direction = ParameterDirection.Input;
        //        //orapamnumEstbonne1.Value = question.BonneReponce;
        //        //oraclCommandAjoutQuestion.Parameters.Add(orapamnumEstbonne1);



        //        // Enoncer
        //        //oraclCommandAjoutReponce.Parameters.Add(orapamnumEnoncer);




        //        //oraclCommandAjoutReponce.ExecuteNonQuery();

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex) {
        //        return RedirectToAction("Index");
        //    }
        //}

        [HttpGet]
        [AuthorisationRequired]
        public ActionResult Lister()
        {
            User user = (User)Session["User"];

            Oracle.ManagedDataAccess.Client.OracleCommand ObjSelct = new Oracle.ManagedDataAccess.Client.OracleCommand("select * from QUESTIONS",user.connexion);
            Oracle.ManagedDataAccess.Client.OracleDataReader ObjeRead = ObjSelct.ExecuteReader();
            List<Question> q = new List<Question>();
            while (ObjeRead.Read())
            {
                Question QQ = new Question();
                QQ.Id = ObjeRead.GetString(0);
                QQ.Enoncer = ObjeRead.GetString(1);
                QQ.flag = ObjeRead.GetString(2);
                QQ.Dificulter = ObjeRead.GetString(3);

                q.Add(QQ);
            }
            ObjeRead.Close();



            return View(q);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        [AuthorisationRequired]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [AuthorisationRequired]
        public ActionResult Delete(Question Q)
        {
            User user = (User)Session["User"];
            OracleCommand CMD = new OracleCommand("GESTIONQUESTION", user.connexion);
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GESTIONQUESTION.SUPPRIMER";

            OracleParameter Username = new OracleParameter("PUSERNAME", OracleDbType.Varchar2, 20);
           // Username.Value = CB_JOUEUR.SelectedItem.ToString();
            Username.Direction = ParameterDirection.Input;

            CMD.Parameters.Add(Username);
            try
            {
                user.connexion.Open();
                CMD.ExecuteNonQuery();
                TempData["alertMessage"] = "Joueur effacé";

            }
            catch (Exception Ex)
            {
                 Ex.ToString();
            }

            return RedirectToAction("Index");
        }




        [HttpGet]
        [AuthorisationRequired]
        public ActionResult Test()
        {
            Question question = new Question();
            return View(question);
        }

        [HttpPost]
        [AuthorisationRequired]
        public ActionResult Test(Question question)
        {
            User user = (User)Session["User"];

            try
            {
                //   PROCEDURE INSERTQUESTION(PENONCER IN QUESTION.ENONCER%TYPE,PDIFFICULTER IN QUESTION.DIFFICULTER%TYPE);

                // Ajout de la question
                OracleCommand oraclCommandAjoutQuestion = new OracleCommand("GESTIONQUESTION", user.connexion);
                oraclCommandAjoutQuestion.CommandText = "GESTIONQUESTION.INSERTQUESTION";
                oraclCommandAjoutQuestion.CommandType = CommandType.StoredProcedure;

                OracleParameter orapamnumEnoncer = new OracleParameter("PENONCER", OracleDbType.Varchar2, 100);
                orapamnumEnoncer.Direction = ParameterDirection.Input;
                orapamnumEnoncer.Value = question.Enoncer;
                oraclCommandAjoutQuestion.Parameters.Add(orapamnumEnoncer);

                OracleParameter orapamDificulter = new OracleParameter("PDIFFICULTER", OracleDbType.Int32);
                orapamDificulter.Direction = ParameterDirection.Input;
                orapamDificulter.Value = question.Dificulter;
                oraclCommandAjoutQuestion.Parameters.Add(orapamDificulter);

                oraclCommandAjoutQuestion.ExecuteNonQuery();

                // ########################################################################################################################################

                //  PROCEDURE INESRTREPONSE(PENONCER IN REPONSE.ENONCERREPONSE%TYPE,PBONNE IN REPONSE.ESTBONNE%TYPE,PENONCERQUESTION IN REPONSE.NUMQUESTION%TYPE);

                // Ajout de la reponse 1
                OracleCommand oraclCommandAjoutReponse1 = new OracleCommand("GESTIONQUESTION", user.connexion);
                oraclCommandAjoutReponse1.CommandText = "GESTIONQUESTION.INESRTREPONSE";
                oraclCommandAjoutReponse1.CommandType = CommandType.StoredProcedure;

                OracleParameter orapamnumEnoncer1 = new OracleParameter("PENONCER", OracleDbType.Varchar2, 100);
                orapamnumEnoncer1.Direction = ParameterDirection.Input;
                orapamnumEnoncer1.Value = question.Reponce1;
                oraclCommandAjoutReponse1.Parameters.Add(orapamnumEnoncer1);

                OracleParameter orapamnumEstbonne1 = new OracleParameter("PBONNE", OracleDbType.Int32);
                orapamnumEstbonne1.Direction = ParameterDirection.Input;
                if (question.Reponse1Bonne == true)
                {
                    orapamnumEstbonne1.Value = 1;
                }
                else
                {
                    orapamnumEstbonne1.Value = 0;
                }
                oraclCommandAjoutReponse1.Parameters.Add(orapamnumEstbonne1);


                OracleParameter orapamnumEnoncerRep = new OracleParameter("PENONCERQUESTION", OracleDbType.Varchar2, 100);
                orapamnumEnoncerRep.Direction = ParameterDirection.Input;
                orapamnumEnoncerRep.Value = question.Enoncer;
                oraclCommandAjoutReponse1.Parameters.Add(orapamnumEnoncerRep);


                oraclCommandAjoutReponse1.ExecuteNonQuery();

                // Ajout de la reponse 2
                OracleCommand oraclCommandAjoutReponse2 = new OracleCommand("GESTIONQUESTION", user.connexion);
                oraclCommandAjoutReponse2.CommandText = "GESTIONQUESTION.INESRTREPONSE";
                oraclCommandAjoutReponse2.CommandType = CommandType.StoredProcedure;

                OracleParameter orapamnumEnoncer2 = new OracleParameter("PENONCER", OracleDbType.Varchar2, 100);
                orapamnumEnoncer2.Direction = ParameterDirection.Input;
                orapamnumEnoncer2.Value = question.Reponce2;
                oraclCommandAjoutReponse2.Parameters.Add(orapamnumEnoncer2);

                OracleParameter orapamnumEstbonne2 = new OracleParameter("PBONNE", OracleDbType.Int32);
                orapamnumEstbonne2.Direction = ParameterDirection.Input;
                if (question.Reponse2Bonne == true)
                {
                    orapamnumEstbonne2.Value = 1;
                }
                else
                {
                    orapamnumEstbonne2.Value = 0;
                }
                oraclCommandAjoutReponse2.Parameters.Add(orapamnumEstbonne2);


                OracleParameter orapamnumEnoncerRep2 = new OracleParameter("PENONCERQUESTION", OracleDbType.Varchar2, 100);
                orapamnumEnoncerRep2.Direction = ParameterDirection.Input;
                orapamnumEnoncerRep2.Value = question.Enoncer;
                oraclCommandAjoutReponse2.Parameters.Add(orapamnumEnoncerRep2);


                oraclCommandAjoutReponse2.ExecuteNonQuery();

                // Ajout de la reponse 3
                OracleCommand oraclCommandAjoutReponse3 = new OracleCommand("GESTIONQUESTION", user.connexion);
                oraclCommandAjoutReponse3.CommandText = "GESTIONQUESTION.INESRTREPONSE";
                oraclCommandAjoutReponse3.CommandType = CommandType.StoredProcedure;

                OracleParameter orapamnumEnoncer3 = new OracleParameter("PENONCER", OracleDbType.Varchar2, 100);
                orapamnumEnoncer3.Direction = ParameterDirection.Input;
                orapamnumEnoncer3.Value = question.Reponce3;
                oraclCommandAjoutReponse3.Parameters.Add(orapamnumEnoncer3);

                OracleParameter orapamnumEstbonne3 = new OracleParameter("PBONNE", OracleDbType.Int32);
                orapamnumEstbonne3.Direction = ParameterDirection.Input;
                if (question.Reponse3Bonne == true)
                {
                    orapamnumEstbonne3.Value = 1;
                }
                else
                {
                    orapamnumEstbonne3.Value = 0;
                }
                oraclCommandAjoutReponse3.Parameters.Add(orapamnumEstbonne3);


                OracleParameter orapamnumEnoncerRep3 = new OracleParameter("PENONCERQUESTION", OracleDbType.Varchar2, 100);
                orapamnumEnoncerRep3.Direction = ParameterDirection.Input;
                orapamnumEnoncerRep3.Value = question.Enoncer;
                oraclCommandAjoutReponse3.Parameters.Add(orapamnumEnoncerRep3);


                oraclCommandAjoutReponse3.ExecuteNonQuery();

                // Ajout de la reponse 4
                OracleCommand oraclCommandAjoutReponse4 = new OracleCommand("GESTIONQUESTION", user.connexion);
                oraclCommandAjoutReponse4.CommandText = "GESTIONQUESTION.INESRTREPONSE";
                oraclCommandAjoutReponse4.CommandType = CommandType.StoredProcedure;

                OracleParameter orapamnumEnoncer4 = new OracleParameter("PENONCER", OracleDbType.Varchar2, 100);
                orapamnumEnoncer4.Direction = ParameterDirection.Input;
                orapamnumEnoncer4.Value = question.Reponce4;
                oraclCommandAjoutReponse4.Parameters.Add(orapamnumEnoncer4);

                OracleParameter orapamnumEstbonne4 = new OracleParameter("PBONNE", OracleDbType.Int32);
                orapamnumEstbonne4.Direction = ParameterDirection.Input;
                if (question.Reponse4Bonne == true)
                {
                    orapamnumEstbonne4.Value = 1;
                }
                else
                {
                    orapamnumEstbonne4.Value = 0;
                }
                oraclCommandAjoutReponse4.Parameters.Add(orapamnumEstbonne4);


                OracleParameter orapamnumEnoncerRep4 = new OracleParameter("PENONCERQUESTION", OracleDbType.Varchar2, 100);
                orapamnumEnoncerRep4.Direction = ParameterDirection.Input;
                orapamnumEnoncerRep4.Value = question.Enoncer;
                oraclCommandAjoutReponse4.Parameters.Add(orapamnumEnoncerRep4);


                oraclCommandAjoutReponse4.ExecuteNonQuery();











                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        private void Question(String Categorie)
        {
            User user = (User)Session["User"];
            DataSet Data = new DataSet();
            var modelObj = new Question();
           
            user.connexion.Open();
            try
            {
                OracleCommand oraCmdTotal = new OracleCommand("GESTIONQUESTION", user.connexion);
                oraCmdTotal.CommandText = "GESTIONQUESTION.questionhasard";
                oraCmdTotal.CommandType = CommandType.StoredProcedure;

                OracleParameter OrapamTotal = new OracleParameter("resultat",
                OracleDbType.RefCursor);
                OrapamTotal.Direction = ParameterDirection.ReturnValue;
                oraCmdTotal.Parameters.Add(OrapamTotal);

                OracleParameter orapamusername = new OracleParameter("CODECATEGORIE", OracleDbType.Char, 6);

                orapamusername.Direction = ParameterDirection.Input;
                orapamusername.Value = Categorie;
                oraCmdTotal.Parameters.Add(orapamusername);
                OracleDataAdapter allo = new OracleDataAdapter(oraCmdTotal);
                Data = new DataSet();
                allo.Fill(Data, "resultat");
                allo.Dispose();
               
                for (int i = 0; i < Data.Tables["resultat"].Rows.Count; ++i)
                {
                    object obj = Data.Tables["resultat"].Rows[i].ItemArray[1].ToString();

                    modelObj.question1_ran = Data.Tables["resultat"].Rows[i].ItemArray[1].ToString();
                    modelObj.question2_ran = Data.Tables["resultat"].Rows[i].ItemArray[1].ToString();
                    modelObj.question3_ran = Data.Tables["resultat"].Rows[i].ItemArray[1].ToString();
                    modelObj.question4_ran = Data.Tables["resultat"].Rows[i].ItemArray[1].ToString();
                    modelObj.question5_ran = Data.Tables["resultat"].Rows[i].ItemArray[1].ToString();

                  
                }
                
            }
            catch (Exception se)
            {
                se.Message.ToString();
            }
            user.connexion.Close();



        }

        public ActionResult Cat()
        {
            string hasard="";

            if(hasard=="DBZ")
            {
                Question(hasard);
            }
            if(hasard=="LOTR")
            {
                Question(hasard);
            }
            if (hasard == "WOW")
            {
                Question(hasard);
            }
            if (hasard == "LOL")
            {
                Question(hasard);
            }
            return View();
        }
    }
}


