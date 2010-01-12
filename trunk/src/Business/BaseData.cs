namespace FaceIDpp.Business
{
    public class BaseData
    {
        protected DBUtils.DatabaseAccess objData;
        public BaseData()
        {
            objData = new DBUtils.DatabaseAccess();
            objData.CreateConnection(@"F:\vnanh\project\FaceID\db\FaceIDdb.mdb");
        }
    }
}
