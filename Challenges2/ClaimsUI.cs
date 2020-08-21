using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Challenges2
{
    class ClaimsUI
    {
        private readonly ClaimRepo _claimInfo = new ClaimRepo();

        public void Start()
        {

            ClaimMenu();
        }


        private void ClaimMenu()

        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the claims menu - What would you like to do?\n" +
                    "1.) See all claims.\n" +
                    "2.) Enter a new claim.\n" +
                    "3.) Modify an existing claim.\n" +
                    "4.) Work on Claims.\n" +
                    "5.) Exit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllClaims();
                        break;

                    case "2":
                        EnterNewClaim();
                        break;

                    case "3":
                        UpdateClaim();
                        break;

                    case "4":
                        WorkOnClaims();
                        break;

                    case "5":
                        keepRunning = false;
                        break;
                }
            }
        }




        //Claim methods

        private void DisplayAllClaims()
        {
            Console.Clear();
            List<Claim> allClaims = _claimInfo.SeeAllClaims();




            Console.WriteLine($"{"ClaimID",-10} {"ClaimType",-13} {"Description",-22} {"ClaimAmount",-15} {"Date Of Incident",-26} {"Date Of Claim",-25} {"Is it Valid",-1}");


            foreach (Claim claimInfo in allClaims)
            {
                Console.WriteLine($"{claimInfo.ClaimID,-10} {claimInfo.ClaimType,-13} {claimInfo.Description,-22} ${claimInfo.ClaimAmount,-14} {claimInfo.DateOfIncident,-26} {claimInfo.DateOfClaim,-25} {claimInfo.IsValid,-1}\n ");

            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }







        private void EnterNewClaim()
        {
            Claim newClaim = new Claim();
            Console.Clear();
            Console.WriteLine("What is the claim ID?");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("What is the type of claim?\n" +
                "1.) Car\n" +
                "2.) Home\n" +
                "3.) Theft\n");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    newClaim.ClaimType = ClaimType.Car;
                    break;

                case "2":
                    newClaim.ClaimType = ClaimType.Home;
                    break;

                case "3":
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
            }

            Console.WriteLine("Please give a quick description of the claim.");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("What is the claim amount?");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("What is the dater of the incident?");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("What is the date of the claim?");
            newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            newClaim.IsValid = Compare(newClaim.DateOfClaim, newClaim.DateOfIncident);

            _claimInfo.AddClaimToList(newClaim);

        }


        private void UpdateClaim()
        {
            Console.Clear();
            DisplayAllClaims();
            Console.WriteLine("What is the ID of the claim you'd like to update?");

            int input = Convert.ToInt32(Console.ReadLine());

            Claim updatedClaim = new Claim();

            Console.WriteLine("What is the claims new ID?");
            updatedClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is claims new type?\n" +
                "1.) Car\n" +
                "2.) Home\n" +
                "3.) Theft\n");

            string input2 = Console.ReadLine();

            switch (input2)
            {
                case "1":
                    updatedClaim.ClaimType = ClaimType.Car;
                    break;

                case "2":
                    updatedClaim.ClaimType = ClaimType.Home;
                    break;

                case "3":
                    updatedClaim.ClaimType = ClaimType.Theft;
                    break;
            }



            Console.WriteLine("What is the claims new description?");
            updatedClaim.Description = Console.ReadLine();

            Console.WriteLine("What is the claims new monetary amount?");
            updatedClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("What is the claims new incident date?");
            updatedClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("What is the claims new claim date?");
            updatedClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            bool wasUpdated = _claimInfo.ModifyClaim(input, updatedClaim);

            if (wasUpdated)
            {
                Console.WriteLine("The claim has been updated.");
            }
            else
            {
                Console.WriteLine("There was an issue updated the claim.");
            }
            Console.ReadLine();

        }

        public static bool Compare(DateTime T1, DateTime T2)
        {
            if (T1 <= T2.AddDays(30))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void WorkOnClaims()
        {
            DisplayAllClaims();

            Console.WriteLine("Which claim would you like to work on?");
            int input = Convert.ToInt32(Console.ReadLine());

            Claim workingClaim = new Claim();

            Console.WriteLine("Is this claim taken care of?\n" +
                "1.) Yes \n" +
                "2.) No \n");

            string input2 = Console.ReadLine();

            switch (input2)
            {
                case "1":
                    _claimInfo.RemoveClaimFromList(input);
                    break;

                case "2":
                    ClaimMenu();
                    break;

            }







        }







    }
}
