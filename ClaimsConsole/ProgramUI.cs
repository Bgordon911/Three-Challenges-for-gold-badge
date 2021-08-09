using ClamsChallegeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ClaimsChallenge.Claim;

namespace ClaimsChallenge
{
    class ProgramUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();
        
        public void Run()
        {
            
            SeedClaimList();
            Menu();
        }

        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine($"Please choose an option:\n" +
                    $"1. See all Claims\n" +
                    $"2. Take care of next Claim\n" +
                    $"3. Enter a new Claim\n" +
                    $"4. Exit");

                String input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //SeeClaims
                        SeeAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        TakeCareNextClaim();
                        break;
                    case "3":
                        //Enter a claim
                        EnteraNewClaim();
                        break;
                    case "4":
                        //Exit
                        keepRunning = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> queueofClaims = _repo.GetClaims();

            Console.WriteLine($"{ "Claim", -25} { "Description", -25} { "Amount", -25}{ "Accident Date", -25} { "Claim Date", -25} { "Valid", - 25}");

            foreach (Claim claims in queueofClaims)
            {
                var output = String.Format("{0, -25}, {1, -25}, {2,-25}, {3,-25}, {4, -25}, {5, -25}", claims.TypeofClaim, claims.Description, claims.ClaimAmount, claims.DateofIncident, claims.DateOfClaim, claims.IsValid);
                Console.WriteLine(output);
                 
            }
        }

        private void TakeCareNextClaim()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _repo.GetClaims();
            Claim nextInQueue = queueOfClaims.Peek();
            Console.WriteLine($"Clain ID: {nextInQueue.ClaimID}\n" +
                $"Type of Claim: {nextInQueue.TypeofClaim}\n" +
                $"Description: {nextInQueue.Description}\n" +
                $"Claim Amount: {nextInQueue.ClaimAmount}\n" +
                $"Date of Incident : {nextInQueue.DateofIncident}\n" +
                $"Date Of Claim: {nextInQueue.DateOfClaim}\n" +
                $"IsValid: {nextInQueue.IsValid}");
            Console.WriteLine("Do you want to deal the the claim?");
            string input = Console.ReadLine().ToLower();
            if (input.Contains("y"))
            {
                queueOfClaims.Dequeue();
                queueOfClaims.Peek();
                TakeCareNextClaim();

            }
            else if (input.Contains("n"))
            {
                Console.WriteLine("Press any key to be returned to the menu...");
                Console.ReadKey();
            }




        }
        private void SeedClaimList()
        {
            Claim firstClaim = new Claim(1, Claim.ClaimType.Car, "Rear-ended", 4000, new DateTime(1999, 07, 01), new DateTime(1999, 07, 21), true);
            _repo.AddClaimToQueue(firstClaim);
            Claim secondClaim =  new Claim(2, Claim.ClaimType.Car, "Rear-ended", 4000, new DateTime(1999, 07, 01), new DateTime(1999, 07, 21), true);
            _repo.AddClaimToQueue(secondClaim);
        }
        private void EnteraNewClaim()
        {
            Claim newClaim = new Claim();
            Console.WriteLine("Enter one of the choices that is given:\n" +
              "1.Theft\n" +
              "2.Auto\n" +
              "3.Home\n");
            string typeAsstring = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsstring);
            newClaim.TypeofClaim = (ClaimType)typeAsInt;

            Console.WriteLine("Enter the descripition of the Claim; ");
            string description = Console.ReadLine();
            newClaim.Description = description;

            Console.WriteLine("How much is the claim amount?");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date of the Incident (YYYY/MM/DD): ");
            string dateTimeAsString2 = Console.ReadLine();
            newClaim.DateOfClaim = Convert.ToDateTime(dateTimeAsString2);
            Console.WriteLine("Was this claim made within 30 days of incident? (Y/N)");
            string input2 = Console.ReadLine().ToLower();
            if (input2.Contains("y"))
            {
                newClaim.IsValid = true;
            }
            else if (input2.Contains("n"))
            {
                newClaim.IsValid = false;
            }
            _repo.AddClaimToQueue(newClaim);
        }
    }
}








        

        
    


