using playwright_newintegrationtests.InterfacePoints.DbInterface.Base;

namespace playwright_newintegrationtests.InterfacePoints.DbInterface.Base.DataModels
{
    public class LookupData
    {
        [SqlDataField("fId")]
        public int Id { get; set; }

        [SqlDataField("fName")]
        public string Name { get; set; } = string.Empty;
    }
}
