using BridgeProtocol.Integrations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeProtocol.Integrations.Utility
{
    public static class PassportUtility
    {
        private static List<Claim> RemoveUnknownSignedClaims(VerifyPassportLoginChallengeResponse res)
        {
            List<Claim> claims = new List<Claim>();

            foreach (var claim in res.Claims)
            {
                //If we were flagged as an unknown signer, we shouldn't include it
                if (!res.UnknownSignerClaimTypes.Contains(claim.ClaimTypeId))
                {
                    claims.Add(claim);
                }
            }

            return claims;
        }
    }
}
