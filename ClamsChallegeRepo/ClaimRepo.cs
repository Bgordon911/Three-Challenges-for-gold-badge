using ClaimsChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClamsChallegeRepo
{


    public class ClaimsRepo
    {
        private Queue<Claim> _listOfClaim = new Queue<Claim>();

        // Create
        public void AddClaimToQueue(Claim claimToAddToQueue)
        {
            _listOfClaim.Enqueue(claimToAddToQueue);
        }

        // Read
        public Queue<Claim> GetClaims()
        {
            return _listOfClaim;
        }



        // Delete
        public bool RemovClaimsFromList()
        {
            Claim claim = _listOfClaim.Peek();

            if (claim == null)
            {
                return false;
            }

            int initialCount = _listOfClaim.Count;
            _listOfClaim.Dequeue();

            if (initialCount > _listOfClaim.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper

        public Claim GetClaimbgID(int claimID)
        {
            foreach (Claim claim in _listOfClaim)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;

        }


    }
}



