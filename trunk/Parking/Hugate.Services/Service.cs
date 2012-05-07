using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Hugate.DataHelper;

namespace Hugate.Services
{
    public class Service : IService
    {
        Execute exec = new Execute();

        public pk_In_Out[] GetAll()
        {
            return exec.GetAll();
        }

        //public pk_In_Out[] getAllPKIn()
        //{
        //    return exec.GetAllPKIn();
        //}

        public pk_In_Out[] getAllPKIn(int skip, int take)
        {
            return exec.GetAllPKIn(skip, take);
        }

        public pk_In_Out[] getAllPKOut(int skip, int take)
        {
            return exec.GetAllPKOut(skip, take);
        }

        public bool hasObject(string RFID)
        {
            return exec.HasObject(RFID);
        }

        public vw_Pk_All getSinglePKIn(string RFID)
        {
            return exec.GetSinglePKIn(RFID);
        }

        public pk_In_Out getSinglePKOut(string RFID)
        {
            return exec.GetSinglePKOut(RFID);
        }

        public Guid SavePKIn(string RFID, string Number, DateTime TimeIn, int VehicleTypeID)
        {
            pk_In_Out PKIn = new pk_In_Out();
            PKIn.ID = System.Guid.NewGuid();
            PKIn.RFID = RFID;
            PKIn.Number = Number;
            PKIn.TimeIn = TimeIn;
            PKIn.VehicleTypeID = VehicleTypeID;
            return exec.SavePKIn(PKIn);
        }

        public void SavePKOut(Guid ID, DateTime TimeOut)
        {
            pk_In_Out PKIn = new pk_In_Out();
            PKIn.TimeOut = TimeOut;
            exec.SavePKOut(ID, PKIn);
        }

        public pk_Price[] GetAllPrice()
        {
            return exec.GetAllPrice();
        }

        public IEnumerable<pk_Price> IEPrice()
        {
            return exec.IEPrice();
        }

        public decimal GetPriceByID(int ID)
        {
            return exec.GetPriceByID(ID);
        }

        public void SavePrice(string type, decimal price, string note)
        {
            pk_Price _object = new pk_Price();
            _object.VehicleType = type;
            _object.Price = price;
            _object.Note = note;
            exec.SavePrice(_object);
        }

        public void EditPrice(int ID, string type, decimal price, string note)
        {
            pk_Price _object = new pk_Price();
            _object.VehicleType = type;
            _object.Price = price;
            _object.Note = note;
            exec.EditPrice(ID, _object);
        }

        public void DeletePrice(int ID)
        {
            exec.DeletePrice(ID);
        }

        public void DeleteCard(string RFIDCard)
        {
            exec.DeleteCard(RFIDCard);
        }

        public pk_Camera[] GetAllCameras()
        {
            return exec.GetAllCameras();
        }

        public IEnumerable<pk_Camera> IECamera()
        {
            return exec.IECamera();
        }

        public IEnumerable<pk_In_Out> Search(string RFID, string Number, DateTime fromDate, DateTime toDate, bool isOut, bool isRFID, bool isNumber, bool isDate)
        {
            return exec.Search(RFID, Number, fromDate, toDate, isOut, isRFID, isNumber, isDate);
        }

        public void DeleteCamera(int cameraId)
        {
            exec.DeleteCamera(cameraId);
        }

        public void SaveCamera(string name, string provider, string desc, string source, string login, string password, string size, string type, string quality, string interval, bool isIn, bool position, int areadId)
        {
            pk_Camera cam = new pk_Camera();
            cam.Name = name;
            cam.provider = provider;
            cam.desc = desc;
            cam.source = source;
            cam.login = login;
            cam.password = password;
            cam.size = size;
            cam.type = type;
            cam.quality = quality;
            cam.interval = interval;
            cam.isIn = isIn;
            cam.position = position;
            cam.areaId = areadId;
            exec.SaveCamera(cam);
        }

        public void EditCamera(int cameraId, string name, string provider, string desc, string source, string login, string password, string size, string type, string quality, string interval, bool isIn, bool position, int areadId)
        {
            pk_Camera cam = new pk_Camera();
            cam.Name = name;
            cam.provider = provider;
            cam.desc = desc;
            cam.source = source;
            cam.login = login;
            cam.password = password;
            cam.size = size;
            cam.type = type;
            cam.quality = quality;
            cam.interval = interval;
            cam.isIn = isIn;
            cam.position = position;
            cam.areaId = areadId;
            exec.EditCamera(cameraId, cam);
        }

        public void getImage(Guid ID, ref byte[] arrImg, bool position)
        {
            exec.getImage(ID, ref arrImg, position);
        }

        public void setImage(Guid ID, byte[] arrImg, bool position)
        {
            exec.setImage(ID, arrImg, position);
        }

        public List<vw_Pk_All> TotalAmount(DateTime fromDate, DateTime toDate)
        {
            return exec.TotalAmount(fromDate, toDate);
        }


        public pk_In_Out[] getAllPKOut()
        {
            throw new NotImplementedException();
        }
    }
}