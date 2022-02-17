//I have create one small Cosole App which has Menu driven program using do while loop and switch 
//which have functionalities of Insert,Update,Delete And retrive data from database 
//In this Example I have taaken Student as a Database Stud_Info table which has 2 field sid and sname
//for sid I have declare Primary key constraint
//Also i have created store procedure for insert update delete operations
using System;
using System.Data.SqlClient;//To use Sql Commands we need to use System.Data.SqlClient namespace
namespace ADO_Select
{
    class DatabaseProgram
    {
        SqlConnection? con = null;
        string sname;
        int sid;
        public void CreateConnection()//Create connection fuction by which we dont need to write much lines only we can reuse this fuction whenever there is need
        {
            try
            {
                //Connection string
                con = new SqlConnection("data source =devops.aapnainfotech.com;database=Student; uid=apnsa; pwd=W98rd41lMravjL5");
                con.Open();
                Console.WriteLine("\n \t Connection Established successfulliy in the SQL Server");
            }
            catch (SqlException e)
            {
                Console.WriteLine("\n \t Something went wrong while connecting or executing" + e.Message);
            }
            finally
            {
                con?.Close();
            }
        }
        public void InsertData()//Inserting data to database
        {
            try
            {
                Console.WriteLine("Enter Stud Id:");
                sid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name:");
                sname = Console.ReadLine();
                SqlCommand cm = new SqlCommand("insert_data", con);
                con?.Open();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@Student_id", sid));
                cm.Parameters.Add(new SqlParameter("@S_Name", sname));
                cm.ExecuteNonQuery();

                Console.WriteLine("\n \t Record inserted successfulliy in the SQL Server");
            }
            catch (SqlException e)
            {
                Console.WriteLine("\n \t Something went wrong Record not inserted" + e.Message);
            }
            finally
            {
                con?.Close();

            }
        }
        public void updateData()
        {
            try
            {
                Console.WriteLine("Enter Stud Id to update:");
                sid = Convert.ToInt32(Console.ReadLine());
                SqlCommand cm = new SqlCommand("update_data", con); // Opening Connection
                con?.Open(); // Executing the SQL query to retrive the values fromt he table
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@Student_id", sid));
                
                int i = cm.ExecuteNonQuery();
                Console.WriteLine("\n\tRecord Updated Successfully:\t" + i);

            }
            catch (SqlException e)
            {
                Console.WriteLine("\n \t Something went wrong Record not Updatedted" + e.Message);
            }
            finally
            {
                con?.Close();
            }
        }
        public void DeleteData()
        {
            try
            {
                Console.WriteLine("Enter Stud Id to delete:");
                sid = Convert.ToInt32(Console.ReadLine());
                SqlCommand cm = new SqlCommand("delete_data1", con); // Opening Connection
                con?.Open(); // Executing the SQL query to retrive the values from the table
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Add(new SqlParameter("@Student_id", sid));
                int i = cm.ExecuteNonQuery();
                Console.WriteLine("\n\t" + i + " Record Deleted Successfully:\t");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e.Message);
            }
            finally
            {
                con?.Close();

            }
        }
        public void SelectData(char option)
        {
            try
            {

                SqlCommand cm = new SqlCommand("select_data2", con); // Opening Connection
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                con?.Open(); // Executing the SQL query to retrive the values fromt he table

                SqlDataReader dr = cm.ExecuteReader();
                Console.WriteLine("StudId \tName \tCourse");

                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + " " + dr[2]);
               
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e.Message);
            }
            // Closing the connection
            finally
            {
                con?.Close();
               
            }

        }
        static void Main(string[] args)
        {
            DatabaseProgram p = new DatabaseProgram();
            char choice = 'y';
            int ch;
            do
            {
                Console.WriteLine("\t1 To Insert Data");
                Console.WriteLine("\t2 To Update Data");
                Console.WriteLine("\t3 To Delete Data");
                Console.WriteLine("\t4 To Display Data");
                Console.WriteLine("\tEnter Your Choice:");
                ch = Convert.ToInt32(Console.ReadLine());
                //ch will check the choice and according to that it will call case
                switch (ch)
                {
                    case 1:
                        p.CreateConnection();
                        p.InsertData();
                        break;
                    case 2:
                        p.CreateConnection();
                        p.updateData();
                        break;
                    case 3:
                        p.CreateConnection();
                        p.DeleteData();
                        break;
                    case 4:
                        p.CreateConnection();
                        p.SelectData(choice);

                        break;
                    default:
                        Console.WriteLine("Pls Enter Valid Choice...");
                        break;

                }
                Console.WriteLine("Do u want to continue press y for n for no...");
                choice = Convert.ToChar(Console.ReadLine());
            } while (choice == 'y' || choice == 'Y');//It will work till user press Y or y first time time it will work true 
            Console.ReadLine();
        }
    }
}

