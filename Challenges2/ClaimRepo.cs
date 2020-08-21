using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges2
{
    public class ClaimRepo
    {
        private List<Claim> _claimInfo = new List<Claim>();


        public List<Claim> SeeAllClaims()
        {
            return _claimInfo;
        }


        public void AddClaimToList(Claim claimInfo)
        {
            _claimInfo.Add(claimInfo);
        }

       public Claim FindClaimByID(int claimID)
        {
            foreach (Claim claimInfo in _claimInfo)
            {
                if (claimInfo.ClaimID == claimID)
                {
                    return claimInfo;
                }
            }
            return null;
        }

        public bool ModifyClaim(int claimID, Claim newClaim)
        {
            Claim oldClaim = FindClaimByID(claimID);

            if(oldClaim != null)
            {
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.ClaimType = newClaim.ClaimType;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.Description = newClaim.Description;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveClaimFromList(int claimID)
        {
            Claim claim = FindClaimByID(claimID);

            if(claim == null)
            {
                return false;
            }

            int claimCount = _claimInfo.Count;
            _claimInfo.Remove(claim);

            if(claimCount > _claimInfo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
    }
}
