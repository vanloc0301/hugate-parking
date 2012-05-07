using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Hugate.DataHelper;
using System.Data;

namespace Hugate.Services
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        pk_In_Out[] GetAll();

        //[OperationContract]
        //pk_In_Out[] getAllPKIn();

        [OperationContract]
        pk_In_Out[] getAllPKIn(int skip, int take);

        [OperationContract]
        pk_In_Out[] getAllPKOut(int skip, int take);

        [OperationContract]
        bool hasObject(string RFID);

        [OperationContract]
        vw_Pk_All getSinglePKIn(string RFID);

        [OperationContract]
        pk_In_Out getSinglePKOut(string RFID);

        [OperationContract]
        pk_Camera[] GetAllCameras();

        [OperationContract]
        pk_Price[] GetAllPrice();

        [OperationContract]
        IEnumerable<pk_Price> IEPrice();

        [OperationContract]
        decimal GetPriceByID(int ID);

        [OperationContract]
        void SavePrice(string type, decimal price, string note);

        [OperationContract]
        void EditPrice(int ID, string type, decimal price, string note);

        [OperationContract]
        void DeletePrice(int ID);

        [OperationContract]
        void DeleteCard(string RFIDCard);


        [OperationContract]
        IEnumerable<pk_Camera> IECamera();

        [OperationContract]
        IEnumerable<pk_In_Out> Search(string RFID, string Number, DateTime fromDate, DateTime toDate, bool isOut, bool isRFID, bool isNumber, bool isDate);

        [OperationContract]
        void SaveCamera(string name, string provider, string desc, string source, string login, string password, string size, string type, string quality, string interval, bool isIn, bool position, int areadId);

        [OperationContract]
        void EditCamera(int cameraId, string name, string provider, string desc, string source, string login, string password, string size, string type, string quality, string interval, bool isIn, bool position, int areadId);

        [OperationContract]
        void DeleteCamera(int cameraId);

        [OperationContract]
        Guid SavePKIn(string RFID, string Number, DateTime Time, int VehicleTypeID);

        [OperationContract]
        void SavePKOut(Guid ID, DateTime TimeOut);

        [OperationContract]
        void getImage(Guid ID, ref byte[] arrImg, bool isIn);

        [OperationContract]
        void setImage(Guid ID, byte[] arrImg, bool isIn);

        [OperationContract]
        List<vw_Pk_All> TotalAmount(DateTime fromDate, DateTime toDate);
    }
}
