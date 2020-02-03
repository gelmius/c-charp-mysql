using System;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;


namespace mysql1
{
    class Program
    {
        static void Main(string[] args)
        {            
            DBOldSchool con = new DBOldSchool("178.128.202.96", "Testas", "TestUser", "TestasTesta5");

            Console.WriteLine("write text(case sensetive)");
            String[] ivestis = Console.ReadLine().Split(" ");
            DataSet aaa = con.SelectAll("Automobilis");
            foreach (DataTable table in aaa.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    int points = 0;
                    for(int i =0;i<ivestis.Length;i++)
                    {
                        if (!(string.Join(",", dr.ItemArray).Split(',').ToList().Contains(ivestis[i])))
                        {
                            break;
                        }
                        else { points++; }
                        if(points == ivestis.Length)
                        {
                            foreach (DataColumn dc in table.Columns)
                            {
                                Console.WriteLine(dc.ToString()+": "+ dr[dc].ToString()+" ");
                            }
                            Console.WriteLine();
                        }
                    }   
                }
            }
        }   
    }
}
