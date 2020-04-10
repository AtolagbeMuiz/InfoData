using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using InfoData.Models;


namespace InfoData.Controllers
{
    public class HomeController : Controller
    {
        DataBase.DB db = new DataBase.DB();
       

        //ViewBag for Insertion/Submission: This rendersd the HTML page for Insertion
        public ActionResult Insert_Record()
        {
            return View();
        }


        //Action Method for inserting 
        [HttpPost]
       public JsonResult Insert_Record(Register res)
        {
            string message = string.Empty;
            try
            {
                //creates an ionstance of A DB Class and inserts the txtbox values into the DB
                db.InsertData(res);
                message = "Inserted Successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
               // message = "Failed";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        //ViewBag for Display all the data in the database:Renders the HTML page
        public ActionResult DisplayData()
        {
            return View();
        }
        

        //Action Method for accessing the data in the database and adding to a LIST collection
        public JsonResult GetData()
        {
            //casts the data returned from the database into a DATASET
            DataSet dataset = db.GetAllData();

            //Instantiating a List object
            List<Register> listreg = new List<Register>();

            //Gets the rows of data in the dataset and adds them to the LIST with type REGISTER
            foreach(DataRow dr in dataset.Tables[0].Rows)
            {
                listreg.Add(new Register
                {
                    SerialNo = Convert.ToInt32(dr["SerialNo"]),
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString(),

                });
            }

            //returns a all the data in the LIST but in JSOn Format
            return Json(listreg, JsonRequestBehavior.AllowGet);
        }

        //Renders the UpadateData HTML page
        public ActionResult Updatedata(int SN)
        {
            return View();
        }

        //Action Method for Updating data
        public JsonResult Update_Record(Register res)
        {
            string message = string.Empty;
            try
            {
                //accessing the DB class by creating in instance Of DB updata the record in the Database
                db.UpdateData(res);
                message = " Updated Successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // message = "Failed";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }


        //gets a particular data by its SN passed from the ClientSide(SN:Request.QueryString)
        public JsonResult GetRecordbySN(int SN)
        {
            //casts the data gotten by its SN into a dataset
            DataSet dataset = db.GetDataBySN(SN);
            List<Register> listreg = new List<Register>();

            //accesses the row dataset and adding it to a list
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                listreg.Add(new Register
                {
                    SerialNo = Convert.ToInt32(dr["SerialNo"]),
                    Name = dr["Name"].ToString(),
                    Email = dr["Email"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString(),

                });
            }
            //returns the list in JSON format
            return Json(listreg, JsonRequestBehavior.AllowGet);
        }


       
        //public ActionResult Delete_Data(int SN)
        //{
        //    return View();
        //}


        //[HttpPost]

            //Action method for deleting the record from the DB
        public ActionResult Delete_Record(int SN)
        {
            string message = string.Empty;
            try
            {
                //access the DB by creating an instance
                db.DeleteDataBySN(SN);
                message = "Deleted Successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // message = "Failed";
            }

      //redirects to a particular action method whose job is to render a viewbag(HTML page): the pages that shows all data
            return RedirectToAction("DisplayData");
        }




        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}