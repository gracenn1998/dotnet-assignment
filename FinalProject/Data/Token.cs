using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Data
{
    public class Token
    {
        public String token { get; set; }
        public DateTime expireTime { get; set; }

        public Token()
        {
            this.token = generateToken();
            this.expireTime = DateTime.Now.AddMinutes(20);
        }
        public String generateToken()
        {
            String token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return token;
        }

        public int validateToken(String token)
        {
            int status = -1; //1: valid token | -1: unknown token | 0: expired token 
            if(token.Equals(this.token) && DateTime.Now <= this.expireTime)
            {
                status = 1;
            }
            else if(DateTime.Now > this.expireTime)
            {
                status = 0;
            }
            return status;
        }
    }
}