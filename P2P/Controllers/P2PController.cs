using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P2P.Models.Entities;
using P2P.Services.Interfaces;

namespace P2P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class P2PController : ControllerBase
    {
        private readonly IP2PServices p2PServices;

        public P2PController(IP2PServices p2pServices)
        {
            this.p2PServices = p2pServices;
        }
        // GET: /<controller>/
        [HttpGet("get-user/{Id}")]
        public ActionResult<User> Get(string Id)
        {
            var user = p2PServices.GetUser(Id);
            return user;
        }


        [HttpPost("create-new-user", Name = "Create-New-user")]
        public ActionResult<User> CreateUser([FromBody]User user)
        {
            p2PServices.CreateUser(user);
            return user;
        }


        [HttpPut("update-user-details/{Id}")]
        public ActionResult<User> UpdateUser(string Id, [FromBody] User user)
        {
            var updatedUser = p2PServices.UpdateUser(Id, user);
            return updatedUser;
        }

        [HttpDelete("delete-user/{Id}")]
        public ActionResult<User> DeleteUser(string Id)
        {
            var user = p2PServices.DeleteUser(Id);
            return user;
        }

        [HttpPost("apply-for-loan", Name = "Create-New-Loan")]
        public ActionResult<LoanRequest> LoanMoney(string lenderId, string borrowerId, decimal amount)
        {
            var loanRequest = p2PServices.CreateLoanRequest(lenderId, borrowerId, amount);
            return loanRequest;
        }

        [HttpPost("create-new-Transaction", Name = "Create-New-Transaction")]
        public ActionResult<Transaction> CreateTransaction(string loanRequestId, decimal amount)
        {
            var transaction = p2PServices.CreateTransaction(loanRequestId, amount);
            return transaction;
        }
    }
}

