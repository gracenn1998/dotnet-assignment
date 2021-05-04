using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Data
{
    public class Account
    {
        public int id { get; set; }
        public String email { get; set; }
        public String hashed_password { get; set; }
        public String salt { get; set; }

        public Hashtable generateHashedPassword(String original_password)
        {
            string hashed_pw;
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            hashed_pw = BCrypt.Net.BCrypt.HashPassword(original_password, salt);
            Hashtable password = new Hashtable();
            password["salt"] = salt;
            password["hashed_password"] = hashed_pw;
            return password;
        }

        public void changePassword(string new_password)
        {
            Hashtable pw = generateHashedPassword(new_password);
            this.salt = pw["salt"].ToString();
            this.hashed_password = pw["hashed_password"].ToString();
        }

        public Boolean validatePassword(string entered_password)
        {
            string myPassword = "password";
            string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);
            return BCrypt.Net.BCrypt.Verify(entered_password, this.hashed_password);            
        }




    }
}