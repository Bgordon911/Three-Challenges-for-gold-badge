using System;

namespace ClaimsChallenge
{
    public class Claim
    {
        public enum ClaimType
        {
            Theft,
            Home,
            Auto,
            Car
        }
        public int ClaimID { get; set; }
        public ClaimType TypeofClaim { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateofIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(int claimID, ClaimType typeofClaim, string description, double claimAmount, DateTime dateofIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeofClaim = typeofClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateofIncident = dateofIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }


    }
}



