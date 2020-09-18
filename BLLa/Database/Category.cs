using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class Category
    {
        public Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Category(DataRow Row)
        {
            this.Id = (int)Row["ID"];
            this.Name = Row["Name"].ToString();
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
