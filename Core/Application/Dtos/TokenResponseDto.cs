using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class TokenResponseDto
    {

        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public TokenResponseDto(string token, DateTime expiryDate)
        {
            Token = token;
            ExpiryDate = expiryDate;
        }
    }
}
