namespace playwright_newintegrationtests.Constants
{
    public class VtosApiEndpointConstants
    {
        /// <summary>
        /// Constant for CreatePairGameV3 endpoint on the VTOS API
        /// {0} - Sport
        /// </summary>
        public const string CreatePairGame = "{0}/Fixture/CreatePairGameV3";

        /// <summary>
        /// Constant for ModifyStatus endpoint on the VTOS API
        /// {0} - Sport
        /// {1} - Fixture ID
        /// </summary>
        public const string ModifyStatus = "{0}/Fixture/{1}/ModifyStatus";

        /// <summary>
        /// Constant for ModifyIsSuspended endpoint on the VTOS API 
        /// {0} - Sport 
        /// {1} - Fixture ID
        /// </summary>
        public const string ModifyIsSuspended = "{0}/Fixture/{1}/ModifyIsSuspended";

        /// <summary>
        /// Constant for GetFullV11 Endpoint on the VTOS API 
        /// {0} - Sport 
        /// {1} - Fixture ID 
        /// </summary>
        public const string GetFullFixture = "{0}/Fixture/{1}/GetFullV11?";

        /// <summary>
        /// Constant for the Create Option Market endpoint 
        /// {0} - Sport
        /// {1} - Fixture ID
        /// </summary>
        public const string CreateOptionMarket = "{0}/Fixture/{1}/OptionMarket/CreateV3";

        /// <summary>
        /// Constant for the Modify Results V3 enpoint
        /// {0} - Sport 
        /// {1} - Fixture ID
        /// {2} - Option Market ID
        /// </summary>
        public const string ModifyResults = "{0}/Fixture/{1}/OptionMarket/{2}/ModifyResultsV2";

        /// <summary>
        /// Constant for the Modify Results V3 enpoint
        /// {0} - Sport 
        /// {1} - Fixture ID
        /// {2} - Option Market ID
        /// </summary>
        public const string StatusModify = "{0}/Fixture/{1}/OptionMarket/{2}/Status/Modify";

        /// <summary>
        /// Constant for the Modify Results V3 enpoint
        /// {0} - Sport 
        /// {1} - Fixture ID
        /// {2} - Option Market ID
        /// </summary>
        public const string SettlementRequestsCreate = "{0}/Fixture/{1}/OptionMarket/{2}/SettlementRequests/Create";
    }
}
